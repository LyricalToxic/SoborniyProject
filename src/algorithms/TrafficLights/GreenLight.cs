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
        public override void DB_Inf(List<GreenLight> greens,long key)
        {
            var sites = greens[0].Context.LightTraffic.Where(p => p.SessionId.Value == key);
            int local_i = 0;
            foreach (var item in sites)
            {
                try
                {
                    if (item.GreenLightDurationSec <= 0) { throw new Exception($"{item.GreenLightDurationSec} must be > 0"); }
                    if (local_i == 0)
                    {
                        if (item.StartColor == 3) { greens[0].CurrentLight = 1; } else { greens[0].CurrentLight = 0; }
                        greens[0].CurrentLightSeconds = item.Status;
                        greens[0].LightDuration = item.GreenLightDurationSec;
                    }
                    else
                    {
                        int LocalLight = 0;
                        if (item.StartColor == 3) { LocalLight = 1; } else { LocalLight = 0; }
                        greens.Add(new GreenLight()
                        {
                            CurrentLight = LocalLight,
                            LightDuration = item.GreenLightDurationSec,
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
