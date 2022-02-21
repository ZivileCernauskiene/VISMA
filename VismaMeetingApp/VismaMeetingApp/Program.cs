﻿// See https://aka.ms/new-console-template for more information
using VismaMeetingApp;

Console.WriteLine("Welcome to console App");
DataBase.loadMeetings();

List<string> startOptions = new List<string>() {"1. Add a meeting", "2. Select a meeting ", "3. End program " };
List<string> selectMeeting = new List<string>() { "1. Select a meeting ", "2. Filter meetings", "3. End program" };
List<string> filterOptions = new List<string>() {"1. Filter by description", "2. Filter by responsible person ", "3.Filter by category", "4. Filter by type", "5. Filter by dates (you will be asked to provide start date and end date).", "6. Filter by minimum number of attendees" };
List<string> whatToDoWithMeeting = new List<string>() { "1. Add person", "2. Remove person", "3. Delete meeting" };

while (!Controlls.EndProgram)
{
    
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
            Console.Clear();
            string selectedFilter=MainSelections.GetValidSelection(filterOptions);

            if (Controlls.EndProgram)
            {
                break;
            }
            if (selectedFilter == "1")
            {
                Console.WriteLine("How to filter descriptions of meetings? ");
                string filteringDescription=Console.ReadLine();
                meetingsToShow=DataBase.Meetings.Select(x=>x.Description).Where(a=>a.Contains(filteringDescription)).ToList();
                goto selectAgain;
            }
            if (selectedFilter == "2")
            {
                Console.WriteLine("These are responsible persons: ");
                List<string> allResposibles = DataBase.Meetings.Select(x=>x.ResponsiblePerson).Distinct().ToList();

          

                string filteringResponsible=MainSelections.GetValidSelection(allResposibles);


                // this is bad line but it works (not in all cases though)
                meetingsToShow = DataBase.Meetings.Select(x =>  x.Name + "   " + x.Description +"    "+x.ResponsiblePerson).Where(a=>a.Contains(allResposibles[int.Parse(filteringResponsible)-1])).ToList();
                goto selectAgain;
            }
            
            
            
            goto selectAgain;
        }
        else break;
    }
    else break;
}

DataBase.saveMeetings();
Console.WriteLine(DataBase.Meetings.Count);
Console.WriteLine("Pabaiga");
