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
    public class YellowLight :TrafficLight<YellowLight>
    {
        public int Next_color { set; get; }
        public override void DB_Inf(List<YellowLight> yellows,long key)
        {
            using (SoborniyContext db = new SoborniyContext())
            {
                var sites = db.LightTraffic.Where(p => p.SessionId.Value == key);
                int local_i = 0;
                foreach (var item in sites)
                {
                    try
                    {
                        if (item.RedLightDurationSec <= 0) { throw new Exception($"{ item.RedLightDurationSec } must be > 0"); }
                        if (local_i == 0)
                        {
                            if (item.StartColor == 2) { yellows[0].CurrentLight = 1; } else { yellows[0].CurrentLight = 0; }
                            yellows[0].CurrentLightSeconds = item.Status;
                            yellows[0].LightDuration = item.GreenLightDurationSec;
                        }
                        else
                        {
                            int LocalLight = 0;
                            if (item.StartColor == 2) { LocalLight = 1; } else { LocalLight = 0; }
                            yellows.Add(new YellowLight()
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
}
