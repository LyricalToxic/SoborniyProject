using System;
using System.Windows.Forms;
using SoborniyProject.src.interfaces;


namespace SoborniyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LOL lol = new LOL();
            lol.ShowDialog();
        }
    }
}
