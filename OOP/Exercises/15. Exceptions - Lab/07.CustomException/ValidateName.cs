namespace CustomException
{
    public class ValidateName
    {
        private string name;

        public ValidateName(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(Validate(value))
                {
                    this.name = value;
                }
            }
        }

        private bool Validate(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if(!char.IsLetter(name[i]))
                {
                    throw new InvalidPersonNameException(name);
                }
            }

            return true;
        }
    }
}