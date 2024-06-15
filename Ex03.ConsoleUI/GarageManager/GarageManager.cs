using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Vehicles.Motorcycle;
using Ex03.GarageLogic.Entities.Vehicles;
using Ex03.GarageLogic.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Factory.Dto;
using Ex03.ConsoleUI.VehicleDataHandler;

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
           try
            {
                while (true)
                {
                    showMenu();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void showMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a vehicle");
            Console.WriteLine("2. Show plate numbers with options to filter");
            Console.WriteLine("3. Change vehicle state");
            Console.WriteLine("4. Inflate wheels");
            Console.WriteLine("5. Refuel a fuel-driven vehicle");
            Console.WriteLine("6. Charge an electric vehicle");
            Console.WriteLine("7. View full vehicle details");
            Console.WriteLine("0. Exit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    addVehicle();
                    break;
                case 2:
                    showPlateNumbersWithFilterOptions();
                    break;
                case 3:
                    changeVehicleState();
                    break;
                case 4:
                    inflateWheels();
                    break;
                case 5:
                    refuelFuelDrivenVehicle();
                    break;
                case 6:
                    chargeElectricVehicle();
                    break;
                case 7:
                    viewFullVehicleDetails();
                    break;
                case 0:
                    exit();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }

        private void exit()
        {
            Environment.Exit(0);
        }

        private void addVehicle()
        {
            Console.WriteLine("Please enter the plate number of the vehicles:");
            string plateNumber = Console.ReadLine();

            if (r_Garage.CheckIfCarExistInGarage(plateNumber))
            {
                Console.WriteLine("The vehicles already exist in the Garage. we move to repair mode.");
            }
            else
            {
                getDetailsAboutVehicle(plateNumber);
            }
        }

        private void showPlateNumbersWithFilterOptions()
        {
            Console.WriteLine("Please enter a filter option (Repair, Repaired, Paid):");
            string filterOption = Console.ReadLine();

            IList<string> vehiclePlateNumbers = r_Garage.GetListOFVwhicleByFilter(filterOption);
            
            if (vehiclePlateNumbers.Count == 0)
            {
                Console.WriteLine("No vehicles found for the selected filter.");
                return;
            }

            Console.WriteLine($"Plate numbers for {filterOption} vehicles:");
            foreach (string plateNumber in vehiclePlateNumbers)
            {
                Console.WriteLine(plateNumber);
            }
        }

        private void changeVehicleState()
        {

        }

        private void inflateWheels()
        {

        }

        private void refuelFuelDrivenVehicle()
        {

        }

        private void chargeElectricVehicle()
        {

        }

        private void viewFullVehicleDetails()
        {

        }

        private void getDetailsAboutVehicle(string i_PlateNumber)
        {
            (string ownerName, string ownerPhone) = getOwnerDetailsFromUser();
            int vehicleType = getVehicleTypeFromUser();
            bool isFuel = askUserIfHeWantToEnterDataAboutVehicleWithFuelEngine();
            float energyStatus = getEnergyStatusOfTheCurrentVehicle(isFuel);
            float numberOfAirWheels = getNumberOfAirInWheels();

            VehicleData vehicleData = new VehicleData
            {
                VehicleType = vehicleType,
                IsFuel = isFuel,
                EnergyStatus = energyStatus,
                NumberOfAirWheels = numberOfAirWheels,
                OwnerName = ownerName,
                OwnerPhone = ownerPhone
            };

            switch (vehicleType)
            {
                case 1:
                    addCar(vehicleData, i_PlateNumber);
                    break;
                case 2:
                    addTruck(vehicleData, i_PlateNumber);
                    break;
                case 3:
                    addMotorcycle(vehicleData, i_PlateNumber);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    getDetailsAboutVehicle(i_PlateNumber);
                    break;
            }
        }

        private void addTruck(VehicleData i_VehicleData, string i_PlateNumber)
        {

        }

        private void addMotorcycle(VehicleData i_VehicleData, string i_PlateNumber)
        {

        }

        private int getVehicleTypeFromUser()
        {
            Console.WriteLine("Please select the type of vehicle you want to add:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.WriteLine("3. Motorcycle");

            return int.Parse(Console.ReadLine());
        }

        private (string, string) getOwnerDetailsFromUser()
        {
            Console.WriteLine("Please enter the owner's name:");
            string ownerName = Console.ReadLine();

            Console.WriteLine("Please enter the owner's phone number:");
            string ownerPhone = Console.ReadLine();

            return (ownerName, ownerPhone);
        }

        private float getNumberOfAirInWheels()
        {
            float airPressure;

            Console.WriteLine("Please enter the air pressure for each wheel (in psi):");

            while (!float.TryParse(Console.ReadLine(), out airPressure) || airPressure < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for the air pressure:");
            }

            return airPressure;
        }

        private float getEnergyStatusOfTheCurrentVehicle(bool i_IsFuel)
        {
            float statusEnergy;

            if (i_IsFuel)
            {
                Console.WriteLine("Please enter the current amount of fuel in liters:");
            }
            else
            {
                Console.WriteLine("Please enter the current battery status (in percentage):");
            }

            while (!float.TryParse(Console.ReadLine(), out statusEnergy) || statusEnergy < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number:");
            }

            return statusEnergy;
        }

        private void addCar(VehicleData i_VehicleData, string i_PlateNumber)
        {
            string carColor = getCarColor();
            int numberOfDoors = getNumberOfDoors();

            var vehicleDto = new VehicleDto.VehicleDtoBuilder()
                    .SetPlateNumber(i_PlateNumber)
                    .SetType("Car")
                    .SetColor(carColor)
                    .SetCurrentEnergy(i_VehicleData.EnergyStatus)
                    .SetWheelCapacity(i_VehicleData.NumberOfAirWheels)
                    .SetNumbersOfDoors(numberOfDoors)
                    .SetOwnerName(i_VehicleData.OwnerName)
                    .SetOwnerPhone(i_VehicleData.OwnerPhone);
            
            if (i_VehicleData.IsFuel)
            {
                vehicleDto.SetEngineType("Fuel")
                              .SetFuelType(getEngineType());
            }
            else
            {
                vehicleDto.SetEngineType("Electricy")
                              .SetFuelType("Electricy");
            }

            VehicleDto vehicle = vehicleDto.Build();
            r_Garage.AddVehicles(vehicle);
        }

        private string getEngineType()
        {
            string engineType = null;
            bool isValidType = false;

            Console.WriteLine("Please enter the engine type (Soler, Octan95, Octan96, Octan98, Electric):");

            while (!isValidType)
            {
                engineType = Console.ReadLine();
                isValidType = engineType.Equals("Soler", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Octan95", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Octan96", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Octan98", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Electric", StringComparison.OrdinalIgnoreCase);

                if (!isValidType)
                {
                    Console.WriteLine("Invalid input. Please enter a valid engine type (Soler, Octan95, Octan96, Octan98, Electric):");
                }
            }

            return engineType;
        }

        private int getNumberOfDoors()
        {
            int numberOfDoors = 1;
            bool isValid = false;

            Console.WriteLine("Please enter the number of doors (2, 3, 4, 5):");

            while (!isValid)
            {
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out numberOfDoors) && (numberOfDoors == 2 || numberOfDoors == 3 || numberOfDoors == 4 || numberOfDoors == 5);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of doors (2, 3, 4, 5):");
                }
            }

            return numberOfDoors;
        }

        private string getCarColor()
        {
            string carColor = null;
            bool isValidColor = false;

            Console.WriteLine("Please enter the color of the car (Yellow, White, Red, Black):");

            while (!isValidColor)
            {
                carColor = Console.ReadLine();
                isValidColor = carColor.Equals("Yellow", StringComparison.OrdinalIgnoreCase) ||
                               carColor.Equals("White", StringComparison.OrdinalIgnoreCase) ||
                               carColor.Equals("Red", StringComparison.OrdinalIgnoreCase) ||
                               carColor.Equals("Black", StringComparison.OrdinalIgnoreCase);

                if (!isValidColor)
                {
                    Console.WriteLine("Invalid input. Please enter a valid color (Yellow, White, Red, Black):");
                }
            }

            return carColor;
        }

        private bool askUserIfHeWantToEnterDataAboutVehicleWithFuelEngine()
        {
            Console.WriteLine("Do you want to enter data about a vehicle with a fuel engine or an electric engine?");
            Console.WriteLine("Enter 'fuel' for a fuel engine or 'electric' for an electric engine:");

            string userInput = Console.ReadLine().Trim().ToLower();

            while (userInput != "fuel" && userInput != "electric")
            {
                Console.WriteLine("Invalid input. Please enter 'fuel' or 'electric':");
                userInput = Console.ReadLine().Trim().ToLower();
            }

            return userInput == "fuel";
        }
        
    }
}
