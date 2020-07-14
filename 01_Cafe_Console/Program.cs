using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //new instance of program ui then boots the run() method within ProgramUI
            Cafe_ProgramUI ui = new Cafe_ProgramUI();
            ui.Run();
        }
    }
}
