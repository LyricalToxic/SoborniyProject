﻿using System;

namespace SoborniyProject.database.Models
{
    public class Car
    {
        public Int64 Id { get; set; }
        public Int64? SessionId { get; set; }
        public string Name { get; set; }
        public float MaxSpeed { get; set; }
        public double Acceleration { get; set; }
        public double  Deceleration { get; set; }
        public DateTime CreatedAt{ get; set; } 
        public DateTime UpdatedAt{ get; set; } 
        
        public Session Session { get; set; } 
    }
}