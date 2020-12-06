using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SoborniyProject.database.Context;
using SoborniyProject.database.Models;

namespace SoborniyProject.src.algorithms.CarAndRoads
{
    public class RoadInf
    {
        private int id;

        public double DistaceRoadSite;

        public SoborniyContext Context;
        public void Inf_from_BD(List<RoadInf> roads,string key)
        {

            var sites = roads[0].Context.LightTraffic.Where(p => p.Session.Key == key);

            int local_i = 0;
            foreach (var item in sites)
                {
                  if (local_i == 0)
                    {
                    roads[0].DistaceRoadSite = item.PreviousDistance;
                    }
                    else
                    {
                    roads.Add(new RoadInf()
                    {
                        DistaceRoadSite = item.PreviousDistance,
                    });
                    }
                    local_i = 1;
                }
            
        }
    }
}
