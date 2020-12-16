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
        public int globalAsync = 0;
        private Car car = new Car();
        private const int Y_LIGHT_TRAFFIC = 50;
        private float X_LIGHT_TRAFFIC = 0;
        private const string PATH_TO_IMAGE = "D:/Work/Универ/SoborniyProject/src/assets/img/";
        private List<PictureBox> lightTraffics = new List<PictureBox>();
        private List<string> allColors = new List<string>();
        private bool stoped = false;


        public Main(Store store)
        {
            this.store = store;
            InitializeComponent();
            initializeData();
            information.Text = "На головній формі ви побачите моделювання руху авто і кнопки, якими ви керуєте програмою. Кнопка «Зберегти світлофори» зберігає світлофори і дані про них в файли формату csv. Для запуску програми потрібно перейти на вкладку «Car» і додати автомобіль і на вкладку «Light Traffic», щоб додати світлофори, якщо не буде цих об'єктів, то алгоритм немає від працює. Після того як всі дані введені, ви натискайте на кнопку Запуск, щоб побачити результат алгоритму. Остання кнопка потрібна для зупинки моделювання.";
        }





        private void initializeData()
        {
            car.SessionId = store.session.Id;
            var sesions = from p in store.context.Session select p;
            foreach (var item in sesions)
            {
                CBKeySessions.Items.Add(item.Key);
            }
            CBKeySessions.Text = CBKeySessions.Items[0].ToString();
        }




        private void BAddNewTraffic_Click(object sender, EventArgs e)
        {

            store.countLightTraffic++;
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


            X_LIGHT_TRAFFIC += lightTraffic.PreviousDistance;
            createILightTraffic(checkColor(lightTraffic.StartColor));

        }

        private void createILightTraffic(string color)
        {
            try
            {
                PictureBox picture = new PictureBox
                {
                    Name = $"lightTraffic{color}{store.countLightTraffic}",
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Location = new Point(Convert.ToInt32(X_LIGHT_TRAFFIC), Y_LIGHT_TRAFFIC),
                    Image = Image.FromFile($"{PATH_TO_IMAGE}{color}.png"),
                    Size = new Size(33, 106),
                };
                tabPage1.Controls.Add(picture);
                tabPage1.Refresh();
                lightTraffics.Add(picture);
                allColors.Add(color);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        

        private int convertToInt(TextBox text)
        {
            return Convert.ToInt32(text.Text);
        }

        private string checkColor(int light)
        {
            string color = "";
            switch (light)
            {
                case 1:
                    color = "RedLight";
                    break;
                case 3:
                    color = "GreenLight";
                    break;
                case 2:
                    color = "YellowLight";
                    break;
                default:
                    color = "RedLight";
                    break;
            }
            return color;
        }

        

      

        

    
        private void spawnSessions(string key)
        {
            var sesions = from p in store.context.SessionStatistics where p.Session.Key == key select p;
            foreach (var item in sesions)
            {
                ListViewItem listItem = new ListViewItem(item.Id.ToString());
                listItem.SubItems.Add(item.SessionId.ToString());
                listItem.SubItems.Add(item.PositionId.ToString());
                listItem.SubItems.Add(item.AccelerationTime.ToString());
                listItem.SubItems.Add(item.AccelerationDistance.ToString());
                listItem.SubItems.Add(item.DecelerationTime.ToString());
                listItem.SubItems.Add(item.DecelerationDistance.ToString());
                listItem.SubItems.Add(item.LightTrafficStatus.ToString());
                listItem.SubItems.Add(item.DistanceBetweenLightTraffic.ToString());
                listItem.SubItems.Add(item.TimeBetweenLightTraffic.ToString());
                listItem.SubItems.Add(item.CarSpeed.ToString());
                listView1.Items.Add(listItem);

            }
        }

        private async void BStartAlgorithm_Click(object sender, EventArgs e)
        {
            
            if (globalAsync == 0)
            {
                stoped = false;
                globalAsync = 1;
                try
                {
                    if (string.IsNullOrEmpty(car.Name))
                    {
                        throw new Exception("Please add car");
                    }
                    
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
                            if (stoped)
                            {
                                carModel.Location = new Point(0, carModel.Location.Y);
                                break;
                            }
                            await Task.Delay(Convert.ToInt32(item.PreviousDistance / store.Speed[indexSpeed]));
                            
                            if (allColors[indexSpeed] == "RedLight" && i == distance - 200)
                            {

                                item.NextColor = 3;
                                lightTraffics[indexSpeed].Image = Image.FromFile($"{PATH_TO_IMAGE}YellowLight.png");
                                allColors[indexSpeed] = "YellowLight";
                                lightTraffics[indexSpeed].Refresh();
                            }
                            else if (allColors[indexSpeed] == "YellowLight" && i == distance - 100)
                            {
                                allColors[indexSpeed] = "GreenLight";
                                lightTraffics[indexSpeed].Image = Image.FromFile($"{PATH_TO_IMAGE}{"GreenLight"}.png");
                                lightTraffics[indexSpeed].Refresh();
                            }
                            else if (indexSpeed != 0 && allColors[indexSpeed - 1] == "GreenLight" && i > distance - item.PreviousDistance + 100)
                            {

                                allColors[indexSpeed - 1] = "";
                                lightTraffics[indexSpeed - 1].Image = Image.FromFile($"{PATH_TO_IMAGE}{"RedLight"}.png");
                                lightTraffics[indexSpeed - 1].Refresh();

                            }

                        }
                        indexSpeed++;

                    }
                    distance = Size.Width;


                    for (; i < distance; i++)
                    {
                        carModel.Location = new Point(i - carModel.Width, carModel.Location.Y);
                        if (stoped)
                        {
                            carModel.Location = new Point(0, carModel.Location.Y);
                            break;
                        }
                        await Task.Delay(Convert.ToInt32(distance / store.Speed[0]));
                        if (allColors[indexSpeed - 1] == "GreenLight" && i > distance - 300)
                        {
                            allColors[indexSpeed - 1] = "";
                            lightTraffics[indexSpeed - 1].Image = Image.FromFile($"{PATH_TO_IMAGE}{"RedLight"}.png");
                            lightTraffics[indexSpeed - 1].Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                
                globalAsync = 0;

            }
            else
            {
                MessageBox.Show("Please wait to end the algorithms");
            }
        }

        private void BSaveSessions_Click(object sender, EventArgs e)
        {
            store.exportLightTraffic();
        }

      

        private void BAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                
                car.Name = nameCar.Text;
                car.MaxSpeed = convertToInt(speed);
                car.Acceleration = convertToInt(acceleration);
                car.Deceleration = convertToInt(deceleration);
                store.addNewCar(car);
                carModel.Visible = true;
                store.startProgram();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

       
        private void BOpenFileLightTraffic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"D:\Work\Универ\SoborniyProject\src\data";
            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                store.importLightTraffic(open.FileName);
            }


            lightTraffics.Clear();

            X_LIGHT_TRAFFIC = 0;
            foreach (var item in store.lightTraffics)
            {
                X_LIGHT_TRAFFIC += item.PreviousDistance;

                createILightTraffic(checkColor(item.StartColor));

                currentLightTraffic.Items.Add($"{item.PositionId} світлофор");
            }
            currentLightTraffic.Text = currentLightTraffic.Items[0].ToString();
        }

        

        private void BStopAlgorithm_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            
            foreach (var p in lightTraffics)
            {
                p.Image = Image.FromFile($"{PATH_TO_IMAGE}{checkColor(store.lightTraffics[i].StartColor)}.png");
                p.Refresh();
                allColors[i] = checkColor(store.lightTraffics[i].StartColor);
                i++;
              
            }
            stoped = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            information.Text = "На головній формі ви побачите моделювання руху авто і кнопки, якими ви керуєте програмою. Кнопка «Зберегти світлофори» зберігає світлофори і дані про них в файли формату csv. Для запуску програми потрібно перейти на вкладку «Car» і додати автомобіль і на вкладку «Light Traffic», щоб додати світлофори, якщо не буде цих об'єктів, то алгоритм немає від працює. Після того як всі дані введені, ви натискайте на кнопку Запуск, щоб побачити результат алгоритму. Остання кнопка потрібна для зупинки моделювання.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            information.Text = "На сторінці світлофорів можна додати світлофор або змінити його. При натискані на кнопку відкрити файл на робочому столі з'являється діологове вікно файлів, де ви відкриваєте файл зі збереженими раніше світлофорами.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            information.Text = "На сторінці автомобіля можна додати авто. Після введення даних авто натисніть кнопку додати, тоді ваш автомобіль додається в базу. Він потрібен для роботи програми";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            information.Text = "На сторінці статистика ви побачите інформацію про сесію, яку ви вибираєте завдяки ComboBox"; 
        }

        private void currentLightTraffic_SelectedIndexChanged(object sender, EventArgs e)
        {

            var index = Convert.ToInt32(currentLightTraffic.Text[0])-49 ;

            currentColor.Text = store.session.LightTraffics[index].StartColor.ToString();
            distance.Text = store.session.LightTraffics[index].PreviousDistance.ToString();
            currentTime.Text = store.session.LightTraffics[index].StartColor.ToString();
            nextColor.Text = store.session.LightTraffics[index].NextColor.ToString();
            redColor.Text = store.session.LightTraffics[index].RedLightDuration.ToString();
            yellowColor.Text = store.session.LightTraffics[index].YellowLightDuration.ToString();
            greenColor.Text = store.session.LightTraffics[index].GreenLightDuration.ToString();
        }

        private void CBKeySessions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            spawnSessions(CBKeySessions.Text);
        }
    }
          
}

            

            
      

       
            


        
    