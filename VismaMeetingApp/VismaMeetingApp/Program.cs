// See https://aka.ms/new-console-template for more information
using VismaMeetingApp;

Console.WriteLine("Welcome to console App");
DataBase.loadMeetings();

List<string> startOptions = new List<string>() {"1. Add a meeting", "2. Select a meeting ", "3. End program " };
List<string> selectMeeting = new List<string>() { "1. Select a meeting ", "2. Filter meetings", "3. End program" };
List<string> filterOptions = new List<string>() {"1. Filter by name", "2. Filter by description ", "3.Filter by responsible person", "4. Filter by date" };
List<string> whatToDoWithMeeting = new List<string>() { "1. Add person", "2. Remove person", "3. Delete meeting" };

while (!Controlls.EndProgram)
{
    Console.Clear();
    Console.WriteLine("What do you want to do? Choose a number: ");
    string mainSelecion = MainSelections.GetValidSelection(startOptions);
    if (Controlls.EndProgram)
    {
        break;
    }
    if (mainSelecion == "1")
    {
        Console.WriteLine("You are now adding a meeting....");
        Controlls.AddMeeting();
        DataBase.saveMeetings();
    }
    else if (mainSelecion == "2")
    {
        List<string> meetingsToShow = DataBase.Meetings.Select(x => x.Name).ToList();
        selectAgain: ;
        Console.Clear();
        Console.WriteLine("This is a list of available meetings :");
        meetingsToShow.ForEach(x => Console.WriteLine(x));
        if (meetingsToShow.Count == 0)
        {
            Console.WriteLine("No meetings found, try filter less or add new meeting");
        }
        Console.WriteLine("Choose what to do next: ");
        
        string filterOrSelectMeeting = MainSelections.GetValidSelection(selectMeeting);
        
        
        if (filterOrSelectMeeting == "1")
        {
        
            string selectedMeeting = MainSelections.GetValidSelection(meetingsToShow);
            if (Controlls.EndProgram)
            {
                break;
            }
            string selectedAction=MainSelections.GetValidSelection(whatToDoWithMeeting);
            if (Controlls.EndProgram)
            {
                break;
            }
            if (selectedAction == "1")
            {
                Controlls.AddPerson(meetingsToShow[int.Parse(selectedMeeting)-1]);
            }
            else if (selectedAction == "2")
            {
                Controlls.RemovePerson(meetingsToShow[int.Parse(selectedMeeting)-1]);
            }
            else if (selectedAction == "3")
            {
                Controlls.DeleteMeeting(meetingsToShow[int.Parse(selectedMeeting)-1]);
            }
        }
        if (filterOrSelectMeeting == "2")
        {
            goto selectAgain;
        }
        else break;
    }
    else break;
}

DataBase.saveMeetings();
Console.WriteLine(DataBase.Meetings.Count);
Console.WriteLine("Pabaiga");
