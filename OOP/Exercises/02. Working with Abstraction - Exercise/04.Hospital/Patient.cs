﻿namespace Hospital
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
