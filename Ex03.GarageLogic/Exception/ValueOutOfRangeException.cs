namespace Ex03.GarageLogic.Exception
{
    public class ValueOutOfRangeException : System.Exception
    {
        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string message)
            : base(message)
        {
        }

        public ValueOutOfRangeException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}