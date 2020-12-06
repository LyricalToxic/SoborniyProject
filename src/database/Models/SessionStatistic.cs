using System;
namespace SoborniyProject.database.Models
{
    public class SessionStatistic
    {
        public Int64 Id { get; set; }
        public Int64? SessionId { get; set; }
        public int PositionId { get; set; }
        public short AccelerationTime { get; set; }
        public short AccelerationDistance { get; set; }
        public short DecelerationTime { get; set; }
        public short DecelerationDistance { get; set; }
        public short LightTrafficStatus { get; set; }
        public int DistanceBetweenLightTraffic { get; set; }
        public int TimeBetweenLightTraffic { get; set; }
        public int CarSpeed { get; set; }
        public int SessionTime { get; set; }
        public DateTime UpdatedAt{ get; set; } 
        public DateTime CreatedAt{ get; set; } 
        public Session Session { get; set; } 
    }
}