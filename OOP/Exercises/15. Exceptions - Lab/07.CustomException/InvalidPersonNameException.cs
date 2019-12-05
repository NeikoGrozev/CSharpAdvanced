namespace CustomException
{
    using System;

    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string name) 
            : base(String.Format($"Invalid Student Name: {name}"))
        {
        }
    }
}