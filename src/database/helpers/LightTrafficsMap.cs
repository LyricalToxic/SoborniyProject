using CsvHelper.Configuration;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.helpers
{
    public class LightTrafficsMap: ClassMap<LightTraffic>
    {
        public LightTrafficsMap()
        {
            Map(m => m.PositionId);
            Map(m => m.RedLightDurationSec);
            Map(m => m.YellowLightDurationSec);
            Map(m => m.GreenLightDurationSec);
            Map(m => m.StartColor);
            Map(m => m.NextColor);
            Map(m => m.Status);
            Map(m => m.PreviousDistance);
        }
    }
}