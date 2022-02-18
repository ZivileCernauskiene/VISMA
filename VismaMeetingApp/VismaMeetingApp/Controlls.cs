using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaMeetingApp
{
    public static class Controlls
    {
        public static bool EndProgram = false;
        static string terminating = "Terminating.....";
        static string endAll = "PLEASEENDTHISMISSERY";

        public static void AddMeeting()
        {
            //get unique name
            string name = askString("Name of new meeting: ");
            if (DataBase.Meetings != null)
            {
                if (DataBase.Meetings.Any(x => x.Name == name))
                    {
                    Console.WriteLine("Meeting with this name already exists. Try again?");
                    if (tryAgain("Meeting with this name already exists. Try again? Y/N"))
                    {
                        AddMeeting();
                    }
                    else
                    {
                        EndProgram = true;
                        Console.WriteLine(terminating);
                        return;
                    }
                }
            }

            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            // get description
            string description = askString("Add description: ");
            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            //get Responsible 
            string responsible = askString("Responsible person: ");
            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            // get Category 
            Category category = GetCategory("Meeting category: ");
            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            //get Type
            Type type = GetType("Meeting type: ");
            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            //get startDate
            DateTime startMeeting = GetDateTime("Meeting starts at: ");
            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            //get endDate
            DateTime endMeeting = GetDateTime("Meeting ends at: ");
            if (EndProgram)
            {
                Console.WriteLine(terminating);
                return;
            }

            DataBase.Meetings.Add(new Meeting(name, description, responsible, category, type, startMeeting, endMeeting));
            Console.WriteLine("Meeting added. Success");
        }

        public static void DeleteMeeting(string name)
        {
            if (DataBase.Meetings.Any(x => x.Name == name))
            {
                Console.WriteLine("Who is responsible?");
                string responsible = Console.ReadLine();
                if (DataBase.Meetings.Any(x => x.Name == name && x.ResponsiblePerson == responsible))
                {
                    if(tryAgain("Are you sure you want to delete this meeting? "))
                    {
                        Meeting meetingToDelete=DataBase.Meetings.FirstOrDefault(x => x.Name == name);
                        DataBase.Meetings.Remove(meetingToDelete);
                        Console.WriteLine("Meeting " + meetingToDelete.Name + " deleted. ");
                    }
                }
                
            }
        }




        static string askString(string question)
        {
            while (true)
            {
                Console.Write(question);
                string answer = Console.ReadLine();
                if (answer != "" || answer != endAll)
                {
                    return answer;
                }
                if (answer == endAll)
                {
                    EndProgram = true;
                    return "a5ae1b786f924b755ef026efb3c21179b3c33e9f";
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong. Try again");
                }
            }
        }

        static bool tryAgain(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes")
            {
                return true;
            }
            return false;
        }

        static Category GetCategory(string question)
        {
            List<string> categories = new List<string>() { "1. CodeMonkey", "2. Hub", "3. Short", "4. TeamBuilding" };
            while (true)
            {
                Console.WriteLine(question);
                categories.ForEach(x => Console.WriteLine(x));
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1": return Category.CodeMonkey;
                    case "2": return Category.Hub;
                    case "3": return Category.Short;
                    case "4": return Category.TeamBuilding;
                    case "PLEASEENDTHISMISSERY":
                        {
                            EndProgram = true;
                            return Category.TeamBuilding;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Please use Numeric answer 1,2,3,4 respectively");
                            break;
                        }
                }
            }
        }

        static Type GetType(string question)
        {
            List<string> types = new List<string>() {"1. InPerson", "2. Live" };
            while (true)
            {
                Console.WriteLine(question);
                types.ForEach(x => Console.WriteLine(x));
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    return Type.InPerson;
                }
                if (answer == "2")
                {
                    return Type.Live;
                }
                if(answer== "PLEASEENDTHISMISSERY")
                {
                    EndProgram = true;
                    return Type.Live;
                }
                Console.Clear();
                Console.WriteLine("Please use Numeric answer 1,2 respectively");
            }
        }

        static DateTime GetDateTime(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                string userDefinedDate = Console.ReadLine();
                DateTime dateTime = new DateTime();
                if(DateTime.TryParse(userDefinedDate, out dateTime))
                {
                    return dateTime;
                }
                if(question == endAll)
                {
                    EndProgram = true;
                    return DateTime.Now;
                }
                Console.Clear();
                Console.WriteLine("Wrong format, please use correct DataTime format");
            }
        }
    }
}
