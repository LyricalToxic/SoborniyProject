using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class YellowLight :TrafficLight<YellowLight>
    {
        public int Next_color { set; get; }
        public override void DB_Inf(List<YellowLight> yellows,string key)
        {
            //var sites = yellows[0].Context.LightTraffic.Where(p => p.Session.Key == key);
            var sites = from p in yellows[0].Context.LightTraffic orderby p.PositionId where p.Session.Key == key select p;
            int local_i = 0;
            foreach (var item in sites)
            {
                try
                {
                    if (item.RedLightDuration <= 0) { throw new Exception($"{ item.RedLightDuration } must be > 0"); }
                    if (local_i == 0)
                    {
                        if (item.StartColor == 2) { yellows[0].CurrentLight = 1; } else { yellows[0].CurrentLight = 0; }
                        yellows[0].CurrentLightSeconds = item.Status;
                        yellows[0].LightDuration = item.GreenLightDuration;
                        yellows[0].PositionId = item.PositionId;
                        yellows[0].SessionId = (int)item.SessionId;
                    }
                    else
                    {
                        int LocalLight = 0;
                        if (item.StartColor == 2) { LocalLight = 1; } else { LocalLight = 0; }
                        yellows.Add(new YellowLight()
                        {
                            CurrentLight = LocalLight,
                            LightDuration = item.GreenLightDuration,
                            CurrentLightSeconds = item.Status,
                            PositionId =item.PositionId,
                            SessionId = (int)item.SessionId,
                        });
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
