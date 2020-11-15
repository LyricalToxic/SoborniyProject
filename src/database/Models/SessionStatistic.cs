using System;
namespace SoborniyProject.database.Models
{
    public class SessionStatistic
    {
        public Int64 Id { get; set; }
        public Int64 SessionId { get; set; }
        public int PositionId { get; set; }
        public short LightColor { get; set; }
        public short NextLightColor { get; set; }
        public short LightTrafficStatus { get; set; }
        public int DurationLeftSec { get; set; }
        public int CarSpeed { get; set; }
        public int SessionTime { get; set; }
        public DateTime UpdatedAt{ get; set; } 
    }
}