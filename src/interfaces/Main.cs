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

namespace SoborniyProject.src.interfaces
{
    public partial class Main : Form
    {

       

        public SoborniyContext context = new SoborniyContext();
        private string currentColor = "red";

        public Main()
        {
            InitializeComponent();
            initializeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var options = new Options();
            Hide();
            options.Show();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //Session session = new Session();
            //session.Key = textBox1.Text;
            //context.Session.Add(session);
            //context.SaveChanges();

            for (int i = 0; i < 200; i++)
            {
                if(currentColor == "green")
                {
                    car.Location = new Point(i, 245);
                    await Task.Delay(10);
                }
                
            }

        }
        private void initializeData()
        {
            var pictures = this.Controls.OfType<PictureBox>().Select(p => p);
            foreach (PictureBox control in pictures)
            {
                if (control.Name.Contains("color"))
                {
                    control.Image = Image.FromFile($"D:/Work/Универ/SoborniyProject/src/assets/img/{currentColor}.png");
                }

            }
        }
    }
}
