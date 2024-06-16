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
        protected abstract void SetEnergy(float i_EnergyUnit);

        public void AddMaxTankIfNeeded(float i_EnergyUnit)
        {
            if(Energy() + i_EnergyUnit > MaxEnergy())
            {
                SetEnergy(MaxEnergy());
            }
            else
            {
                SetEnergy(i_EnergyUnit + Energy());
            }
        }
        
        public eEngineType GetFuelType()
        {
            return m_FuelType;
        }
    }
}
