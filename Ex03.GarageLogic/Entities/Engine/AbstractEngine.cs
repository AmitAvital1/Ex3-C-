namespace Ex03.GarageLogic.Entities.Engine
{
    public abstract class AbstractEngine
    {
        protected eEngineType m_FuelType;

        public AbstractEngine(eEngineType i_FuelType)
        {
            this.m_FuelType = i_FuelType;
        }

        public string FuelType()
        {
            return m_FuelType.ToString();
        }

        public abstract float Energy();
        
        public abstract float MaxEnergy();
        
        public abstract void AddEnergy(float i_EnergyUnit);
        
        public eEngineType GetFuelType()
        {
            return m_FuelType;
        }
    }
}
