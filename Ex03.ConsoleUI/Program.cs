using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI.GarageManagerHandler;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main() 
        {
            run();
        }

        private static void run()
        {
            GarageManager garageManager = new GarageManager();
            garageManager.ActivateGarage();
        }
    }
}
