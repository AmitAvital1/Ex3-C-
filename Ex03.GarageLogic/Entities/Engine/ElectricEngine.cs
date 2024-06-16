using System;

namespace Ex03.GarageLogic.Entities.Engine
{
    public class ElectricEngine : AbstractEngine
    {
        private float m_CurrentElectricy;
        private readonly float r_MaxElectricy; //In Hours
        
        public ElectricEngine(eEngineType i_FuelType, float i_CurrentElectricy, float i_MaxElectricy) : base(i_FuelType)
        {
            if (i_MaxElectricy < 0)
            {
                throw new ArgumentException($"Max Electricy '{i_MaxElectricy}' invalid.");
            }

            if (i_CurrentElectricy < 0 || i_CurrentElectricy > i_MaxElectricy)
            {
                throw new ArgumentException($"Current Electricy '{i_CurrentElectricy}' invalid.");
            }

            r_MaxElectricy = i_MaxElectricy;
            r_MaxElectricy = i_CurrentElectricy;
        }
        public override float Energy()
        {
           return m_CurrentElectricy;
        }

        public override float MaxEnergy()
        {
            return r_MaxElectricy;
        }

        protected override void SetEnergy(float i_EnergyUnit)
        {
            m_CurrentElectricy = i_EnergyUnit;
        }
    }
}
