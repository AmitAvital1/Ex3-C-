using Ex03.GarageLogic.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI.GarageManagerHandler
{
    public class GarageManager
    {
        private readonly Garage r_Garage;
        public GarageManager() 
        {
            r_Garage = new Garage();
        }

        public void ActivateGarage()
        {
            Console.WriteLine("Please enter the plate number of the vehicles:");
            string plateNumber = Console.ReadLine();

            if (r_Garage.CheckIfCarExistInGarage(plateNumber))
            {
                Console.WriteLine("The vehicles already exist in the Garage. we move to repair mode.");
            }
            else
            {

               // r_Garage.AddVehicles()
            }
        }
    }
}
