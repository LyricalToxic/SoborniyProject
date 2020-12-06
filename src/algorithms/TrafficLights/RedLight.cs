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
    public class RedLight :TrafficLight<RedLight>
    {
        public override void DB_Inf(List<RedLight> reds,string key)
        {
            var sites = reds[0].Context.LightTraffic.Where(p => p.Session.Key == key);
            int local_i = 0;
            foreach (var item in sites)
            {
                try
                {
                    if (item.RedLightDuration <= 0) { throw new Exception($"{ item.RedLightDuration } must be > 0"); }
                    if (local_i == 0)
                    {
                        if (item.StartColor == 1) { reds[0].CurrentLight = 1; } else { reds[0].CurrentLight = 0; }
                        reds[0].CurrentLightSeconds = item.Status;
                        reds[0].LightDuration = item.GreenLightDuration;
                    }
                    else
                    {
                        int LocalLight = 0;
                        if (item.StartColor == 1) { LocalLight = 1; } else { LocalLight = 0; }
                        reds.Add(new RedLight()
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
