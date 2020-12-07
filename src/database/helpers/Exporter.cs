using System;
using System.Linq;
using SoborniyProject.database.Context;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;


namespace SoborniyProject.database.helpers
{
    public class Exporter
    {
        private SoborniyContext Context;
        public Exporter(SoborniyContext context)
        {
            Context = context;
        }
        public void Run(string sessionKey, string directory="")
        {
            string csvPath = ResolvePath(directory, sessionKey, "csv");
            string jsonPath = ResolvePath(directory, sessionKey, "json");
            WriteToCsv(csvPath, sessionKey);
            WriteToJson(jsonPath, sessionKey);
        }

        protected string ResolvePath(string directory, string sessionKey, string extension)
        {
            string resolvedPath;
            string resolvedPathDir;
            string resolvedName = String.Format("{0}.{1}", sessionKey, extension);
            if (Directory.Exists(directory))
            {
                resolvedPath = Path.Combine(directory, resolvedName);
            }
            else
            {
                resolvedPathDir = Path.Combine(Settings.ROOT_PATH,  "src", "exports",sessionKey);
                Directory.CreateDirectory(resolvedPathDir);
                resolvedPath = Path.Combine(resolvedPathDir, resolvedName);
            }

            return resolvedPath;
        }
        private  void WriteToCsv(string csvPath, string sessionKey)
        {
            var statistics = GetResultStatistics(sessionKey);
            using (var writer = new StreamWriter(csvPath)) 
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(statistics);
            }
        }

        private dynamic GetResultStatistics(string sessionKey)
        {
            var lightTrafficStatistics = Context.SessionStatistics.Join(
                Context.Session.Where(o => o.Key == sessionKey),
                e => e.SessionId,
                o => o.Id,
                (e, o) => new
                {
                    sessionId = o.Id,
                    positionId = e.PositionId,
                    AccelerationDistance = e.AccelerationDistance,
                    AccelerationTime = e.AccelerationTime,
                    DecelerationDistance = e.DecelerationDistance,
                    DecelerationTime = e.DecelerationTime,
                    lightTrafficStatus = e.LightTrafficStatus,
                    TimeBetweenLightTraffic = e.TimeBetweenLightTraffic,
                    DistanceBetweenLightTraffic = e.DistanceBetweenLightTraffic,
                    carSpeed = e.CarSpeed,
                    sessionTime = e.SessionTime,
                }
            ).Select(o => o).ToList();
            return lightTrafficStatistics;
        }

        private void WriteToJson(string jsonPath, string sessionKey)
        {
            var data = GetSessionData(sessionKey);
            using (var writer = new StreamWriter(jsonPath))
            {
                string jsonData = JsonConvert.SerializeObject(data);
                writer.Write(jsonData);
            }
        }

        private dynamic GetSessionData(string sessionKey)
        {
            var sessionData = Context.Session.Where(o => o.Key == sessionKey).Join(
                Context.Car,
                l => l.Id,
                r => r.Session.Id,
                (l, r) => new
                {
                    Session = new Dictionary<string, dynamic>
                    {
                        {"Id", l.Id},
                        {"Key", l.Key},
                        {"Status", l.Status},
                        {"Total time", l.TotalTime}
                    },
                    Car = new Dictionary<string, dynamic>
                    {
                        {"Name", r.Name},
                        {"Max speed", r.MaxSpeed},
                        {"Acceleration", r.Acceleration},
                        {"Deceleration", r.Deceleration}
                    },
                }
            ).Select(o => o);
            var lightTrafficData = Context.Session.Where(o => o.Key == sessionKey).Join(
                Context.LightTraffic,
                l => l.Id,
                r => r.Session.Id,
                (l, r) => new
                {
                    LightTraffic = new Dictionary<string, dynamic>
                    {
                        {"Position id", r.PositionId},
                        {"Red light duration", r.RedLightDuration},
                        {"Yellow light duration", r.YellowLightDuration},
                        {"Green light duration", r.GreenLightDuration},
                        {"Start color", r.StartColor},
                        {"Next color", r.NextColor},
                        {"Status", r.Status},
                        {"Previous distance", r.PreviousDistance}
                    }
                }
            ).Select(o => o);
            var resultData = new
            {
                sessionData,
                lightTrafficData
            };      
                
            return resultData;
        }
    }
}