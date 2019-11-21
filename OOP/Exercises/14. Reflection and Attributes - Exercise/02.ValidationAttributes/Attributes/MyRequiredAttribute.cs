namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if(obj != null)
            {
                return true;
            }

            return false;
        }
    }
}