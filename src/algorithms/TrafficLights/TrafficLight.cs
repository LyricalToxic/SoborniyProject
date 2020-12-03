using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public abstract class TrafficLight<T>
    {
        public int Current_light { get; set; }

        public double Current_time_of_light { get; set; }

        public double Seconds_of_light { get; set; }

        public int id { get; set; }

        public abstract void In_from_BD(List<T> obj);

    }
}
