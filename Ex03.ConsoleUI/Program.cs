using Ex03.ConsoleUI.GarageManagerHandler;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main() 
        {
            run();
        }

        private static void run()
        {
            GarageManager garageManager = new GarageManager();
            garageManager.ActivateGarage();
        }
    }
}
