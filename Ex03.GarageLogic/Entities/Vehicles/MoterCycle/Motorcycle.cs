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

        internal Motorcycle(string i_LicenseType, int i_EngineCapacity, AbstractEngine i_Engine, string i_ModelName, string i_PlateNumber, string i_EnergyVolume, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_EnergyVolume, i_Wheels)
        {
            bool IsValidLicenseType = Enum.TryParse<eLicenseType>(i_LicenseType, true, out m_LicenseType);

            if (!IsValidLicenseType)
            {
                throw new ArgumentException($"License Type '{i_LicenseType}' invalid.");
            }
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
