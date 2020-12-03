using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class GreenLight :TrafficLight<GreenLight>
    {
        public override void In_from_BD(List<GreenLight> greens)
        {
            string name_of_my_file = @"D:\C#\for_projectX\For_projectX\For_projectX\Data\Green.txt";

            using (StreamReader stream_read = new StreamReader(name_of_my_file, true))
            {
                greens[0].Current_light = Convert.ToInt32(stream_read.ReadLine());
                greens[0].Current_time_of_light = Convert.ToInt32(stream_read.ReadLine());
                greens[0].Seconds_of_light = Convert.ToInt32(stream_read.ReadLine());
                greens[0].id = Convert.ToInt32(stream_read.ReadLine());

                while (!stream_read.EndOfStream)
                {
                    greens.Add(new GreenLight()
                    {
                        Current_light = Convert.ToInt32(stream_read.ReadLine()),
                        Current_time_of_light = Convert.ToDouble(Convert.ToInt32(stream_read.ReadLine())),
                        Seconds_of_light = Convert.ToDouble(Convert.ToInt32(stream_read.ReadLine())),

                        id = Convert.ToInt32(stream_read.ReadLine())
                    });
                }

            }
        }

    }
}
