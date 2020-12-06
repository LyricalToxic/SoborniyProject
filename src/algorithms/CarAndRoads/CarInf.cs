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

        public void DB_Inf(CarInf car ,long key)
        {

            
            using (SoborniyContext db = new SoborniyContext()) 
            {

                //var inf_car = from p in db.Car where p.MaxSpeed == 50 select p;

                Car car2 = new Car
                {
                    Id = 0,
                    Name = "DAWD",
                    MaxSpeed = 50,
                    Acceleration = 11,
                    Deceleration = 8
                };

                db.Car.Add(car2);
                db.SaveChanges();

                foreach (var item in db.Car)
                {
                    int a = Convert.ToInt32(item.Acceleration);
                    int b = Convert.ToInt32(item.Deceleration);
                }


                //car.Acceleration = inf_car.ToArray()[0].Acceleration;
                //car.CarMaxSpeed = inf_car.ToArray()[0].MaxSpeed;
                //car.Decelaration = inf_car.ToArray()[0].Deceleration;


                   
            }
        }

    }
}
