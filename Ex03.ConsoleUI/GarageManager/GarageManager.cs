﻿using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Vehicles.Motorcycle;
using Ex03.GarageLogic.Entities.Vehicles;
using Ex03.GarageLogic.Garage;
using System;
using System.Collections;
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
            string modelName = getVehicleModelName();
            (string ownerName, string ownerPhone) = getOwnerDetailsFromUser();
            int vehicleType = getVehicleTypeFromUser();
            bool isFuel = askUserIfHeWantToEnterDataAboutVehicleWithFuelEngine();
            (float energyMaxTank, float energyStatus) = getEnergyStatusOfTheCurrentVehicle(isFuel);
            IList<WheelDto> wheelsData = getNumberOfAirInWheels();

            var vehicleDtoBuilder = new VehicleDto.VehicleDtoBuilder()
                .SetPlateNumber(i_PlateNumber)
                .SetModelName(modelName)
                .SetCapacityEnergy(energyMaxTank)
                .SetCurrentEnergy(energyStatus)
                .SetWheelsData(wheelsData)
                .SetOwnerName(ownerName)
                .SetOwnerPhone(ownerPhone);

            switch (vehicleType)
            {
                case 1:
                    addCar(vehicleDtoBuilder);
                    break;
                case 2:
                    addTruck(vehicleDtoBuilder);
                    break;
                case 3:
                    addMotorcycle(vehicleDtoBuilder);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    getDetailsAboutVehicle(i_PlateNumber);
                    break;
            }

            if (isFuel)
            {
                vehicleDtoBuilder.SetEngineType("Fuel")
                    .SetFuelType(getEngineType());
            }
            else
            {
                vehicleDtoBuilder.SetEngineType("Electricy")
                    .SetFuelType("Electricy");
            }

            VehicleDto vehicle = vehicleDtoBuilder.Build();
            r_Garage.AddVehicles(vehicle);
        }

        private void addTruck(VehicleDto.VehicleDtoBuilder i_VehicleDtoBuilder)
        {
            int numberOfDoors = getNumberOfDoors();
            float transportCapacity = getTransportCapacity();
            bool isDangerous = getTruckDangerous();

            i_VehicleDtoBuilder
                .SetType("Truck")
                .SetIsTransportDangerous(isDangerous)
                .SetNumbersOfDoors(numberOfDoors)
                .SetTransportCapacity(transportCapacity);
        }

        private void addMotorcycle(VehicleDto.VehicleDtoBuilder i_VehicleDtoBuilder)
        {
            string licenseType = getLicenseType();
            int engineCapacity = getMotorcycleEngineCapacity();

            i_VehicleDtoBuilder
                .SetType("Motorcycle")
                .SetLicenseType(licenseType)
                .SetEngineCapacity(engineCapacity);
        }

        private string getLicenseType()
        {
            Console.WriteLine("Please enter the motorcycle license type: (A/A1/AA/B1)");
            string licenseType = Console.ReadLine();

            return licenseType;
        }

        private int getMotorcycleEngineCapacity()
        {
            int engineCapacity;

            Console.WriteLine("Please enter engine capacity:");

            while (!int.TryParse(Console.ReadLine(), out engineCapacity) || engineCapacity < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for engine capacity");
            }

            return engineCapacity;
        }

        private float getTransportCapacity()
        {
            float transportCapacity;

            Console.WriteLine("Please enter if the truck transport capacity:");

            while (!float.TryParse(Console.ReadLine(), out transportCapacity) || transportCapacity <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid non negative number for transport capacity");
            }

            return transportCapacity;
        }

        private bool getTruckDangerous()
        {
            int isDangerous;

            Console.WriteLine("Please enter if the truck transmit dangerous package: 1 - Yes | 0 - No");

            while (!int.TryParse(Console.ReadLine(), out isDangerous) || isDangerous != 0 && isDangerous != 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number: 1 - Yes | 0 - No");
            }

            return isDangerous == 1;
        }

        private int getVehicleTypeFromUser()
        {
            Console.WriteLine("Please select the type of vehicle you want to add:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.WriteLine("3. Motorcycle");

            return int.Parse(Console.ReadLine());
        }

        private string getVehicleModelName()
        {
            Console.WriteLine("Please enter the vehicle model name:");
            string modelName = Console.ReadLine();

            return modelName;
        }

        private (string, string) getOwnerDetailsFromUser()
        {
            Console.WriteLine("Please enter the owner's name:");
            string ownerName = Console.ReadLine();

            Console.WriteLine("Please enter the owner's phone number:");
            string ownerPhone = Console.ReadLine();

            return (ownerName, ownerPhone);
        }

        private IList<WheelDto> getNumberOfAirInWheels()
        {
            int numOfWheels;

            Console.WriteLine("Please enter the number of wheels:");

            while (!int.TryParse(Console.ReadLine(), out numOfWheels) || numOfWheels < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for the wheels number:");
            }

            IList<WheelDto> wheelsData = new List<WheelDto>(numOfWheels);

            for(int i = 0; i < numOfWheels; i++)
            {
                wheelsData.Add(getWheelDetails());
            }

            return wheelsData;
        }

        public WheelDto getWheelDetails()
        {
            float maxAirPressure;
            float airPressure;

            Console.WriteLine("Please enter the producer of the wheel:");
            string producerName = Console.ReadLine();

            Console.WriteLine("Please enter the max air pressure the wheel (in psi):");

            while (!float.TryParse(Console.ReadLine(), out maxAirPressure) || maxAirPressure < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for the max air pressure:");
            }

            Console.WriteLine("Please enter the air pressure the wheel (in psi):");

            while (!float.TryParse(Console.ReadLine(), out airPressure) || airPressure < 0 || airPressure > maxAirPressure)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for the air pressure or not bigger then max air pressure:");
            }

            return new WheelDto
                       {
                           ManufacturerName = producerName,
                           CurrentAirPressure = airPressure,
                           MaxAirPressure = maxAirPressure
            };
        }

        private (float, float) getEnergyStatusOfTheCurrentVehicle(bool i_IsFuel)
        {
            float maxEnergyTank;
            float statusEnergy;

            if (i_IsFuel)
            {
                Console.WriteLine("Please enter the max amount of fuel tank in liters:");
            }
            else
            {
                Console.WriteLine("Please enter the max battery capacity in hours:");
            }

            while (!float.TryParse(Console.ReadLine(), out maxEnergyTank) || maxEnergyTank < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number:");
            }

            if (i_IsFuel)
            {
                Console.WriteLine("Please enter the current amount of fuel in liters:");
            }
            else
            {
                Console.WriteLine("Please enter the current battery status (in hours):");
            }

            while (!float.TryParse(Console.ReadLine(), out statusEnergy) || statusEnergy < 0 || maxEnergyTank < statusEnergy)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number or number that not bigger then the tank:");
            }

            return (maxEnergyTank, statusEnergy);
        }

        private void addCar(VehicleDto.VehicleDtoBuilder i_VehicleDtoBuilder)
        {
            string carColor = getCarColor();
            int numberOfDoors = getNumberOfDoors();

            i_VehicleDtoBuilder
                .SetType("Car")
                .SetNumbersOfDoors(numberOfDoors)
                .SetColor(carColor);
        }

        private string getEngineType()
        {
            string engineType = null;
            bool isValidType = false;

            Console.WriteLine("Please enter the engine type (Soler, Octan95, Octan96, Octan98):");

            while (!isValidType)
            {
                engineType = Console.ReadLine();
                isValidType = engineType.Equals("Soler", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Octan95", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Octan96", StringComparison.OrdinalIgnoreCase) ||
                              engineType.Equals("Octan98", StringComparison.OrdinalIgnoreCase);

                if (!isValidType)
                {
                    Console.WriteLine("Invalid input. Please enter a valid engine type (Soler, Octan95, Octan96, Octan98):");
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
