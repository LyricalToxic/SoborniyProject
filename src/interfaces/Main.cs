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

        public Store store;
       
        private Car car = new Car();        
        private int countLightTraffic;


        public Main(Store store)
        {
            this.store = store;
            InitializeComponent();
            initializeData();
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


        private void tabPage2_Click(object sender, EventArgs e)
        {
            
            countLightTraffic = store.countLightTraffic;
        }

        private void addNewTraffic_Click(object sender, EventArgs e)
        {

            LightTraffic lightTraffic = new LightTraffic();
            lightTraffic.SessionId = store.session.Id;
            lightTraffic.PositionId = countLightTraffic;
            lightTraffic.StartColor = 1;//convertToInt(currentColor)

            if (lightTraffic.StartColor == 2)
            {
                lightTraffic.NextColor = 1;//convertToInt(nextColor)
            }

            lightTraffic.Status = 20;// convertToInt(currentTime)
            lightTraffic.PreviousDistance = 200;//convertToInt(distance)
            lightTraffic.RedLightDuration = 30;//convertToInt(redColor)
            lightTraffic.YellowLightDuration = 20;// convertToInt(yellowColor)
            lightTraffic.GreenLightDuration = 30;// convertToInt(greenColor)
            store.addNewLightTraffic(lightTraffic);
            countLightTraffic++;


            currentLightTraffic.Items.Add($"{countLightTraffic} світлофор");
            currentLightTraffic.Text = currentLightTraffic.Items[0].ToString();
        }


        









        private void tabControl1_Click(object sender, EventArgs e)
        {
            car.SessionId = store.session.Id;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            
            car.Name ="DAWD" ; //nameCar.Text
            car.MaxSpeed = 50;//convertToInt(speed)
            car.Acceleration = 11 ;//convertToInt(acceleration)
            car.Deceleration = 8;//convertToInt(deceleration)
            store.addNewCar(car);
          
        }


        private int convertToInt(TextBox text)
        {
            return Convert.ToInt32(text.Text);
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            
            store.startProgram();
            float distance = 0;
            int i = 0;
            int indexTime = 0;
            foreach (var item in store.context.LightTraffic.ToArray())
            {
                distance += item.PreviousDistance;
                for (; i < distance; i++)
                {
                        carModel.Location = new Point(i, 233);
                        await Task.Delay(Convert.ToInt32(item.PreviousDistance / store.FullTime[indexTime]));
                }
                indexTime++;
                

            }





           

                
             
              


            
        }
    }
}
