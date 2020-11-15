using DotNetEnv;
using System;
using System.IO;


namespace SoborniyProject
{
    
    public readonly struct Settings
    {    
        public static void Load()
        {
            Env.Load(envFile);
            MYSQL_HOST = Env.GetString("MYSQL_HOST", "localhost");
            MYSQL_PORT = Env.GetInt("MYSQL_PORT", 3306);
            MYSQL_USER = Env.GetString("MYSQL_USER", "root");
            MYSQL_PASSWORD = Env.GetString("MYSQL_PASSWORD", "1234");
            MYSQL_DATABASE = Env.GetString("MYSQL_DATABASE", "soborniy");
        }

        public static string MYSQL_HOST { get; set; }
        public static int MYSQL_PORT { get; set; }
        public static string MYSQL_USER { get; set; }
        public static string MYSQL_PASSWORD { get; set; }
        public static string MYSQL_DATABASE { get; set; }

         public  enum LightTrafficColorEnum
        {
            Red = 1,
            Yellow = 2,
            Green = 3
        }
        public static string envFile = "../../.env";
    }
}
