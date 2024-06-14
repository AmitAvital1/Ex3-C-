using System.Collections.Generic;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private IList<AddressCard> m_Cars;

        public Garage()
        {
            m_Cars = new List<AddressCard>();
        }

        public void AddCar(AddressCard i_Car)
        {
            foreach (var existingCar in m_Cars)
            {
                if (existingCar.m_OwnerName == i_Car.m_OwnerName && existingCar.m_OwnerPhone == i_Car.m_OwnerPhone)
                {
                    // Car already exists, change its state to "Repair"
                    existingCar.m_State = eState.Repair;
                    return;
                }
            }

            // Car doesn't exist, add it to the garage
            m_Cars.Add(i_Car);
        }
    }
}
