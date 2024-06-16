using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;
using Ex03.GarageLogic.Factory.Dto;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportDangerous;
        private float m_TransportCapacity;

        internal Truck(bool i_IsTransportDangerous, float i_TransportCapacity, AbstractEngine i_Engine, 
            string i_ModelName, string i_PlateNumber, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_Wheels)
        {
            if (m_TransportCapacity < 0)
            {
                throw new FormatException("Transport capacity invalid.");
            }

            m_IsTransportDangerous = i_IsTransportDangerous;
            m_TransportCapacity = i_TransportCapacity;
        }

        public bool IsTransportDangerous()
        {
            return m_IsTransportDangerous;
        }

        public float TransportCapacity()
        {
            return m_TransportCapacity;
        }

        public class TruckBuilder
        {
            private bool m_IsTransportDangerous;
            private float m_TransportCapacity;
            private AbstractEngine m_Engine;
            private string m_ModelName;
            private string m_PlateNumber;
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

            public TruckBuilder SetWheels(IList<WheelDto> i_WheelsDetails)
            {
                IList<Wheel> wheels = new List<Wheel>();

                foreach (WheelDto wheel in i_WheelsDetails)
                {
                    wheels.Add(new Wheel(wheel.ManufacturerName, wheel.CurrentAirPressure, Constants.sr_TruckMaxWheelsPressure));
                }
                m_Wheels = wheels;

                return this;
            }

            public Truck Build()
            {
                return new Truck(m_IsTransportDangerous, m_TransportCapacity, m_Engine, m_ModelName, m_PlateNumber, m_Wheels);
            }
        }
    }
}
