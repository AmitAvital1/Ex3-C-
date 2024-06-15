using Ex03.GarageLogic.Entities.Vehicles;
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
                    return i_EngineType.ToLower() == "electric" ? eVehicleType.ElectricMotorcycle : eVehicleType.FuelMotorcycle;
                case "car":
                    return i_EngineType.ToLower() == "electric" ? eVehicleType.ElectricCar : eVehicleType.FuelCar;
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
                
                if ( currentCarPlateNumber.Equals(i_Car))
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
            return true;
        }

        public void SetNewFuelAmount(string i_PlateNumber, float i_FuelAmount)
        {

        }
    }
}
