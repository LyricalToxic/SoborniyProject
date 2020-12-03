using SoborniyProject.src.algorithms.CarAndRoads;
using SoborniyProject.src.algorithms.TrafficLights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.Algorithms
{
    class RegroupAndCheck
    {

        public List<double> cycles;

        public List<double> full_cycles;

        public List<double> saving_seconds;

        private List<double> time_of_intersection;

        public void Regroup(List<GreenLight> greens, List<RedLight> reds, List<YellowLight> yellows, RegroupAndCheck regroup, List<Car_Sessions> car_sessions, List<Road_Inf> roads, int i)
        {
            regroup.saving_seconds = new List<double>();
            double full_time = 0;
            for (int g = 0; g < car_sessions.Count(); g++)
            {
                if (((car_sessions[g].S_of_Boost * 2) - car_sessions[g].Boost_speed_per_second) <= 0)
                {
                    full_time += car_sessions[g].Time_after_Boost;
                }
                else
                {
                    full_time += car_sessions[g].Time_of_Boost +
                    car_sessions[g].Time_after_Boost;
                }
            }
            if (greens[i].Current_light == 1)
            {
                if (full_time - (greens[i].Seconds_of_light - greens[i].Current_time_of_light) > 0)
                {
                    full_time = full_time - (greens[i].Seconds_of_light - greens[i].Current_time_of_light);
                    for (; ; )
                    {
                        if (full_time - regroup.cycles[i] < 0)
                        {
                            regroup.Breaking(regroup, car_sessions, roads, i, full_time);
                            //тормаза
                            break;
                        }
                        full_time = full_time - regroup.cycles[i];

                        if (full_time < greens[i].Seconds_of_light)
                        {
                            regroup.saving_seconds.Add(greens[i].Seconds_of_light - full_time);
                            //ок успели
                            break;
                        }
                        full_time = full_time - greens[i].Seconds_of_light;
                    }
                }
                else if (full_time - (greens[i].Seconds_of_light - greens[i].Current_time_of_light) <= 0)
                {
                    regroup.saving_seconds.Add((full_time - (greens[i].Seconds_of_light - greens[i].Current_time_of_light)) * -1);
                    //ок успели
                }
            }
            else if (reds[i].Current_light == 1)
            {
                if (full_time - ((reds[i].Seconds_of_light - reds[i].Current_time_of_light) + yellows[i].Seconds_of_light) > 0)
                {
                    full_time = full_time - ((reds[i].Seconds_of_light - reds[i].Current_time_of_light) + yellows[i].Seconds_of_light);
                    regroup.Infinity_cycle_for_red_and_yellow(regroup, car_sessions, roads, greens, full_time, i);
                }
                else if (full_time - ((reds[i].Seconds_of_light - reds[i].Current_time_of_light) + yellows[i].Seconds_of_light) < 0)
                {
                    full_time = (full_time - ((reds[i].Seconds_of_light - reds[i].Current_time_of_light) + yellows[i].Seconds_of_light)) * -1;
                    regroup.Breaking(regroup, car_sessions, roads, i, full_time);
                    //тормаза
                }
                else
                {
                    regroup.saving_seconds.Add(0);
                }
            }
            else if (yellows[i].Current_light == 1)
            {
                if (yellows[i].Next_color == 0)
                {
                    if ((full_time - (yellows[i].Seconds_of_light - yellows[i].Current_time_of_light)) > 0)
                    {
                        full_time = full_time - (yellows[i].Seconds_of_light - yellows[i].Current_time_of_light);
                        regroup.Infinity_cycle_for_red_and_yellow(regroup, car_sessions, roads, greens, full_time, i);
                    }
                    else if (full_time - (yellows[i].Seconds_of_light - yellows[i].Current_time_of_light) < 0)
                    {
                        regroup.Breaking(regroup, car_sessions, roads, i, full_time);
                        //тормаза
                    }
                    else
                    {
                        regroup.saving_seconds.Add(0);
                    }
                }
                else if (yellows[i].Next_color == 1)
                {
                    if (((full_time - (yellows[i].Seconds_of_light - yellows[i].Current_time_of_light)) - reds[i].Seconds_of_light) > 0)
                    {
                        full_time = (full_time - (yellows[i].Seconds_of_light - yellows[i].Current_time_of_light)) - reds[i].Seconds_of_light;
                        regroup.Infinity_cycle_for_red_and_yellow(regroup, car_sessions, roads, greens, full_time, i);
                    }
                    else if ((full_time - (yellows[i].Seconds_of_light - yellows[i].Current_time_of_light)) - reds[i].Seconds_of_light < 0)
                    {
                        regroup.Breaking(regroup, car_sessions, roads, i, full_time);
                        //тормаза
                    }
                    else
                    {
                        regroup.saving_seconds.Add(0);
                    }
                }
            }
        }

        public void Breaking(RegroupAndCheck regroup, List<Car_Sessions> car_sessions, List<Road_Inf> roads, int i, double full_time)
        {
            double not_green_time = full_time + car_sessions[i].Time_after_Boost;
            Break_Algorithm break_Algorithm = new Break_Algorithm();
            break_Algorithm.Breaking(regroup, car_sessions, roads, i, not_green_time);
        }

        public void Infinity_cycle_for_red_and_yellow(RegroupAndCheck regroup, List<Car_Sessions> car_sessions, List<Road_Inf> roads, List<GreenLight> greens, double full_time, int i)
        {
            for (; ; )
            {
                if (full_time - greens[i].Seconds_of_light < 0)
                {
                    regroup.saving_seconds.Add((full_time - greens[i].Seconds_of_light) * -1);
                    //все ок
                    break;
                }
                else
                {
                    full_time = full_time - greens[i].Seconds_of_light;
                    if (full_time - regroup.cycles[i] < 0)
                    {
                        regroup.Breaking(regroup, car_sessions, roads, i, full_time);
                        //тормаза
                        break;
                    }
                    full_time = full_time - regroup.cycles[i];
                }
            }
        }

        public void Find_cycle(List<GreenLight> greens, List<RedLight> reds, List<YellowLight> yellows, RegroupAndCheck regroup)
        {
            regroup.cycles = new List<double>();
            regroup.full_cycles = new List<double>();
            for (int i = 0; i < greens.Count(); i++)
            {
                regroup.full_cycles.Add(greens[i].Seconds_of_light + reds[i].Seconds_of_light + yellows[i].Seconds_of_light * 2);
                regroup.cycles.Add(reds[i].Seconds_of_light + yellows[i].Seconds_of_light * 2);//+yellow
            }
        }
    }
}
