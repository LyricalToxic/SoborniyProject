
using System;

namespace SoborniyProject.database.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int Status { get; set; }
        public string TotalTime { get; set; }
        public DateTime CreatedAt{ get; set; } 
        public DateTime UpdatedAt{ get; set; } 
    }
}