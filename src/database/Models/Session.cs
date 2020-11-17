using System;
using System.Collections.Generic;


namespace SoborniyProject.database.Models
{
    public class Session
    {
        public Int64 Id { get; set; }
        public string Key { get; set; }
        public int Status { get; set; }
        public int TotalTime { get; set; }
        public DateTime CreatedAt{ get; set; } 
        public DateTime UpdatedAt{ get; set; } 
        
        public Car Car { get; set; }
        
        public List<LightTraffic> LightTraffics{ get; set; }
        
        public List<SessionStatistic> SessionStatistics { get; set; }
    }
}