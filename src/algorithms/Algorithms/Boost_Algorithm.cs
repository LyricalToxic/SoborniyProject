using SoborniyProject.src.algorithms.CarAndRoads;
using SoborniyProject.src.algorithms.TrafficLights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.Algorithms
{
    class Boost_Algorithm
    {


        public void Boost_Way(List<Car_Sessions> car_sessions, List<Road_Inf> roads, Boost_Algorithm position_Braking_or_Boost)//считает сколько времни надо ехать чтоб преодолеть нужное расстояние
        {
            List<GreenLight> greens = new List<GreenLight>();
            List<RedLight> reds = new List<RedLight>();
            List<YellowLight> yellows = new List<YellowLight>();
            greens.Add(new GreenLight() { });
            reds.Add(new RedLight() { });
            yellows.Add(new YellowLight() { });

            yellows[0].In_from_BD(yellows);
            greens[0].In_from_BD(greens);
            reds[0].In_from_BD(reds);

            RegroupAndCheck regroup = new RegroupAndCheck();

            regroup.Find_cycle(greens, reds, yellows, regroup);

            for (int i = 0; i < roads.Count(); i++)
            {
                if (i - 1 > 0 && car_sessions[i - 1].speed_between_boost_and_breaking == 0)
                {
                    car_sessions[i - 1].time_of_breaking = 0;
                }
                car_sessions[i].Full_s = car_sessions[i].S_of_Boost;//в полный путь занес результат разгона
                while (car_sessions[i].S_after_Boost + car_sessions[i].S_of_Boost < roads[i].S_Road - car_sessions[i].S_of_Boost) //если мы достигли нужного расстояния завершаем 
                {

                    double s;
                    s = roads[i].S_Road - car_sessions[i].S_of_Boost;//от нужного пуtи удаляем уже найденый
                    if (car_sessions[i].S_after_Boost + car_sessions[i].Current_speed < s)//добавляем к пути расстояник которое машина проходит за секунду
                    {
                        double time;
                        time = ((s * 100) / car_sessions[i].Current_speed) / 100;
                        car_sessions[i].S_after_Boost += s;
                        car_sessions[i].Time_after_Boost += time;
                        break;
                    }
                }
                car_sessions[i].Full_s += car_sessions[i].S_after_Boost;//полный путь

                position_Braking_or_Boost.First_Fase_of_Check_on_colour(car_sessions, roads, i, greens, reds, yellows, regroup);//проверка времени относительно светофора
                if (i - 1 >= 0)
                {
                    if (car_sessions[i - 1].New_limit_of_speed > car_sessions[i].New_limit_of_speed)
                    {
                        car_sessions[i].Time_of_Boost = 0;
                        car_sessions[i].S_of_Boost = 0;
                        car_sessions[i].S_after_Boost = 0;
                        car_sessions[i].Time_after_Boost = 0;
                        car_sessions[i].Current_speed = car_sessions[i].New_limit_of_speed * 1000 / 3600;
                        car_sessions[i].time_of_breaking = ((car_sessions[i - 1].New_limit_of_speed - car_sessions[i].New_limit_of_speed) * car_sessions[0].Breaking_facilities) / 100;
                        car_sessions[i].speed_between_boost_and_breaking = (car_sessions[i - 1].New_limit_of_speed - car_sessions[i].New_limit_of_speed) * -1;
                        car_sessions[i].S_after_Boost = roads[i].S_Road;
                        car_sessions[i].Time_after_Boost = car_sessions[i].time_of_breaking + (roads[i].S_Road / ((car_sessions[i].New_limit_of_speed * 1000) / 3600));
                        position_Braking_or_Boost.Zeroing_and_go_to_next(car_sessions, roads, i);
                    }
                    else if (car_sessions[i - 1].New_limit_of_speed < car_sessions[i].New_limit_of_speed)
                    {
                        car_sessions[i].S_of_Boost = 0;
                        car_sessions[i].S_after_Boost = 0;
                        car_sessions[i].Time_after_Boost = 0;
                        car_sessions[i].Time_of_Boost = 0;
                        car_sessions[i].Current_speed = (car_sessions[i].New_limit_of_speed * 1000) / (60 * 60);
                        car_sessions[i].Time_of_Boost = (car_sessions[i].Current_speed - (car_sessions[i - 1].New_limit_of_speed * 1000 / 3600)) / car_sessions[0].Boost_speed_per_second;
                        car_sessions[i].S_of_Boost = (car_sessions[0].Boost_speed_per_second * Math.Pow(car_sessions[i].Time_of_Boost, 2)) / 2;
                        car_sessions[i].S_after_Boost = (roads[i].S_Road - car_sessions[i].S_of_Boost);
                        car_sessions[i].Time_after_Boost = car_sessions[i].S_after_Boost / ((car_sessions[i].New_limit_of_speed * 1000) / (60 * 60));
                        position_Braking_or_Boost.Zeroing_and_go_to_next(car_sessions, roads, i);
                    }
                    else { position_Braking_or_Boost.Zeroing_and_go_to_next(car_sessions, roads, i); }
                }
                else { position_Braking_or_Boost.Zeroing_and_go_to_next(car_sessions, roads, i); }
            }

        }


        public void Zeroing_and_go_to_next(List<Car_Sessions> car_sessions, List<Road_Inf> roads, int i)
        {
            if (roads.Count > i + 1)
            {
                car_sessions.Add(new Car_Sessions());
                car_sessions[i + 1].S_after_Boost = 0;
                car_sessions[i + 1].S_of_Boost = 0;
                car_sessions[i + 1].Time_after_Boost = 0;
                car_sessions[i + 1].Time_of_Boost = 0;
                if (car_sessions[i].New_limit_of_speed < car_sessions[0].Max_speed_of_car)
                {
                    car_sessions[i + 1].New_limit_of_speed = car_sessions[0].Max_speed_of_car;
                    car_sessions[i + 1].Current_speed = car_sessions[i + 1].New_limit_of_speed * 1000 / 3600;
                    car_sessions[i + 1].Time_of_Boost = (car_sessions[i + 1].Current_speed - (car_sessions[i].New_limit_of_speed * 1000 / 3600)) / car_sessions[0].Boost_speed_per_second;
                    car_sessions[i + 1].S_of_Boost = (car_sessions[0].Boost_speed_per_second * Math.Pow(car_sessions[i + 1].Time_of_Boost, 2)) / 2;
                    car_sessions[i + 1].S_after_Boost = roads[i + 1].S_Road - car_sessions[i + 1].S_of_Boost;
                    car_sessions[i + 1].Time_after_Boost = car_sessions[i + 1].S_after_Boost / (car_sessions[i + 1].New_limit_of_speed * 1000 / 3600);
                }
                else
                {

                    car_sessions[i + 1].New_limit_of_speed = car_sessions[i].New_limit_of_speed;
                    car_sessions[i + 1].Current_speed = car_sessions[i].New_limit_of_speed * 1000 / 3600;
                    car_sessions[i + 1].S_after_Boost = roads[i + 1].S_Road;
                    car_sessions[i + 1].Time_after_Boost = roads[i + 1].S_Road / (car_sessions[i].New_limit_of_speed * 1000 / 3600);
                }
            }
        }

        public void First_Fase_of_Check_on_colour(List<Car_Sessions> car_sessions, List<Road_Inf> roads, int i, List<GreenLight> greens, List<RedLight> reds, List<YellowLight> yellows, RegroupAndCheck regroup)
        {
            regroup.Regroup(greens, reds, yellows, regroup, car_sessions, roads, i);
        }
    }
}
