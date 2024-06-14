namespace Ex03.GarageLogic.Entities.Engine
{
    public abstract class AbstractEngine
    {
        protected readonly eEngineType m_FuelType;
        public string FuelType()
        {
            return m_FuelType.ToString();
        }

        public abstract float Energy();
        public abstract float MaxEnergy();
        public abstract void AddEnergy(float i_EnergyUnit);
    }
}
