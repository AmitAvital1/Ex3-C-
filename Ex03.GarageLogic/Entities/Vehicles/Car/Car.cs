using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;

namespace Ex03.GarageLogic.Entities.Vehicles.Car
{
    public class Car : Vehicle
    {
        private readonly eCarColor m_Color;
        private readonly eCarDoors m_NumOfDoors;

        internal Car(string i_Color, int m_NumOfDoors, AbstractEngine i_Engine, string i_ModelName, string i_PlateNumber, string i_EnergyVolume, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_EnergyVolume, i_Wheels)
        {
            bool IsValidColor = Enum.TryParse<eCarColor>(i_Color, true, out m_Color);
            bool IsValidDoorsNum = Enum.IsDefined(typeof(eCarDoors), m_NumOfDoors);

            if(!IsValidColor)
            {
                throw new ArgumentException($"Color '{i_Color}' invalid.");
            }
            if (!IsValidDoorsNum)
            {
                throw new ArgumentException($"Num of doors '{i_Color}' invalid.");
            }
        }
    }
}
