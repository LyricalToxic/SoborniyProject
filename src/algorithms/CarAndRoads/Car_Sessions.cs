using SoborniyProject.database.Models;
using SoborniyProject.database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.CarAndRoads
{
    class Car_Sessions
    {
        private double max_speed_of_car;

        private double new_limit_of_speed;

        private double boost_speed_per_second;

        private double breaking_facilities;

        public double time_of_breaking;

        public double speed_between_boost_and_breaking;

        private double time_after_boost;

        private double time_of_boost;

        private double s_of_boost;

        private double s_after_boost;

        private double full_s;

        private double current_speed;

        public Car_Inf car_Inf;

        public double we_was_here { get; set; }

        public void start_convert_data(List<Car_Sessions> car_sessions, List<Road_Inf> roads)//вызывает другие методы
        {
            Car_Inf car_Inf = new Car_Inf();
            car_Inf.Inf_from_BD(car_Inf);
            car_sessions[0].Max_speed_of_car = car_Inf.max_speed_of_car;
            car_sessions[0].new_limit_of_speed = car_Inf.max_speed_of_car;
            car_sessions[0].boost_speed_per_second = car_Inf.boost_speed_per_second;
            car_sessions[0].breaking_facilities = car_Inf.breaking_facilities;
            car_sessions[0].Aspeed(car_sessions, 0, car_Inf);
            car_sessions[0].Time_of_razgon_to_current_speed(car_sessions, 0, roads);//время ускорения и после ускорения
            car_sessions[0].S_of_razgon_on_current_speed(car_sessions, 0);//расстояние которое пройдет во время ускорения
            /*cars[0].Way(cars, roads);//считает сколько времни надо ехать чтоб преодолеть нужное расстояние*/
        }
        public void Aspeed(List<Car_Sessions> car_sessions, int i, Car_Inf car) //ускорение вс еккунду принимает правильное значение ,переделывая значение 11,2
        {
            car_sessions[i].boost_speed_per_second = (100 * 1000) / (60 * 60) / car.boost_speed_per_second;
        }

        public void Time_of_razgon_to_current_speed(List<Car_Sessions> car_sessions, int iter_of_car, List<Road_Inf> roads)
        {
            car_sessions[iter_of_car].current_speed = (car_sessions[iter_of_car].new_limit_of_speed * 1000) / (60 * 60);// м/с
            if (iter_of_car - 1 >= 0)
            {
                car_sessions[iter_of_car].time_of_boost = (car_sessions[iter_of_car].current_speed - car_sessions[iter_of_car - 1].new_limit_of_speed) / car_sessions[0].boost_speed_per_second;
            }
            else
            {
                car_sessions[iter_of_car].time_of_boost = car_sessions[iter_of_car].current_speed / car_sessions[0].boost_speed_per_second;
            }//время разгона
            car_sessions[iter_of_car].time_after_boost = 0;//время после разгона обнуляем что не наткнуться на мусор

        }

        public void S_of_razgon_on_current_speed(List<Car_Sessions> car_sessions, int iter_of_car)//путь при ускорении
        {
            car_sessions[iter_of_car].s_of_boost =
            (car_sessions[iter_of_car].boost_speed_per_second * Math.Pow(car_sessions[iter_of_car].time_of_boost, 2)) / 2;
        }

        public void Break_Car(List<Car_Sessions> car_sessions, int i)
        {
            car_sessions[i].Full_s = 0;
            car_sessions[i].S_after_Boost = 0;
            car_sessions[i].S_of_Boost = 0;
            car_sessions[i].Time_after_Boost = 0;
            car_sessions[i].Time_of_Boost = 0;
            car_sessions[i].Current_speed = (car_sessions[i].New_limit_of_speed * 1000) / (60 * 60);
            car_sessions[i].speed_between_boost_and_breaking = (car_sessions[i - 1].new_limit_of_speed - car_sessions[i].new_limit_of_speed) * -1;
        }

        public void Save_Session(List<Car_Sessions> car_Sessions) 
        {
            //доделать
            SoborniyContext context = new SoborniyContext();
            Session session = new Session();
            for (int i = 0; i < car_Sessions.Count; i++)
            {
                SessionStatistic sessionStatistic = new SessionStatistic();
                sessionStatistic.CarSpeed= Convert.ToInt32("");
                context.SessionStatistics.Add(sessionStatistic);
                context.SaveChanges();
            }
        }
        public double Time_of_Boost
        {
            get
            {
                return time_of_boost;
            }
            set
            {
                time_of_boost = value;
            }
        }
        public double Time_after_Boost
        {
            get
            {
                return time_after_boost;
            }
            set
            {
                time_after_boost = value;
            }
        }

        public double S_of_Boost
        {
            get
            {
                return s_of_boost;
            }
            set
            {
                s_of_boost = value;
            }
        }

        public double S_after_Boost
        {
            get
            {
                return s_after_boost;
            }
            set
            {
                s_after_boost = value;
            }
        }

        public double Full_s
        {
            get
            {
                return full_s;
            }
            set
            {
                full_s = value;
            }
        }

        public double Boost_speed_per_second
        {
            get
            {
                return boost_speed_per_second;
            }
            set
            {
                boost_speed_per_second = value;
            }
        }
        public double Current_speed
        {
            get
            {
                return current_speed;
            }
            set
            {
                current_speed = value;
            }
        }

        public double Max_speed_of_car
        {
            get
            {
                return max_speed_of_car;
            }
            set
            {
                max_speed_of_car = value;
            }
        }
        public double New_limit_of_speed
        {
            get
            {
                return new_limit_of_speed;
            }
            set
            {
                new_limit_of_speed = value;
            }
        }
        public double Breaking_facilities
        {
            get
            {
                return breaking_facilities;
            }
            set
            {
                breaking_facilities = value;
            }
        }

    }
}
