using SoborniyProject.database.Context;
using SoborniyProject.database.Models;
using SoborniyProject.src.algorithms.Algorithms;
using SoborniyProject.src.algorithms.CarAndRoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoborniyProject.src.interfaces
{
    public class Store
    {
        public List<int> FullTime = new List<int>();
        public SoborniyContext context = new SoborniyContext();
        public Session session = new Session();

        public int countLightTraffic = 0;
        public Store()
        {
            session.Id = 1;
            session.Key = "1";
            context.Session.Add(session);
            
            context.SaveChanges();
        }

        public void startProgram()
        {
            string key = "jjjjj";
   
            List<RoadInf> roads = new List<RoadInf>();
            List<CarSessions> car_sessions = new List<CarSessions>();
            car_sessions.Add(new CarSessions());
            roads.Add(new RoadInf());
            roads[0].Context = context;
            car_sessions[0].Context = context;
            roads[0].Inf_from_BD(roads, key);
            car_sessions[0].StartConvertData(car_sessions, roads, key);
            BoostAlgorithm algoritm = new BoostAlgorithm();
            algoritm.BoostWay(car_sessions, roads, algoritm, key);

            for (int i = 0; i < car_sessions.Count; i++)
            {
                FullTime.Add(Convert.ToInt32(Math.Round(car_sessions[i].SiteTime)));
            }
        }


        public void addNewLightTraffic(LightTraffic lightTraffic)
        {
            context.LightTraffic.Add(lightTraffic);
            context.SaveChanges();
            countLightTraffic++;
        }

        public void addNewCar(Car car)
        {
            context.Car.Add(car);
            context.SaveChanges();
        }
    }
}
