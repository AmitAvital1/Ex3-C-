namespace Ex03.GarageLogic.Entities.Engine
{
    public class FuelEngine : AbstractEngine
    {
        private float m_CurrentFuel;
        private readonly float r_MaxFuel; //In Liters

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
