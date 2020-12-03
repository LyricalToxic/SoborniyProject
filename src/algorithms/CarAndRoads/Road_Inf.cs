using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SoborniyProject.src.algorithms.CarAndRoads
{
    class Road_Inf
    {
        private int id;

        private double s_road;

        public void Inf_from_BD(List<Road_Inf> roads)
        {
            string name_of_my_file = @"D:\C#\for_projectX\For_projectX\For_projectX\Data\for_Road.txt";

            using (StreamReader stream_read = new StreamReader(name_of_my_file, true))
            {
                roads[0].s_road = Convert.ToDouble(stream_read.ReadLine());
                while (!stream_read.EndOfStream)
                {
                    roads.Add(new Road_Inf()
                    {
                        s_road = Convert.ToDouble(stream_read.ReadLine()),
                    });
                }
            }
        }

        public double S_Road
        {
            get
            {
                return s_road;
            }
            set
            {
                s_road = value;
            }
        }
    }
}
