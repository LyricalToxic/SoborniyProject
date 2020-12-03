using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoborniyProject.src.algorithms.TrafficLights
{
    public class YellowLight :TrafficLight<YellowLight>
    {
        public int Next_color { set; get; }
        public override void In_from_BD(List<YellowLight> yellows)
        {
            string name_of_my_file = @"D:\C#\for_projectX\For_projectX\For_projectX\Data\Yellow.txt";

            using (StreamReader stream_read = new StreamReader(name_of_my_file, true))
            {
                yellows[0].Current_light = Convert.ToInt32(stream_read.ReadLine());
                yellows[0].Current_time_of_light = Convert.ToDouble(stream_read.ReadLine());
                yellows[0].Seconds_of_light = Convert.ToDouble(stream_read.ReadLine());
                yellows[0].Next_color = Convert.ToInt32(stream_read.ReadLine());
                yellows[0].id = Convert.ToInt32(stream_read.ReadLine());

                while (!stream_read.EndOfStream)
                {
                    yellows.Add(new YellowLight()
                    {
                        Current_light = Convert.ToInt32(stream_read.ReadLine()),
                        Current_time_of_light = Convert.ToDouble(stream_read.ReadLine()),
                        Seconds_of_light = Convert.ToDouble(stream_read.ReadLine()),
                        Next_color = Convert.ToInt32(stream_read.ReadLine()),
                        id = Convert.ToInt32(stream_read.ReadLine())
                    });
                }

            }
        }
    }
}
