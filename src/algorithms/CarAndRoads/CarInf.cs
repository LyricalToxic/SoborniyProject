using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SoborniyProject.database.Context;
using SoborniyProject.database.Models;
using System.Collections.Generic;

namespace SoborniyProject.src.algorithms.CarAndRoads
{
    public class CarInf
    {
        public double CarMaxSpeed;

        public double Acceleration;

        public double Decelaration;

        public SoborniyContext Context;

        public void DB_Inf(CarInf car ,long key, List<CarSessions> car_sessions)
        {
            car.Context = car_sessions[0].Context;
            var info = from p in car.Context.Car where p.Id == key select p;
            car.CarMaxSpeed = info.ToArray()[0].MaxSpeed;
            car.Acceleration = info.ToArray()[0].Acceleration;
            car.Decelaration = info.ToArray()[0].Deceleration;
        }

    }
}
