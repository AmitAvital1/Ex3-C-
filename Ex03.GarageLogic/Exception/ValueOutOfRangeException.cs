namespace Ex03.GarageLogic.Exception
{
    public class ValueOutOfRangeException : System.Exception
    {
        private float MaxValue;
        private float MinValue;
        private string RelevantCriterionInput;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_RelevantCriterionInput)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
            RelevantCriterionInput = i_RelevantCriterionInput;
        }

        public override string Message
        {
            get
            {
                return string.Format("Value is out of range. {0} value should be between {1} to {2}",
                    RelevantCriterionInput, MinValue, MaxValue);
            }
        }
    }
}