using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Factory.Dto
{
    public class VehicleDto
    {
        public string Type { get; set; }
        public string ModelName { get; set; }
        public string LicenseType { get; set; }
        public int EngineCapacity { get; set; }
        public string EngineType { get; set; }
        public string FuelType { get; set; }
        public float CapacityEnergy { get; set; }
        public string Color { get; set; }
        public int NumberOfDoors { get; set; }
        public float CurrentEnergy { get; set; }
        public bool IsTransportDangerous { get; set; }
        public float TransportCapacity { get; set; }
        public string PlateNumber { get; set; }
        public IList<WheelDto> WheelsData { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public bool DangerousPack { get; set; }
        public string StatusInGarage { get; set; }

        public class VehicleDtoBuilder
        {
            private string m_ModelName;
            private string m_Type;
            private string m_LicenseType;
            private int m_EngineCapacity;
            private string m_EngineType;
            private string m_FuelType;
            private float m_CapacityEnergy;
            private string m_Color;
            private int m_NumberOfDoors;
            private float m_CurrentEnergy;
            private bool m_IsTransportDangerous;
            private float m_TransportCapacity;
            private string m_PlateNumber;
            private IList<WheelDto> m_WheelsData;
            private string m_OwnerName;
            private string m_OwnerPhone;
            private string m_StatusInGarage;

            public VehicleDtoBuilder SetCurrentEnergy(float i_CurrentEnergy)
            {
                this.m_CurrentEnergy = i_CurrentEnergy;
                return this;
            }
            public VehicleDtoBuilder SetModelName(string i_ModelName)
            {
                this.m_ModelName = i_ModelName;
                return this;
            }

            public VehicleDtoBuilder SetOwnerName(string i_OwnerName)
            {
                this.m_OwnerName = i_OwnerName;
                return this;
            }

            public VehicleDtoBuilder SetOwnerPhone(string i_OwnerPhone)
            {
                this.m_OwnerPhone = i_OwnerPhone;
                return this;
            }

            public VehicleDtoBuilder SetWheelsData(IList<WheelDto> i_WheelsData)
            {
                this.m_WheelsData = i_WheelsData;
                return this;
            }

            public VehicleDtoBuilder SetPlateNumber(string i_PlateNumber)
            {
                this.m_PlateNumber = i_PlateNumber;
                return this;
            }

            public VehicleDtoBuilder SetTransportCapacity(float i_TransportCapacity)
            {
                this.m_TransportCapacity = i_TransportCapacity;
                return this;
            }

            public VehicleDtoBuilder SetIsTransportDangerous(bool i_IsTransportDangerous)
            {
                this.m_IsTransportDangerous = i_IsTransportDangerous;
                return this;
            }

            public VehicleDtoBuilder SetType(string i_Type)
            {
                this.m_Type = i_Type;
                return this;
            }

            public VehicleDtoBuilder SetNumbersOfDoors(int i_NumberOfDoors)
            {
                this.m_NumberOfDoors = i_NumberOfDoors;
                return this;
            }

            public VehicleDtoBuilder SetCapacityEnergy(float i_CapacityEnergy)
            {
                this.m_CapacityEnergy = i_CapacityEnergy;
                return this;
            }

            public VehicleDtoBuilder SetColor(string i_Color)
            {
                this.m_Color = i_Color;
                return this;
            }

            public VehicleDtoBuilder SetLicenseType(string i_LicenseType)
            {
                this.m_LicenseType = i_LicenseType;
                return this;
            }

            public VehicleDtoBuilder SetFuelType(string i_FuelType)
            {
                this.m_FuelType = i_FuelType;
                return this;
            }

            public VehicleDtoBuilder SetEngineCapacity(int i_EngineCapacity)
            {
                this.m_EngineCapacity = i_EngineCapacity;
                return this;
            }

            public VehicleDtoBuilder SetEngineType(string i_EngineType)
            {
                this.m_EngineType = i_EngineType;
                return this;
            }

            public VehicleDtoBuilder SetStatusInGarage(string  i_StatusInGarage) 
            { 
                this.m_StatusInGarage = i_StatusInGarage;
                return this;
            }

            public VehicleDto Build()
            {
                return new VehicleDto
                {
                    Type = this.m_Type,
                    ModelName = this.m_ModelName,
                    LicenseType = this.m_LicenseType,
                    EngineCapacity = this.m_EngineCapacity,
                    EngineType = this.m_EngineType,
                    CapacityEnergy = this.m_CapacityEnergy,
                    FuelType = this.m_FuelType,
                    Color = this.m_Color,
                    NumberOfDoors = this.m_NumberOfDoors,
                    CurrentEnergy = this.m_CurrentEnergy,
                    IsTransportDangerous = this.m_IsTransportDangerous,
                    TransportCapacity = this.m_TransportCapacity,
                    PlateNumber = this.m_PlateNumber,
                    WheelsData = this.m_WheelsData,
                    OwnerName = this.m_OwnerName,
                    OwnerPhone = this.m_OwnerPhone,
                    StatusInGarage = this.m_StatusInGarage
                };
            }
        }
    }

}
