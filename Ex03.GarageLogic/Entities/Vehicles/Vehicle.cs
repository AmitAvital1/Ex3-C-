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
        protected string m_EnergyVolume;
        protected IList<Wheel> m_Wheels;


    }
}
