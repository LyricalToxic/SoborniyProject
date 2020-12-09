using SoborniyProject.database.Context;
using SoborniyProject.database.helpers;
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
        public List<int> Speed = new List<int>();
        public SoborniyContext context = new SoborniyContext();
        public Session session = new Session();
        public List<LightTraffic> lightTraffics = new List<LightTraffic>();
        public int countLightTraffic = 0;
        public Store()
        {
            session.Key = getHashKey();
            context.Session.Add(session);
            context.SaveChanges();
        }

        public void startProgram()
        {

            List<RoadInf> roads = new List<RoadInf>();
            List<CarSessions> car_sessions = new List<CarSessions>();
            car_sessions.Add(new CarSessions());
            roads.Add(new RoadInf());
            roads[0].Context = context;
            car_sessions[0].Context = context;
            roads[0].Inf_from_BD(roads, session.Key);
            car_sessions[0].StartConvertData(car_sessions, roads, session.Key);
            BoostAlgorithm algoritm = new BoostAlgorithm();
            algoritm.BoostWay(car_sessions, roads, algoritm, session.Key);
            for (int i = 0; i < car_sessions.Count; i++)
            {
                Speed.Add(Convert.ToInt32(Math.Round(car_sessions[i].SpeedLimit)));//Math.Round(car_sessions[i].BoostTime + car_sessions[i].TimeAfterBoost)
            }
            countLightTraffic = car_sessions.Count;


        }


        public void addNewLightTraffic(LightTraffic lightTraffic)
        {

            context.LightTraffic.Add(lightTraffic);
            lightTraffics.Add(lightTraffic);
            context.SaveChanges();

        }

        public void addNewCar(Car car)
        {
            context.Car.Add(car);
            context.SaveChanges();
        }


        public void importLightTraffic(string path)
        {
            lightTraffics.Clear();

            lightTraffics = Importer.ImportLightTraffics(path);

            foreach (var item in lightTraffics)
            {
                item.SessionId = session.Id;
                context.LightTraffic.Add(item);
            }
            context.SaveChanges();
            countLightTraffic = lightTraffics.Count;

        }

        public void exportLightTraffic()
        {
            Exporter exporter = new Exporter(context);
            exporter.Run(session.Key);

        }

        private string getHashKey()
        {
            return session.Id.GetHashCode().ToString();
        }
    }
}
