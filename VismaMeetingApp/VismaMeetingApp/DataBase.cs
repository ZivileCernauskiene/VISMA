using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaMeetingApp
{
    internal static class DataBase
    {
        const string meetingInfo = "Meetings.json";
        public static List<Meeting> Meetings = new List<Meeting>();
        
        public static void loadMeetings()
        {
            if (File.Exists(meetingInfo))
            {
                var meetingsFromFile=File.ReadAllText(meetingInfo);
                var objectData=JsonConvert.DeserializeObject<List<Meeting>>(meetingsFromFile);
                if (objectData.Count > 0)
                {
                    Meetings = objectData;
                }
                
            }
            else
            {
                Console.WriteLine("No file. Let's create a new meeting");
            }
        }

        public static void saveMeetings()
        {
            if (Meetings.Count > 0)
            {
                var meetingsToText=JsonConvert.SerializeObject(Meetings);
                File.WriteAllText(meetingInfo, meetingsToText);
            }
            else
            {
                File.WriteAllText(meetingInfo, "[]");
            }
        }
    }
}
