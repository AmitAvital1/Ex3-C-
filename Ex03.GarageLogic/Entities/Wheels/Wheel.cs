using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Exception;

namespace Ex03.GarageLogic.Entities.Wheels
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            if (i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("Error: Current pressure bigger then max air pressure");
            }

            this.r_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        
        public void InflateWheelToMAx()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public string GetManufacturerName()
        {
            return r_ManufacturerName;
        }

        public float GetMaxAirPressure()
        {
            return m_MaxAirPressure;
        }

        public float GetCurrentAirPressure()
        {
            return m_CurrentAirPressure;
        }

    }
}
