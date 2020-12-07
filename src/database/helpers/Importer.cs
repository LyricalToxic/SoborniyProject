using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.helpers
{
    public class Importer
    {
        public static List<LightTraffic> ImportLightTraffics(string path)
        {
            List<LightTraffic> lightTraffics = ReadFromCsv(path);
            return lightTraffics;
        }
        private static dynamic ReadFromCsv(string csvPath)
        {
            List<LightTraffic> lightTraffics = new List<LightTraffic>();
            using (var reader = new StreamReader($"D:/Work/Универ/SoborniyProject/src/data/{csvPath}.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<LightTrafficsMap>();
                lightTraffics = csv.GetRecords<LightTraffic>().ToList();
                
                
            }
            return lightTraffics; 
        }
    }
}
