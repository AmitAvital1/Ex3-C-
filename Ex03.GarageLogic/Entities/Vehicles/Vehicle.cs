using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;

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

        public eEngineType GetFuelType()
        {
            return r_Engine.GetFuelType();
        }

        public bool IsCurrentVecileIsTypeOfSameEnergyEngine(float i_FuelAmount)
        {
            return checkIfCurrentVecileIsTypeOfSameEnergyEngine(r_Engine, i_FuelAmount);
        }

        private bool checkIfCurrentVecileIsTypeOfSameEnergyEngine<T>(T i_Engine, float i_EnergyAmount) where T : AbstractEngine
        {
            if (i_Engine is FuelEngine fuelEngine)
            {
                fuelEngine.AddEnergy(i_EnergyAmount);
                
                if (fuelEngine.MaxEnergy() >= i_EnergyAmount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (i_Engine is ElectricEngine electricEngine)
            {
                i_Engine.AddEnergy(i_EnergyAmount);

                if (electricEngine.MaxEnergy() >= i_EnergyAmount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                isEngineNotAFuelEngine();
                return false;
            }
        }

        public void SetCurrentVehcile(float i_FuelAmount)
        {
            setCurrentVehcileGenerics(r_Engine, i_FuelAmount);
        }

        private void setCurrentVehcileGenerics<T>(T i_Engine, float i_EnergyAmount) where T : AbstractEngine
        {
            if (i_Engine is FuelEngine fuelEngine)
            {
                fuelEngine.AddEnergy(i_EnergyAmount);
            }
            else if (i_Engine is ElectricEngine electricEngine)
            {
                i_Engine.AddEnergy(i_EnergyAmount);
            }
            else
            {
                isEngineNotAFuelEngine();
            }
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
    }
}
