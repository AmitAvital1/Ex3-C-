using System;

namespace Ex03.GarageLogic.Entities.Engine
{
    public class FuelEngine : AbstractEngine
    {
        private float m_CurrentFuel;
        private readonly float r_MaxFuel; //In Liters

        public FuelEngine(float i_MaxFuel, string i_FuelType)
        {
            bool IsValidFuelType = Enum.TryParse<eEngineType>(i_FuelType, true, out m_FuelType);

            if (!IsValidFuelType)
            {
                throw new ArgumentException($"Fuel type '{i_FuelType}' invalid.");
            }

            if(i_MaxFuel < 0)
            {
                throw new ArgumentException($"Max Fuel '{i_MaxFuel}' invalid.");
            }

            r_MaxFuel = i_MaxFuel;
            m_CurrentFuel = i_MaxFuel / 2;
        }

        public override float Energy()
        {
            throw new System.NotImplementedException();
        }

        public override float MaxEnergy()
        {
            throw new System.NotImplementedException();
        }

        public override void AddEnergy(float i_EnergyUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}
