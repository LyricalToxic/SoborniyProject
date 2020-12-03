using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SoborniyProject.src.algorithms.CarAndRoads
{
    public class Car_Inf
    {


        public double max_speed_of_car;

        public double boost_speed_per_second;

        public double breaking_facilities;

        public void Inf_from_BD(Car_Inf car)
        {
            string name_of_my_file = @"D:\C#\for_projectX\For_projectX\For_projectX\Data\for_Car_Aspeed.txt";

            using (StreamReader stream_read = new StreamReader(name_of_my_file, true))
            {
                car.boost_speed_per_second = Convert.ToDouble(stream_read.ReadLine());
                car.max_speed_of_car = Convert.ToDouble(stream_read.ReadLine());
                car.breaking_facilities = Convert.ToDouble(stream_read.ReadLine());
            }

        }
    }
}
