
using System;
using System.Numerics;

namespace SoborniyProject.database.Models
{
    public class Session
    {
        public Int64 Id { get; set; }
        public string Key { get; set; }
        public int Status { get; set; }
        public string TotalTime { get; set; }
        public DateTime CreatedAt{ get; set; } 
        public DateTime UpdatedAt{ get; set; } 
    }
}