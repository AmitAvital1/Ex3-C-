using System.Collections.Generic;
using Ex03.GarageLogic.Factory.Dto;

namespace Ex03.ConsoleUI.VehicleDataHandler
{
    public class VehicleData
    {
        public string ModelName { get; set; }
        public int VehicleType { get; set; }
        public bool IsFuel { get; set; }
        public float EnergyMaxTank { get; set; }
        public float EnergyStatus { get; set; }
        public IList<WheelDto> WheelsData { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
    }
}
