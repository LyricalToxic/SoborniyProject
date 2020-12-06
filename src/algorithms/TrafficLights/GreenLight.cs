using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SoborniyProject.database.Context;
using SoborniyProject.database.Models;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class GreenLight :TrafficLight<GreenLight>
    {
        public override void DB_Inf(List<GreenLight> greens,string key)
        {
            var sites = greens[0].Context.LightTraffic.Where(p => p.Session.Key == key);
            int local_i = 0;
            foreach (var item in sites)
            {
                try
                {
                    if (item.GreenLightDuration <= 0) { throw new Exception($"{item.GreenLightDuration} must be > 0"); }
                    if (local_i == 0)
                    {
                        if (item.StartColor == 3) { greens[0].CurrentLight = 1; } else { greens[0].CurrentLight = 0; }
                        greens[0].CurrentLightSeconds = item.Status;
                        greens[0].LightDuration = item.GreenLightDuration;
                    }
                    else
                    {
                        int LocalLight = 0;
                        if (item.StartColor == 3) { LocalLight = 1; } else { LocalLight = 0; }
                        greens.Add(new GreenLight()
                        {
                            CurrentLight = LocalLight,
                            LightDuration = item.GreenLightDuration,
                            CurrentLightSeconds = item.Status

                        });
                    }
                    local_i = 1;
                }
                catch (Exception ex)
                {
                    //($"Erorr :{ex.Message}");
                }
            }


        }

    }
}
