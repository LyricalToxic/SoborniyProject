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
    class RoadInf
    {
        private int id;

        public double DistaceRoadSite;

        public void Inf_from_BD(List<RoadInf> roads,long key)
        {
            using (SoborniyContext db = new SoborniyContext())
            {
                var sites = db.LightTraffic.Where(p => p.SessionId.Value == key);
                int local_i=0;
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
}
