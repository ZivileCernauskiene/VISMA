using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaMeetingApp
{
    internal class Meeting
    {
        public Meeting(string name, string description, string responsiblePerson, Category category, Type type, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Description = description;
            ResponsiblePerson = responsiblePerson;
            Category = category;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            Attendees.Add(responsiblePerson);
        }

        public string Name { get; set; } = "default";
        public string Description { get; set; } = "default";
        public string ResponsiblePerson { get; set; }= "default";
        public Category Category { get; set; }= Category.CodeMonkey;
        public Type Type { get; set; } = Type.Live;
        public DateTime StartDate { get; set; }=DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public List<string> Attendees = new List<string>();
        
    }
}
public enum Category
{
    CodeMonkey,
    Hub,
    Short,
    TeamBuilding
}
public enum Type{
    Live,
    InPerson
}
