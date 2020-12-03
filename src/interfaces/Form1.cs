using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoborniyProject.database.Context;
using SoborniyProject.database.Models;
using SoborniyProject.src.algorithms.Algorithms;
using SoborniyProject.src.algorithms.CarAndRoads;

namespace SoborniyProject.src.interfaces
{
    public partial class Form1 : Form
    {
        public SoborniyContext context = new SoborniyContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Road_Inf> roads = new List<Road_Inf>();
            List<Car_Sessions> car_sessions = new List<Car_Sessions>();
            car_sessions.Add(new Car_Sessions() { });
            roads.Add(new Road_Inf() { });
            roads[0].Inf_from_BD(roads);
            car_sessions[0].start_convert_data(car_sessions, roads);
            Boost_Algorithm algoritm = new Boost_Algorithm();
            algoritm.Boost_Way(car_sessions, roads, algoritm);







            Session session = new Session();
            var firstsession { }= context.Session
                .Select(p: Session => new { p.id ,p.Key}).SingleorDefault(p)
        }
    }
}
