using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Vehicles;
using Ex03.GarageLogic.Entities.Vehicles.CarHandler;
using Ex03.GarageLogic.Entities.Vehicles.MotorcycleHandler;
using Ex03.GarageLogic.Factory.Dto;
using System;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Factory
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, VehicleDto i_VehicleDto)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    return new Motorcycle.MotorcycleBuilder()
                        .SetLicenseType(i_VehicleDto.LicenseType)
                        .SetEngineCapacity(i_VehicleDto.EngineCapacity) 
                        .SetEngine(new ElectricEngine(eEngineType.Electricy,i_VehicleDto.CurrentEnergy, Constants.sr_ElectricEngineMotorcycleMaxCapacity))
                        .SetModelName(i_VehicleDto.ModelName)
                        .SetPlateNumber(i_VehicleDto.PlateNumber)
                        .SetWheels(i_VehicleDto.WheelsData)
                        .Build();

                case eVehicleType.FuelMotorcycle:
                    return new Motorcycle.MotorcycleBuilder()
                        .SetLicenseType(i_VehicleDto.LicenseType)
                        .SetEngineCapacity(i_VehicleDto.EngineCapacity) 
                        .SetEngine(new FuelEngine(eEngineType.Octan98,i_VehicleDto.CurrentEnergy, Constants.sr_FuelEngineMotorcycleMaxCapacity))
                        .SetModelName(i_VehicleDto.ModelName)
                        .SetPlateNumber(i_VehicleDto.PlateNumber)
                        .SetWheels(i_VehicleDto.WheelsData)
                        .Build();

                case eVehicleType.ElectricCar:
                    return new Car.CarBuilder()
                        .SetColor(i_VehicleDto.Color)
                        .SetNumOfDoors(i_VehicleDto.NumberOfDoors)
                        .SetEngine(new ElectricEngine(eEngineType.Electricy, i_VehicleDto.CurrentEnergy, Constants.sr_ElectricEngineCarMaxCapacity))
                        .SetModelName(i_VehicleDto.ModelName)
                        .SetPlateNumber(i_VehicleDto.PlateNumber)
                        .SetWheels(i_VehicleDto.WheelsData)
                        .Build();

                case eVehicleType.FuelCar:
                    return new Car.CarBuilder()
                        .SetColor(i_VehicleDto.Color)
                        .SetNumOfDoors(i_VehicleDto.NumberOfDoors) 
                        .SetEngine(new FuelEngine(eEngineType.Octan95, i_VehicleDto.CurrentEnergy, Constants.sr_FuelEngineCarMaxCapacity)) 
                        .SetModelName(i_VehicleDto.ModelName)
                        .SetPlateNumber(i_VehicleDto.PlateNumber)
                        .SetWheels(i_VehicleDto.WheelsData)
                        .Build();

                case eVehicleType.FuelTruck:
                    return new Truck.TruckBuilder()
                        .SetIsTransportDangerous(i_VehicleDto.IsTransportDangerous) 
                        .SetTransportCapacity(i_VehicleDto.TransportCapacity) 
                        .SetEngine(new FuelEngine(eEngineType.Soler, i_VehicleDto.CurrentEnergy, Constants.sr_FuelEngineTruckMaxCapacity))
                        .SetModelName(i_VehicleDto.ModelName)
                        .SetPlateNumber(i_VehicleDto.PlateNumber)
                        .SetWheels(i_VehicleDto.WheelsData)
                        .Build();

                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
