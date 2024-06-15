using System;

namespace Ex03.GarageLogic.Entities.Engine
{
    public class FuelEngine : AbstractEngine
    {
        private float m_CurrentFuel;
        private readonly float r_MaxFuel; //In Liters

        public FuelEngine(eEngineType i_FuelType, float i_CurrentFuel, float i_MaxFuel) : base(i_FuelType)
        {
            if (i_MaxFuel < 0)
            {
                throw new ArgumentException($"Max Fuel '{i_MaxFuel}' invalid.");
            }

            if (i_CurrentFuel < 0 || i_CurrentFuel > i_MaxFuel)
            {
                throw new ArgumentException($"Current Fuel '{i_CurrentFuel}' invalid.");
            }

            r_MaxFuel = i_MaxFuel;
            m_CurrentFuel = i_CurrentFuel;
        }

        public override float Energy()
        {
            return m_CurrentFuel;
        }

        public override float MaxEnergy()
        {
            return r_MaxFuel;
        }

        public override void AddEnergy(float i_EnergyUnit)
        {
            m_CurrentFuel = i_EnergyUnit;
        }
    }
}
