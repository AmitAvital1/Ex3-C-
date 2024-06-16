using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;
using Ex03.GarageLogic.Factory.Dto;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Entities.Vehicles.MotorcycleHandler
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        internal Motorcycle(string i_LicenseType, int i_EngineCapacity, AbstractEngine i_Engine, string i_ModelName, 
            string i_PlateNumber, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_Wheels)
        {
            bool IsValidLicenseType = Enum.TryParse<eLicenseType>(i_LicenseType, true, out m_LicenseType);

            if (!IsValidLicenseType)
            {
                throw new ArgumentException($"License Type '{i_LicenseType}' invalid.");
            }

            m_EngineCapacity = i_EngineCapacity;
        }

        public string GetLicenseType()
        {
            return m_LicenseType.ToString();
        }

        public int GetEngineCapacity()
        {
            return m_EngineCapacity;
        }

        public class MotorcycleBuilder
        {
            private string m_LicenseType;
            private int m_EngineCapacity;
            private AbstractEngine m_Engine;
            private string m_ModelName;
            private string m_PlateNumber;
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

            public MotorcycleBuilder SetWheels(IList<WheelDto> i_WheelsDetails)
            {
                IList<Wheel> wheels = new List<Wheel>();

                foreach (WheelDto wheel in i_WheelsDetails)
                {
                    wheels.Add(new Wheel(wheel.ManufacturerName, wheel.CurrentAirPressure, Constants.sr_MotorcycleMaxWheelsPressure));
                }
                m_Wheels = wheels;

                return this;
            }

            public Motorcycle Build()
            {
                return new Motorcycle(m_LicenseType, m_EngineCapacity, m_Engine, m_ModelName, m_PlateNumber, m_Wheels);
            }
        }
    }
}
