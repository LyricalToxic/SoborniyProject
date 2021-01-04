using System;
namespace SoborniyProject.database.Models
{
    public class SessionStatistic
    {
        public Int64 Id { get; set; }
        public Int64? SessionId { get; set; }
        public int PositionId { get; set; }
        public double  AccelerationTime { get; set; }
        public double AccelerationDistance { get; set; }
        public double  DecelerationTime { get; set; }
        public double  DecelerationDistance { get; set; }
        public short LightTrafficStatus { get; set; }
        public double  DistanceBetweenLightTraffic { get; set; }
        public double  TimeBetweenLightTraffic { get; set; }
        public int CarSpeed { get; set; }
        public double  SessionTime { get; set; }

        //public DateTime CreatedAt{ get; set; } 
        public byte[] CreatedAt{ get; set; } 
        //public DateTime UpdatedAt{ get; set; } 
        public byte[] UpdatedAt{ get; set; } 
        public Session Session { get; set; } 
    }
}