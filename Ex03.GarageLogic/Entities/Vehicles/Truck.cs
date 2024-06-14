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

        internal Truck(bool i_IsTransportDangerous, float i_TransportCapacity, AbstractEngine i_Engine, string i_ModelName, string i_PlateNumber, string i_EnergyVolume, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_EnergyVolume, i_Wheels)
        {
            m_IsTransportDangerous = i_IsTransportDangerous;
            m_TransportCapacity = i_TransportCapacity;
        }
    }
}
