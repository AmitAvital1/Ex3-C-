using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;

namespace Ex03.GarageLogic.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportDangerous;
        private float m_TransportCapacity;

        internal Truck(bool i_IsTransportDangerous, float i_TransportCapacity, AbstractEngine i_Engine, 
            string i_ModelName, string i_PlateNumber, string i_EnergyVolume, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_EnergyVolume, i_Wheels)
        {
            m_IsTransportDangerous = i_IsTransportDangerous;
            m_TransportCapacity = i_TransportCapacity;
        }

        public class TruckBuilder
        {
            private bool m_IsTransportDangerous;
            private float m_TransportCapacity;
            private AbstractEngine m_Engine;
            private string m_ModelName;
            private string m_PlateNumber;
            private string m_EnergyVolume;
            private IList<Wheel> m_Wheels;

            public TruckBuilder SetIsTransportDangerous(bool i_IsTransportDangerous)
            {
                m_IsTransportDangerous = i_IsTransportDangerous;
                return this;
            }

            public TruckBuilder SetTransportCapacity(float i_TransportCapacity)
            {
                m_TransportCapacity = i_TransportCapacity;
                return this;
            }

            public TruckBuilder SetEngine(AbstractEngine i_Engine)
            {
                m_Engine = i_Engine;
                return this;
            }

            public TruckBuilder SetModelName(string i_ModelName)
            {
                m_ModelName = i_ModelName;
                return this;
            }

            public TruckBuilder SetPlateNumber(string i_PlateNumber)
            {
                m_PlateNumber = i_PlateNumber;
                return this;
            }

            public TruckBuilder SetEnergyVolume(string i_EnergyVolume)
            {
                m_EnergyVolume = i_EnergyVolume;
                return this;
            }

            public TruckBuilder SetWheels(IList<Wheel> i_Wheels)
            {
                m_Wheels = i_Wheels;
                return this;
            }

            public Truck Build()
            {
                return new Truck(m_IsTransportDangerous, m_TransportCapacity, m_Engine, m_ModelName, m_PlateNumber, m_EnergyVolume, m_Wheels);
            }
        }
    }
}
