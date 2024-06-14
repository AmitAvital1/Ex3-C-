using System;

namespace Ex03.GarageLogic.Entities.Engine
{
    public class ElectricEngine : AbstractEngine
    {
        private float m_CurrentElectricy;
        private readonly float r_MaxElectricy; //In Hours

        public ElectricEngine(float i_MaxElectricy)
        {
            if (i_MaxElectricy < 0)
            {
                throw new ArgumentException($"Max Fuel '{i_MaxElectricy}' invalid.");
            }

            r_MaxElectricy = i_MaxElectricy;
            r_MaxElectricy = i_MaxElectricy / 2;
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
