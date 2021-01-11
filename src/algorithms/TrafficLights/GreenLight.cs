using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class GreenLight :TrafficLight<GreenLight>
    {
        public override void DB_Inf(List<GreenLight> greens,string key)
        {
            //var sites = greens[0].Context.LightTraffic.OrderBy( ).Where(p => p.Session.Key == key);
            var sites = from p in greens[0].Context.LightTraffic orderby p.PositionId where p.Session.Key == key select p;
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
                        greens[0].PositionId = item.PositionId;
                        greens[0].SessionId = (int)item.SessionId;
                    }
                    else
                    {
                        int LocalLight = 0;
                        if (item.StartColor == 3) { LocalLight = 1; } else { LocalLight = 0; }
                        greens.Add(new GreenLight()
                        {
                            CurrentLight = LocalLight,
                            LightDuration = item.GreenLightDuration,
                            CurrentLightSeconds = item.Status,
                            PositionId = item.PositionId,
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
