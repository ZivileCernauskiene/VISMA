using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaMeetingApp
{
    internal static class MainSelections
    {
        
        public static string GetValidSelection(List<string> options)
        {
            while (true)
            {
                options.ForEach(x => Console.WriteLine(x));
                string selection = Console.ReadLine();
                for (int i = 1; i <= options.Count; i++)
                {
                    if (selection == i.ToString())
                    {
                        return selection;
                    }
                    if (selection == Controlls.endAll)
                    {
                        Controlls.EndProgram = true;
                        return "1";
                    }
                }
                Console.Clear();
                Console.WriteLine("Please choose a number");
            }
        }
    }
}
