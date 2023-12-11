using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DAL_Repository.Model;
using System.Security.Cryptography.X509Certificates;

namespace API.DAL_Repository
{
    public class TimeRepository : ITimeRepository
    {
        string jsonData = File.ReadAllText(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"DAL_Repository\Data\Time.json"));
        public TimeRepository()
        {

        }
        public int getAll()
        {
            var d = 100;
            return d;


        }
        public List<Time> GetAllJson()
        {

            var data = JsonConvert.DeserializeObject<List<Time>>(jsonData).ToList();
            return data;
        }

        public Time UpdateaVailablePlaces(Time t)
        {
            try
            {
                List<Time> times = JsonConvert.DeserializeObject<List<Time>>(jsonData);

                Time foundTime = times.Find(x => x.startTime == t.startTime);

                if (foundTime != null && foundTime.availablePlaces >= t.availablePlaces)///בדיקה - לראות שלא מוריד יותר כרטיסים מהכמות שיש 
                {
                    foundTime.availablePlaces -= t.availablePlaces;
                }
                else
                {
                    Console.WriteLine($"TIME with startTime {t.startTime} not found.");
                }

                File.WriteAllText(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"DAL_Repository\Data\Time.json"), JsonConvert.SerializeObject(times));
                return foundTime;

            }
            catch (Exception)
            {

                return null ;
            }

             
        }
    }
}