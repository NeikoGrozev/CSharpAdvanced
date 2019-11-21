namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int result = Convert.ToInt32(obj);

            if(result >= this.minValue && result <= this.maxValue)
            {
                return true;
            }

            return false;
        }
    }
}