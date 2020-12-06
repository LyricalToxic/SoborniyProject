using System;

namespace SoborniyProject.database.Models
{
    public class LightTraffic
    {
        public Int64 Id { get; set; }
        public Int64? SessionId { get; set; }
        public int PositionId { get; set; }
        public int RedLightDuration { get; set; }
        public int YellowLightDuration { get; set; }
        public int GreenLightDuration { get; set; }
        public short StartColor { get; set; }
        public short NextColor { get; set; }
        public short Status { get; set; }
        public float PreviousDistance  { get; set; }
        public DateTime CreatedAt{ get; set; } 
        public DateTime UpdatedAt{ get; set; } 
        
        public Session Session { get; set; } 
    }
}