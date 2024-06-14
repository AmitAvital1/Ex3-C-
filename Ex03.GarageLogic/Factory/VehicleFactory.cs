using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Vehicles;
using Ex03.GarageLogic.Entities.Vehicles.Car;
using Ex03.GarageLogic.Entities.Vehicles.Motorcycle;
using Ex03.GarageLogic.Factory.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        .SetEngine(new ElectricEngine(i_VehicleDto.CurrentEnergy, i_VehicleDto.CapacityEnergy)) 
                        .Build();

                case eVehicleType.FuelMotorcycle:
                    return new Motorcycle.MotorcycleBuilder()
                        .SetLicenseType(i_VehicleDto.LicenseType)
                        .SetEngineCapacity(i_VehicleDto.EngineCapacity) 
                        .SetEngine(new FuelEngine(i_VehicleDto.CurrentEnergy, i_VehicleDto.CapacityEnergy, i_VehicleDto.FuelType)) 
                        .Build();

                case eVehicleType.ElectricCar:
                    return new Car.CarBuilder()
                        .SetColor(i_VehicleDto.Color)
                        .SetNumOfDoors(i_VehicleDto.NumberOfDoors)
                        .SetEngine(new ElectricEngine(i_VehicleDto.CurrentEnergy, i_VehicleDto.CapacityEnergy)) 
                        .Build();

                case eVehicleType.FuelCar:
                    return new Car.CarBuilder()
                        .SetColor(i_VehicleDto.Color)
                        .SetNumOfDoors(i_VehicleDto.NumberOfDoors) 
                        .SetEngine(new FuelEngine(i_VehicleDto.CurrentEnergy, i_VehicleDto.CapacityEnergy, i_VehicleDto.FuelType)) 
                        .Build();

                case eVehicleType.ElectricTruck:
                    return new Truck.TruckBuilder()
                        .SetIsTransportDangerous(i_VehicleDto.IsTransportDangerous) 
                        .SetTransportCapacity(i_VehicleDto.TransportCapacity) 
                        .SetEngine(new ElectricEngine(i_VehicleDto.CurrentEnergy, i_VehicleDto.CapacityEnergy)) 
                        .Build();

                case eVehicleType.FuelTruck:
                    return new Truck.TruckBuilder()
                        .SetIsTransportDangerous(i_VehicleDto.IsTransportDangerous) 
                        .SetTransportCapacity(i_VehicleDto.TransportCapacity) 
                        .SetEngine(new FuelEngine(i_VehicleDto.CurrentEnergy, i_VehicleDto.CapacityEnergy, i_VehicleDto.FuelType)) 
                        .Build();

                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
