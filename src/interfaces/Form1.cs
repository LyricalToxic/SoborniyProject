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
            int key=0;
            List<RoadInf> roads = new List<RoadInf>();
            List<CarSessions> car_sessions = new List<CarSessions>();
            car_sessions.Add(new CarSessions() { });
            roads.Add(new RoadInf() { });
            roads[0].Inf_from_BD(roads,key);
            car_sessions[0].StartConvertData(car_sessions, roads,key);
            BoostAlgorithm algoritm = new BoostAlgorithm();
            algoritm.BoostWay(car_sessions, roads, algoritm,key);
            car_sessions



        }
    }
}
