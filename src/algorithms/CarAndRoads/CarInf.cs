using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SoborniyProject.database.Context;
using SoborniyProject.database.Models;

namespace SoborniyProject.src.algorithms.CarAndRoads
{
    public class CarInf
    {
        public double CarMaxSpeed;

        public double Acceleration;

        public double Decelaration;

        public void DB_Inf(CarInf car ,int key)
        {
            using (SoborniyContext db = new SoborniyContext()) 
            {
                var inf_car = db.Car.FirstOrDefault(p => p.Id == key);
                car.Acceleration = inf_car.Acceleration;
                if (inf_car.MaxSpeed < 70)
                {
                    car.CarMaxSpeed = 70;
                }
                else 
                {
                    car.CarMaxSpeed = inf_car.MaxSpeed;
                }
                car.Decelaration = inf_car.Deceleration;
                   
            }
        }

    }
}
