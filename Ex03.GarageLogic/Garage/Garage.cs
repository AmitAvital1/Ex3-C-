using Ex03.GarageLogic.Entities.Vehicles;
using Ex03.GarageLogic.Factory;
using Ex03.GarageLogic.Factory.Dto;
using System;
using System.Collections.Generic;

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
                    return i_EngineType.ToLower() == "electric" ? eVehicleType.ElectricTruck : eVehicleType.FuelTruck;
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
                    // Car already exists, change its state to "Repair"
                    existingCar.m_State = eState.Repair;
                    isCarExistInGarage = true;
                    break;
                }
            }

            return isCarExistInGarage;
        }

        public IList<string> GetListOFVwhicleByFilter(string i_Filter)
        {
            return null;
        }
    }
}
