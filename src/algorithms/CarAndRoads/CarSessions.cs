using SoborniyProject.database.Models;
using SoborniyProject.database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.algorithms.CarAndRoads
{
    public class CarSessions
    {
        public double CarMaxSpeed;

        public double SpeedLimit;

        public double AccelerationPerSecond;

        public double BreakingAbility;

        public double BreakingTime;

        public double SpeedBetweenBoostAndBreaking;

        public double TimeAfterBoost;

        public double BoostTime;

        public double BoostDistance;

        public double DistanceAfterBoost;

        public double BreakinDistance;

        public double FullDistance;

        public double SiteTime;

        public double FullSessionTime;

        public double CurrentSpeed;

        public int SessionLose;

        public CarInf car_inf;

        public SoborniyContext Context;

        public void StartConvertData(List<CarSessions> car_sessions, List<RoadInf> roads,string key)//вызывает другие методы
        {
            CarInf car_Inf = new CarInf();
            car_Inf.DB_Inf(car_Inf,key,car_sessions);
            car_sessions[0].CarMaxSpeed = car_Inf.CarMaxSpeed;
            car_sessions[0].SpeedLimit = car_Inf.CarMaxSpeed;
            car_sessions[0].AccelerationPerSecond = car_Inf.Acceleration;
            car_sessions[0].BreakingAbility = car_Inf.Decelaration;
            car_sessions[0].RecountBoostSpeed(car_sessions, 0, car_Inf);
            car_sessions[0].CountBoosTimeToCurrentSpeed(car_sessions, 0, roads);//время ускорения и после ускорения
            car_sessions[0].CountBoostDistanceOnCurrentSpeed(car_sessions, 0);//расстояние которое пройдет во время ускорения
        }
        public void RecountBoostSpeed(List<CarSessions> car_sessions, int tter, CarInf car) //ускорение вс еккунду принимает правильное значение ,переделывая значение 11,2
        {
            car_sessions[tter].AccelerationPerSecond = (100 * 1000) / (60 * 60) / car.Acceleration;
        }

        public void CountBoosTimeToCurrentSpeed(List<CarSessions> car_sessions, int iter, List<RoadInf> roads)
        {
            car_sessions[iter].CurrentSpeed = (car_sessions[iter].SpeedLimit * 1000) / (60 * 60);// м/с
            if (iter - 1 >= 0)
            {
                car_sessions[iter].BoostTime = (car_sessions[iter].CurrentSpeed - car_sessions[iter - 1].SpeedLimit) / car_sessions[0].AccelerationPerSecond;
            }
            else
            {
                car_sessions[iter].BoostTime = car_sessions[iter].CurrentSpeed / car_sessions[0].AccelerationPerSecond;
            }//время разгона
            car_sessions[iter].TimeAfterBoost = 0;//время после разгона обнуляем что не наткнуться на мусор

        }

        public void CountBoostDistanceOnCurrentSpeed(List<CarSessions> car_sessions, int iter)//путь при ускорении
        {
            car_sessions[iter].BoostDistance =
            (car_sessions[iter].AccelerationPerSecond * Math.Pow(car_sessions[iter].BoostTime, 2)) / 2;
        }

        public void SaveSessions(List<CarSessions> car_sessions,string key) 
        {
            var session = from p in car_sessions[0].Context.Session where p.Key == key select p;
            foreach (var item in session)
            {
                item.Status = car_sessions[0].SessionLose;
                item.TotalTime = Convert.ToInt32(Math.Round(car_sessions[0].FullSessionTime));
            }

            for (int i = 0; i < car_sessions.Count; i++)
            {
                SessionStatistic sessionStatistic = new SessionStatistic();
                sessionStatistic.PositionId = i+1;
                sessionStatistic.AccelerationDistance = (short)car_sessions[i].BoostDistance;
                sessionStatistic.DecelerationDistance = (short)car_sessions[i].BreakinDistance;
                sessionStatistic.AccelerationTime = (short)car_sessions[i].BoostTime;
                sessionStatistic.DecelerationTime = (short)car_sessions[i].BreakingTime;
                sessionStatistic.DistanceBetweenLightTraffic = (short)car_sessions[i].FullDistance;
                sessionStatistic.CarSpeed = (short)car_sessions[i].SpeedLimit;
                sessionStatistic.SessionTime = (short)car_sessions[i].FullSessionTime;
                car_sessions[i].SiteTime = car_sessions[i].BoostTime + car_sessions[i].TimeAfterBoost;
                sessionStatistic.TimeBetweenLightTraffic = (short)car_sessions[i].SiteTime;
                car_sessions[0].Context.SessionStatistics.Add(sessionStatistic);
            }
            car_sessions[0].Context.SaveChanges();
        }

        public void DetectImpossibleValuesInSession(List<CarSessions> car_sessions,string key,List<RoadInf> roads) 
        {
            for (int iter = 0; iter < car_sessions.Count; iter++)
            {
                if (car_sessions[iter].FullSessionTime < 0 || car_sessions[iter].FullDistance > roads[iter].DistaceRoadSite 
                    || car_sessions[iter].SpeedLimit<5 ) 
                {
                  
                    car_sessions[0].SessionLose = 1;
                }
            }
            car_sessions[0].SaveSessions(car_sessions, key);
        }
    }

}

