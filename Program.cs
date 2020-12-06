using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoborniyProject.database.Context;
using SoborniyProject.database.Models;
using SoborniyProject.src.interfaces;


namespace SoborniyProject
{
    public class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            Store store = new Store(); 

            Application.Run(new Main(store));

        }
    }
}
