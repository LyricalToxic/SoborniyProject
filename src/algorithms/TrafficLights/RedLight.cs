using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class RedLight :TrafficLight<RedLight>
    {
        public override void In_from_BD(List<RedLight> reds)
        {
            string name_of_my_file = @"D:\C#\for_projectX\For_projectX\For_projectX\Data\Red.txt";

            using (StreamReader stream_read = new StreamReader(name_of_my_file, true))
            {
                reds[0].Current_light = Convert.ToInt32(stream_read.ReadLine());
                reds[0].Current_time_of_light = Convert.ToInt32(stream_read.ReadLine());
                reds[0].Seconds_of_light = Convert.ToInt32(stream_read.ReadLine());
                reds[0].id = Convert.ToInt32(stream_read.ReadLine());
                while (!stream_read.EndOfStream)
                {
                    reds.Add(new RedLight()
                    {
                        Current_light = Convert.ToInt32(stream_read.ReadLine()),
                        Current_time_of_light = Convert.ToInt32(stream_read.ReadLine()),
                        Seconds_of_light = Convert.ToInt32(stream_read.ReadLine()),

                        id = Convert.ToInt32(stream_read.ReadLine())
                    });


                }

            }
        }

    }
}
