using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class RedLight :TrafficLight<RedLight>
    {
        public override void DB_Inf(List<RedLight> reds,string key)
        {
            //var sites = reds[0].Context.LightTraffic.Where(p => p.Session.Key == key);
            var sites = from p in reds[0].Context.LightTraffic orderby p.PositionId where p.Session.Key == key select p;
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
                        reds[0].SessionId = (int)item.SessionId;
                        reds[0].PositionId = item.PositionId;
                    }
                    else
                    {
                        int LocalLight = 0;
                        if (item.StartColor == 1) { LocalLight = 1; } else { LocalLight = 0; }
                        reds.Add(new RedLight()
                        {
                            CurrentLight = LocalLight,
                            LightDuration = item.GreenLightDuration,
                            CurrentLightSeconds = item.Status,
                            PositionId = item.PositionId,
                            SessionId = (int)item.SessionId,
                        }); ;
                    }
                    local_i = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erorr :{ex.Message}");
                }
            }


        }
    }
}
