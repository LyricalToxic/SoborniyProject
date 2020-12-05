using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoborniyProject.database.Models;
using SoborniyProject.database.Context;
using System.Threading;
using SoborniyProject.src.algorithms.CarAndRoads;

namespace SoborniyProject.src.interfaces
{
    public partial class Main : Form
    {

        public AnimationTrafficLight store;
        private LightTraffic lightTraffic = new LightTraffic();
        private int countLightTraffic;


        public Main(AnimationTrafficLight store)
        {
            this.store = store;
            InitializeComponent();
            initializeData();
        }

       

        private async void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                
                    car.Location = new Point(i, 269);
                    await Task.Delay(200);
                
                
            }
        }

        private void initializeData()
        {
            var pictures = this.Controls.OfType<PictureBox>().Select(p => p);
            foreach (PictureBox control in pictures)
            {
                if (control.Name.Contains("color"))
                {
                    //control.Image = Image.FromFile($"D:/Work/Универ/SoborniyProject/src/assets/img/{currentColor}.png");
                }

            }
        }


        private void addNewTraffic_Click(object sender, EventArgs e)
        {

            lightTraffic.Id = countLightTraffic;
            lightTraffic.StartColor = convertToInt(currentColor);
            if (lightTraffic.StartColor == 2)
            {
                lightTraffic.NextColor = convertToInt(nextColor);
            }
            lightTraffic.Status = convertToInt(currentTime);
            lightTraffic.PreviousDistance = convertToInt(distance);
            lightTraffic.RedLightDurationSec = convertToInt(redColor);
            store.addNewLightTraffic(lightTraffic);



            currentLightTraffic.Items.Add($"{countLightTraffic} світлофор");
            currentLightTraffic.Text = currentLightTraffic.Items[0].ToString();
        }


    
        private void tabPage2_Click(object sender, EventArgs e)
        {
            lightTraffic.SessionId = store.session.Id;
            countLightTraffic = store.countLightTraffic;
        }



        private int convertToInt(TextBox text)
        {
            return Convert.ToInt32(text.Text);
        }

    }
}
