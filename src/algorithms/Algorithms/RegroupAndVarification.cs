using SoborniyProject.src.algorithms.CarAndRoads;
using SoborniyProject.src.algorithms.TrafficLights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.Algorithms
{
    class RegroupAndVarification
    {


        public List<double> Cycles;

        public List<double> FullCycles;

        public List<double> SaveSeconds;

        public void Regroup(List<GreenLight> greens, List<RedLight> reds, List<YellowLight> yellows, RegroupAndVarification regroup, List<CarSessions> car_sessions, List<RoadInf> roads, int iter)
        {
            regroup.SaveSeconds = new List<double>();
            double full_time = 0;
            for (int local = 0; local < car_sessions.Count(); local++)
            {
                if (((car_sessions[local].BoostDistance * 2) - car_sessions[local].AccelerationPerSecond) <= 0)
                {
                    full_time += car_sessions[local].TimeAfterBoost;
                }
                else
                {
                    full_time += car_sessions[local].BoostTime +
                    car_sessions[local].TimeAfterBoost;
                }
            }
            if (greens[iter].CurrentLight == 1)
            {
                if (full_time - (greens[iter].LightDuration - greens[iter].CurrentLightSeconds) > 0)
                {
                    full_time = full_time - (greens[iter].LightDuration - greens[iter].CurrentLightSeconds);
                    for (; ; )
                    {
                        if (full_time - regroup.Cycles[iter] < 0)
                        {
                            regroup.Breaking(regroup, car_sessions, roads, iter, full_time);
                            break;
                        }
                        full_time = full_time - regroup.Cycles[iter];

                        if (full_time < greens[iter].LightDuration)
                        {
                            regroup.SaveSeconds.Add(greens[iter].LightDuration - full_time);
                            break;
                        }
                        full_time = full_time - greens[iter].LightDuration;
                    }
                }
                else if (full_time - (greens[iter].LightDuration - greens[iter].CurrentLightSeconds) <= 0)
                {
                    regroup.SaveSeconds.Add((full_time - (greens[iter].LightDuration - greens[iter].CurrentLightSeconds)) * -1);
                }
            }
            else if (reds[iter].CurrentLight == 1)
            {
                if (full_time - ((reds[iter].LightDuration - reds[iter].CurrentLightSeconds) + yellows[iter].LightDuration) > 0)
                {
                    full_time = full_time - ((reds[iter].LightDuration - reds[iter].CurrentLightSeconds) + yellows[iter].LightDuration);
                    regroup.Infinity_cycle_for_red_and_yellow(regroup, car_sessions, roads, greens, full_time, iter);
                }
                else if (full_time - ((reds[iter].LightDuration - reds[iter].CurrentLightSeconds) + yellows[iter].LightDuration) < 0)
                {
                    full_time = (full_time - ((reds[iter].LightDuration - reds[iter].CurrentLightSeconds) + yellows[iter].LightDuration)) * -1;
                    regroup.Breaking(regroup, car_sessions, roads, iter, full_time);
                }
                else
                {
                    regroup.SaveSeconds.Add(0);
                }
            }
            else if (yellows[iter].CurrentLight == 1)
            {
                if (yellows[iter].Next_color == 0)
                {
                    if ((full_time - (yellows[iter].LightDuration - yellows[iter].CurrentLightSeconds)) > 0)
                    {
                        full_time = full_time - (yellows[iter].LightDuration - yellows[iter].CurrentLightSeconds);
                        regroup.Infinity_cycle_for_red_and_yellow(regroup, car_sessions, roads, greens, full_time, iter);
                    }
                    else if (full_time - (yellows[iter].LightDuration - yellows[iter].CurrentLightSeconds) < 0)
                    {
                        regroup.Breaking(regroup, car_sessions, roads, iter, full_time);
                    }
                    else
                    {
                        regroup.SaveSeconds.Add(0);
                    }
                }
                else if (yellows[iter].Next_color == 1)
                {
                    if (((full_time - (yellows[iter].LightDuration - yellows[iter].CurrentLightSeconds)) - reds[iter].LightDuration) > 0)
                    {
                        full_time = (full_time - (yellows[iter].LightDuration - yellows[iter].CurrentLightSeconds)) - reds[iter].LightDuration;
                        regroup.Infinity_cycle_for_red_and_yellow(regroup, car_sessions, roads, greens, full_time, iter);
                    }
                    else if ((full_time - (yellows[iter].LightDuration - yellows[iter].CurrentLightSeconds)) - reds[iter].LightDuration < 0)
                    {
                        regroup.Breaking(regroup, car_sessions, roads, iter, full_time);
                    }
                    else
                    {
                        regroup.SaveSeconds.Add(0);
                    }
                }
            }
        }

        public void Breaking(RegroupAndVarification regroup, List<CarSessions> car_sessions, List<RoadInf> roads, int iter, double FullTime)
        {
            double not_green_time = FullTime + car_sessions[iter].TimeAfterBoost;
            BreakAlgorithm break_Algorithm = new BreakAlgorithm();
            break_Algorithm.Breaking(regroup, car_sessions, roads, iter, not_green_time);
        }

        public void Infinity_cycle_for_red_and_yellow(RegroupAndVarification regroup, List<CarSessions> car_sessions, List<RoadInf> roads, List<GreenLight> greens, double FullTime, int iter)
        {
            for (; ; )
            {
                if (FullTime - greens[iter].LightDuration < 0)
                {
                    regroup.SaveSeconds.Add((FullTime - greens[iter].LightDuration) * -1);
                    break;
                }
                else
                {
                    FullTime = FullTime - greens[iter].LightDuration;
                    if (FullTime - regroup.Cycles[iter] < 0)
                    {
                        regroup.Breaking(regroup, car_sessions, roads, iter, FullTime);
                        break;
                    }
                    FullTime = FullTime - regroup.Cycles[iter];
                }
            }
        }

        public void Find_cycle(List<GreenLight> greens, List<RedLight> reds, List<YellowLight> yellows, RegroupAndVarification regroup)
        {
            regroup.Cycles = new List<double>();
            regroup.FullCycles = new List<double>();
            for (int i = 0; i < greens.Count(); i++)
            {
                regroup.FullCycles.Add(greens[i].LightDuration + reds[i].LightDuration + yellows[i].LightDuration * 2);
                regroup.Cycles.Add(reds[i].LightDuration + yellows[i].LightDuration * 2);
            }
        }
    }
}
