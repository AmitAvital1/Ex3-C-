namespace Ex03.GarageLogic.Entities.Engine
{
    public class ElectricEngine : AbstractEngine
    {
        private float m_CurrentElectricy;
        private readonly float r_MaxElectricy; //In Hours


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
