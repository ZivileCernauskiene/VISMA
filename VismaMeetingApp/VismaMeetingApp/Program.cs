// See https://aka.ms/new-console-template for more information
using VismaMeetingApp;

Console.WriteLine("Hello, World!");
DataBase.loadMeetings();
Controlls.DeleteMeeting("Pirmas");
DataBase.saveMeetings();
Console.WriteLine(DataBase.Meetings.Count);
Console.WriteLine("Pabaiga");
