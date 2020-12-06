using SoborniyProject.src.algorithms.CarAndRoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.Algorithms
{
    class BreakAlgorithm
    {
        public void Breaking(RegroupAndVarification regroup, List<CarSessions> car_sessions, List<RoadInf> roads, int iter, double waiting_time)
        {

            if (iter - 1 >= 0)
            {
                double full_time_before_new_peace = 0;
                for (int j = 0; j < car_sessions.Count() - 1; j++)
                {
                    full_time_before_new_peace += Math.Sqrt((car_sessions[j].BoostDistance * 2) - car_sessions[j].AccelerationPerSecond) +
                                car_sessions[j].TimeAfterBoost;
                }
                for (; ; )
                {
                    if (roads[iter].DistaceRoadSite / waiting_time <= car_sessions[0].CarMaxSpeed * 1000 / 3600)
                    {


                        car_sessions[iter].SpeedLimit = ((roads[iter].DistaceRoadSite / waiting_time) * 3600 / 1000);
                        if (car_sessions[iter].SpeedLimit < 5) { }
                        car_sessions[iter].BreakingTime = ((roads[iter].DistaceRoadSite / waiting_time) * car_sessions[0].BreakingAbility) / 100;
                        break;
                    }
                    else
                    {
                        waiting_time += regroup.FullCycles[iter];
                    }

                }
                if (car_sessions[iter].SpeedLimit < 5) { car_sessions[0].SessionLose = 1; }
            }
        }

    }
}
