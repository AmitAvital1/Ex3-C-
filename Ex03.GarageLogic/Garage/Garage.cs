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

        public void AddVehicles(AddressCard i_Car)
        {
            m_Cars.Add(i_Car);
        }

        public bool CheckIfCarExistInGarage(string i_Car)
        {
            bool isCarExistInGarage = false;

            foreach (var existingCar in m_Cars)
            {
                string currentCarPlateNumber = existingCar.GetVehicle().GetPlateNumber();
                if ( currentCarPlateNumber.Equals(i_Car))
                {
                    // Car already exists, change its state to "Repair"
                    existingCar.m_State = eState.Repair;
                    isCarExistInGarage = true;
                    break;
                }
            }

            return isCarExistInGarage;
        }
    }
}
