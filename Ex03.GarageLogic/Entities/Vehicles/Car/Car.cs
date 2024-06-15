using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Entities.Engine;
using Ex03.GarageLogic.Entities.Wheels;
using Ex03.GarageLogic.Factory.Dto;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Entities.Vehicles.Car
{
    public class Car : Vehicle
    {
        private readonly eCarColor m_Color;
        private readonly eCarDoors m_NumOfDoors;

        internal Car(string i_Color, int i_NumOfDoors, AbstractEngine i_Engine, string i_ModelName, 
            string i_PlateNumber, IList<Wheel> i_Wheels)
            : base(i_Engine, i_ModelName, i_PlateNumber, i_Wheels)
        {
            bool IsValidColor = Enum.TryParse<eCarColor>(i_Color, true, out m_Color);
            bool IsValidDoorsNum = Enum.IsDefined(typeof(eCarDoors), i_NumOfDoors);

            if (!IsValidColor)
            {
                throw new FormatException($"Color '{i_Color}' invalid.");
            }
            if (!IsValidDoorsNum)
            {
                throw new FormatException($"Num of doors '{i_NumOfDoors}' invalid.");
            }
        }

        public class CarBuilder
        {
            private string m_Color;
            private int m_NumOfDoors;
            private AbstractEngine m_Engine;
            private string m_ModelName;
            private string m_PlateNumber;
            private IList<Wheel> m_Wheels;

            public CarBuilder SetColor(string i_Color)
            {
                m_Color = i_Color;
                return this;
            }

            public CarBuilder SetNumOfDoors(int i_NumOfDoors)
            {
                m_NumOfDoors = i_NumOfDoors;
                return this;
            }

            public CarBuilder SetEngine(AbstractEngine i_Engine)
            {
                m_Engine = i_Engine;
                return this;
            }

            public CarBuilder SetModelName(string i_ModelName)
            {
                m_ModelName = i_ModelName;
                return this;
            }

            public CarBuilder SetPlateNumber(string i_PlateNumber)
            {
                m_PlateNumber = i_PlateNumber;
                return this;
            }

            public CarBuilder SetWheels(IList<WheelDto> i_WheelsDetails)
            {
                IList<Wheel> wheels = new List<Wheel>();

                foreach(WheelDto wheel in i_WheelsDetails)
                {
                    wheels.Add(new Wheel(wheel.ManufacturerName, wheel.CurrentAirPressure, Constants.sr_CarMaxWheelsPressure));
                }

                m_Wheels = wheels;
                return this;
            }

            public Car Build()
            {
                return new Car(m_Color, m_NumOfDoors, m_Engine, m_ModelName, m_PlateNumber, m_Wheels);
            }
        }
    }
}
