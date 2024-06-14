using System;

namespace Ex03.GarageLogic.Entities.Engine
{
    public class FuelEngine : AbstractEngine
    {
        private float m_CurrentFuel;
        private readonly float m_MaxFuel; //In Liters

        public FuelEngine(float i_CurrentFuel, float i_MaxFuel, string i_FuelType)
        {
            bool IsValidFuelType = Enum.TryParse<eEngineType>(i_FuelType, true, out base.m_FuelType);
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
