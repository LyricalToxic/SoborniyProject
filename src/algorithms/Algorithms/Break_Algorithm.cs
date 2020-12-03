using SoborniyProject.src.algorithms.CarAndRoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.Algorithms
{
    class Break_Algorithm
    {
        public void Breaking(RegroupAndCheck regroup, List<Car_Sessions> cars, List<Road_Inf> roads, int i, double waiting_time)
        {

            if (i - 1 >= 0)
            {
                double full_time_before_new_peace = 0;
                for (int j = 0; j < cars.Count() - 1; j++)
                {
                    full_time_before_new_peace += Math.Sqrt((cars[j].S_of_Boost * 2) - cars[j].Boost_speed_per_second) +
                                cars[j].Time_after_Boost;
                }
                for (; ; )
                {
                    if (roads[i].S_Road / waiting_time > 0.1 && roads[i].S_Road / waiting_time < 19.44)
                    {
                        double speed_on_breaking;
                        double time_of_breaking;
                        //waiting_time += (((roads[i].Get_Set_S_road / waiting_time)*3600/1000)*cars[0].Get_Set_Breaking_facilities)/ 10;

                        cars[i].New_limit_of_speed = ((roads[i].S_Road / waiting_time) * 3600 / 1000);
                        cars[i].time_of_breaking = ((roads[i].S_Road / waiting_time) * cars[0].Breaking_facilities) / 100;
                        break;
                    }
                    else
                    {
                        waiting_time += regroup.full_cycles[i];

                        //возвращаемся назад на пред участок
                    }
                }
            }
        }

    }
}
