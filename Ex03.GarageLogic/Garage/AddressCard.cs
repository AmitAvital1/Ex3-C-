using Ex03.GarageLogic.Entities.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class AddressCard
    {
        private readonly Vehicle m_Vechile;
        public string m_OwnerName { get; set; }
        public string m_OwnerPhone { get; set; }
        public eState m_State { get; set; }

        public Vehicle GetVehicle()
        {
            return m_Vechile;
        }
    }
}
