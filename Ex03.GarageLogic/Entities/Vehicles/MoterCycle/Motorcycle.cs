using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Vehicles.Car;
using Ex03.GarageLogic.Entities.Wheels;

namespace Ex03.GarageLogic.Entities.Vehicles.Motorcycle
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        internal Motorcycle(string i_LicenseType, int i_EngineCapacity, AbstractEngine i_Engine, string i_ModelName, 
            string i_PlateNumber, string i_EnergyVolume, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_EnergyVolume, i_Wheels)
        {
            bool IsValidLicenseType = Enum.TryParse<eLicenseType>(i_LicenseType, true, out m_LicenseType);

            if (!IsValidLicenseType)
            {
                throw new ArgumentException($"License Type '{i_LicenseType}' invalid.");
            }

            m_EngineCapacity = i_EngineCapacity;
        }

        public class MotorcycleBuilder
        {
            private string m_LicenseType;
            private int m_EngineCapacity;
            private AbstractEngine m_Engine;
            private string m_ModelName;
            private string m_PlateNumber;
            private string m_EnergyVolume;
            private IList<Wheel> m_Wheels;

            public MotorcycleBuilder SetLicenseType(string i_LicenseType)
            {
                m_LicenseType = i_LicenseType;
                return this;
            }

            public MotorcycleBuilder SetEngineCapacity(int i_EngineCapacity)
            {
                m_EngineCapacity = i_EngineCapacity;
                return this;
            }

            public MotorcycleBuilder SetEngine(AbstractEngine i_Engine)
            {
                m_Engine = i_Engine;
                return this;
            }

            public MotorcycleBuilder SetModelName(string i_ModelName)
            {
                m_ModelName = i_ModelName;
                return this;
            }

            public MotorcycleBuilder SetPlateNumber(string i_PlateNumber)
            {
                m_PlateNumber = i_PlateNumber;
                return this;
            }

            public MotorcycleBuilder SetEnergyVolume(string i_EnergyVolume)
            {
                m_EnergyVolume = i_EnergyVolume;
                return this;
            }

            public MotorcycleBuilder SetWheels(IList<Wheel> i_Eheels)
            {
                m_Wheels = i_Eheels;
                return this;
            }

            public Motorcycle Build()
            {
                return new Motorcycle(m_LicenseType, m_EngineCapacity, m_Engine, m_ModelName, m_PlateNumber, m_EnergyVolume, m_Wheels);
            }
        }
    }
}
