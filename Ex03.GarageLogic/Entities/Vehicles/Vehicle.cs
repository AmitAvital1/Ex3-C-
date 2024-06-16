using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;
using Ex03.GarageLogic.Entities.Vehicles.CarHandler;
using Ex03.GarageLogic.Entities.Vehicles.MotorcycleHandler;

namespace Ex03.GarageLogic.Entities.Vehicles
{
    public abstract class Vehicle
    {
        protected readonly AbstractEngine r_Engine;
        protected readonly string r_ModelName;
        protected readonly string r_PlateNumber;
        protected float m_EnergyVolume;
        protected IList<Wheel> m_Wheels;

        protected Vehicle(AbstractEngine i_Engine, string i_ModelName, string i_PlateNumber, IList<Wheel> i_Wheels)
        {
            r_Engine = i_Engine ?? throw new ArgumentNullException(nameof(i_Engine));
            r_ModelName = i_ModelName ?? throw new ArgumentNullException(nameof(i_ModelName));
            r_PlateNumber = i_PlateNumber ?? throw new ArgumentNullException(nameof(i_PlateNumber));
            m_EnergyVolume = i_Engine.Energy();
            m_Wheels = i_Wheels ?? throw new ArgumentNullException(nameof(i_Wheels));
        }

        public string GetModelName()
        {
            return r_ModelName;
        }

        public string GetPlateNumber()
        {
            return r_PlateNumber;
        }

        public IList<Wheel> GetWheels()
        {
            return m_Wheels;
        }

        public bool IsCar()
        {
            return this is Car;
        }

        public bool IsMotorcycle()
        {
            return this is Motorcycle;
        }

        public eEngineType GetFuelType()
        {
            return r_Engine.GetFuelType();
        }

        public bool IsCurrentVecileIsTypeOfSameEnergyEngine(float i_EnergyAmount)
        {       
            if (r_Engine.MaxEnergy() >= i_EnergyAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetCurrentVehicle(float i_EnergyAmount)
        {
            r_Engine.AddMaxTankIfNeeded(i_EnergyAmount);
        }

        public void IsFuelDrive()
        {
            FuelEngine fuelEngine = r_Engine as FuelEngine;

            if (fuelEngine == null)
            {
                isEngineNotAFuelEngine();
            }
        }

        public void IsElectricDrive()
        {
            ElectricEngine electricEngine = r_Engine as ElectricEngine;

            if (electricEngine == null)
            {
                isEngineNotAElectricEngine();
            }
        }

        private void isEngineNotAFuelEngine()
        {
            throw new InvalidOperationException("Vehicle engine is not a FuelEngine.");
        }

        private void isEngineNotAElectricEngine()
        {
            throw new InvalidOperationException("Vehicle engine is not a ElectricEngine.");
        }

        public float GetCurrentEnergy()
        {
            return r_Engine.Energy();
        }

        public float GetMaxEnergy()
        {
            return r_Engine.MaxEnergy();
        }
    }
}
