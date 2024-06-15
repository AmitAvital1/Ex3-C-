using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;

namespace Ex03.GarageLogic.Entities.Vehicles
{
    public abstract class Vehicle
    {
        protected readonly AbstractEngine r_Engine;
        protected readonly string r_ModelName;
        protected readonly string r_PlateNumber;
        protected float m_EnergyVolume;
        protected IList<Wheel> m_Wheels;

        protected Vehicle(AbstractEngine i_Engine, string i_ModelName, string i_PlateNumber, IList<Wheel> i_Wheels)
        {
            r_Engine = i_Engine ?? throw new ArgumentNullException(nameof(i_Engine));
            r_ModelName = i_ModelName ?? throw new ArgumentNullException(nameof(i_ModelName));
            r_PlateNumber = i_PlateNumber ?? throw new ArgumentNullException(nameof(i_PlateNumber));
            m_EnergyVolume = i_Engine.Energy();
            m_Wheels = i_Wheels ?? throw new ArgumentNullException(nameof(i_Wheels));
        }

        public string GetModelName()
        {
            return r_ModelName;
        }

        public string GetPlateNumber()
        {
            return r_PlateNumber;
        }

        public IList<Wheel> GetWheels()
        {
            return m_Wheels;
        }
    }
}
