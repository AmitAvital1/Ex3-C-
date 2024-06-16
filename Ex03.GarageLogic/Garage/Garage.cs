using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Vehicles;
using Ex03.GarageLogic.Entities.Vehicles.CarHandler;
using Ex03.GarageLogic.Entities.Vehicles.MotorcycleHandler;
using Ex03.GarageLogic.Entities.Wheels;
using Ex03.GarageLogic.Factory;
using Ex03.GarageLogic.Factory.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private IList<AddressCard> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new List<AddressCard>();
        }

        public void AddVehicles(VehicleDto i_Vehicle)
        {
            eVehicleType vehicleType = getTypeOfVehicles(i_Vehicle.Type, i_Vehicle.EngineType);
            Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, i_Vehicle);
            AddressCard card = createNewAddressCard(vehicle, i_Vehicle);

            m_Vehicles.Add(card);
        }

        private AddressCard createNewAddressCard(Vehicle i_Vehicle, VehicleDto i_VehicleDto)
        {
            AddressCard card = new AddressCard
            {
                m_Vechile = i_Vehicle,
                m_OwnerName = i_VehicleDto.OwnerName,
                m_OwnerPhone = i_VehicleDto.OwnerPhone,
                m_State = eState.Repaired
            };

            return card;
        }

        private eVehicleType getTypeOfVehicles(string i_VehicleType, string i_EngineType)
        {
            switch (i_VehicleType.ToLower())
            {
                case "motorcycle":
                    return i_EngineType.ToLower() == eEngineType.Electricy.ToString().ToLower() ? eVehicleType.ElectricMotorcycle : eVehicleType.FuelMotorcycle;
                case "car":
                    return i_EngineType.ToLower() == eEngineType.Electricy.ToString().ToLower() ? eVehicleType.ElectricCar : eVehicleType.FuelCar;
                case "truck":
                    return eVehicleType.FuelTruck;
                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
        }

        public bool CheckIfCarExistInGarage(string i_Car)
        {
            bool isCarExistInGarage = false;

            foreach (var existingCar in m_Vehicles)
            {
                string currentCarPlateNumber = existingCar.m_Vechile.GetPlateNumber();
                
                if (currentCarPlateNumber.Equals(i_Car))
                {
                    isCarExistInGarage = true;
                    break;
                }
            }

            return isCarExistInGarage;
        }

        public IList<string> GetListOFVwhicleByFilter(string i_Filter)
        {
            IList<string> filteredPlateNumbers = new List<string>();

            eState filterState;

            if (!Enum.TryParse<eState>(i_Filter, true, out filterState))
            {
                throw new ArgumentException($"Invalid filter option: {i_Filter}");
            }

            foreach (var vehicle in m_Vehicles)
            {
                if (vehicle.m_State == filterState)
                {
                    filteredPlateNumbers.Add(vehicle.m_Vechile.GetPlateNumber());
                }
            }

            return filteredPlateNumbers;
        }

        public void ChangeVehicleState(string i_PlateNumber, eState i_NewState)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            vehicle.m_State = i_NewState;   
        }

        public void InflateWheelsToMax(string i_PlateNumber)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            IList<Wheel> wheels = vehicle.m_Vechile.GetWheels();

            foreach (var wheel in wheels)
            {
                wheel.InflateWheelToMAx();
            }
        }

        private AddressCard getVehicleByPlateNumber(string i_PlateNumber)
        {
            AddressCard vehicle = m_Vehicles
                .FirstOrDefault(v => v.m_Vechile.GetPlateNumber().Equals(i_PlateNumber, StringComparison.OrdinalIgnoreCase));

            if (vehicle == null)
            {
                throw new ArgumentException($"No vehicle with plate number {i_PlateNumber} found in the garage.");
            }

            return vehicle;
        }

        public bool FuelAmountExeesFromTheMax(string i_PlateNumber, float i_FuelAmount)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            
            return vehicle.m_Vechile.IsCurrentVecileIsTypeOfSameEnergyEngine(i_FuelAmount);
        }

        public void SetNewEnergyAmount(string i_PlateNumber, float i_FuelAmount)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            vehicle.m_Vechile.SetCurrentVehicle(i_FuelAmount);
        }

        public void IsFuelDrive(string i_PlateNumber)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            vehicle.m_Vechile.IsFuelDrive();
        }

        public float GetTankCapacity(string i_PlateNumber)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            return vehicle.m_Vechile.GetMaxEnergy();
        }

        public void IsElectricDrive(string i_PlateNumber)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            vehicle.m_Vechile.IsElectricDrive();
        }

        public bool SameFuelInTheCurrentTank(string i_PlateNumber, string i_FuelType)
        {
            AddressCard vehicle = getVehicleByPlateNumber(i_PlateNumber);
            eEngineType engineType = getEngineType(i_FuelType);
            
            if (vehicle.m_Vechile.GetFuelType() == engineType)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("Fuel type does not match.");
            }
        }

        private eEngineType getEngineType(string i_FuelType)
        {
            if (Enum.TryParse<eEngineType>(i_FuelType, true, out eEngineType fuelType))
            {
                return fuelType;
            }
            else
            {
                throw new ArgumentException("Invalid fuel type specified.");
            }
        }

        public (VehicleDto,string) GetDataByPlateNumber(string i_PlateNumber)
        {
            string type = "";
            AddressCard addressCard = getVehicleByPlateNumber(i_PlateNumber);

            var vehicleDto = new VehicleDto.VehicleDtoBuilder()
                .SetPlateNumber(i_PlateNumber)
                .SetOwnerName(addressCard.m_OwnerName).SetOwnerPhone(addressCard.m_OwnerPhone)
                .SetModelName(addressCard.m_Vechile.GetModelName())
                .SetWheelsData(convertWheelsToDto(addressCard.m_Vechile.GetWheels()))
                .SetFuelType(addressCard.m_Vechile.GetFuelType().ToString())
                .SetStatusInGarage(addressCard.m_State.ToString())
                .SetCapacityEnergy(addressCard.m_Vechile.GetMaxEnergy())
                .SetCurrentEnergy(addressCard.m_Vechile.GetCurrentEnergy());
            
            if (addressCard.m_Vechile.IsCar())
            {
                Car car = addressCard.m_Vechile as Car;
                type = "car";
                vehicleDto
                    .SetColor(car.GetColor())
                    .SetNumbersOfDoors(int.Parse(car.GetNumberOfDoors()));

            }
            else if (addressCard.m_Vechile.IsMotorcycle())
            {
                Motorcycle motorcycle = addressCard.m_Vechile as Motorcycle;
                type = "motorcycle";
                vehicleDto
                    .SetLicenseType(motorcycle.GetLicenseType())
                    .SetEngineCapacity(motorcycle.GetEngineCapacity());
            }
            else
            {
                Truck truck = addressCard.m_Vechile as Truck;
                type = "truck";
                vehicleDto
                    .SetIsTransportDangerous(truck.IsTransportDangerous())
                    .SetTransportCapacity(truck.TransportCapacity());
            }

            return (vehicleDto.Build(), type);
        }

        private IList<WheelDto> convertWheelsToDto(IList<Wheel> wheels)
        {
            IList<WheelDto> wheelDtos = new List<WheelDto>();

            foreach (var wheel in wheels)
            {
                WheelDto wheelDto = new WheelDto
                {
                    ManufacturerName = wheel.GetManufacturerName(),
                    MaxAirPressure = wheel.GetMaxAirPressure(),
                    CurrentAirPressure = wheel.GetCurrentAirPressure()
                };
                wheelDtos.Add(wheelDto);
            }

            return wheelDtos;
        }
    }
}
