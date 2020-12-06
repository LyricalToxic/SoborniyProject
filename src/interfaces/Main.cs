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
        private const int Y_LIGHT_TRAFFIC = 50;
        private float X_LIGHT_TRAFFIC = 0;


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


       

        private void addNewTraffic_Click(object sender, EventArgs e)
        {

            LightTraffic lightTraffic = new LightTraffic();
            lightTraffic.SessionId = store.session.Id;
            lightTraffic.PositionId = store.countLightTraffic;
            lightTraffic.StartColor = (short)convertToInt(currentColor);

            if (lightTraffic.StartColor == 2)
            {
                lightTraffic.NextColor = (short)convertToInt(nextColor);
            }

            lightTraffic.Status = (short)convertToInt(currentTime);
            lightTraffic.PreviousDistance = convertToInt(distance);
            lightTraffic.RedLightDuration = convertToInt(redColor);
            lightTraffic.YellowLightDuration = convertToInt(yellowColor);
            lightTraffic.GreenLightDuration = convertToInt(greenColor);
            store.addNewLightTraffic(lightTraffic);

            currentLightTraffic.Items.Add($"{lightTraffic.Id} світлофор");
            currentLightTraffic.Text = currentLightTraffic.Items[0].ToString();

            string color = "";
            switch (lightTraffic.StartColor)
            {
                case 1:
                    color = "RedLight";
                    break;
                case 2:
                    color = "GreenLight";
                    break;
                case 3:
                    color = "YellowLight";
                    break;
                default:
                    color = "RedLight";
                    break;
            }
            X_LIGHT_TRAFFIC += lightTraffic.PreviousDistance;
            createILightTraffic(color);
           
        }

        private void createILightTraffic(string color)
        {
            try
            {
                PictureBox picture = new PictureBox
                {
                    Name = $"lightTraffic{store.countLightTraffic}",
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Location = new Point(Convert.ToInt32(X_LIGHT_TRAFFIC), Y_LIGHT_TRAFFIC),
                    Image = Image.FromFile($"D:/Work/Универ/SoborniyProject/src/assets/img/{color}.png"),
                    Size = new Size(33, 106),
                };
                tabPage1.Controls.Add(picture);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }










        private void tabControl1_Click(object sender, EventArgs e)
        {
            car.SessionId = store.session.Id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            car.Name ="DAWD" ; //nameCar.Text
            car.MaxSpeed = 100;//convertToInt(speed)
            car.Acceleration = 11 ;//convertToInt(acceleration)
            car.Deceleration = 8;//convertToInt(deceleration)
            store.addNewCar(car);
            carModel.Visible = true;
          
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
            int indexSpeed = 0;
            foreach (var item in store.context.LightTraffic.ToArray())
            {
                distance += item.PreviousDistance;
                if (indexSpeed == store.countLightTraffic)
                {
                    break;
                }
                for (; i < distance; i++)
                {
                    carModel.Location = new Point(i - carModel.Width, carModel.Location.Y);
                    await Task.Delay(Convert.ToInt32(item.PreviousDistance / store.Speed[indexSpeed]));
                }
                indexSpeed++;
            }

            distance = Width;

            for (; i < distance; i++)
            {
                carModel.Location = new Point(i - carModel.Width, carModel.Location.Y);
                await Task.Delay(Convert.ToInt32(distance / store.Speed[0]));
            }
            
        }

        
    }
}
