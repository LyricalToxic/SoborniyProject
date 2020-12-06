using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoborniyProject.database.Models;
using SoborniyProject.database.Context;


namespace SoborniyProject.src.algorithms.TrafficLights
{
    public abstract class TrafficLight<T>
    {

        public SoborniyContext Context { get; set; }
        public int CurrentLight { get; set; }

        public double CurrentLightSeconds { get; set; }

        public double LightDuration { get; set; }

        public int id { get; set; }

        public abstract void DB_Inf(List<T> obj,string key);

    }
}
