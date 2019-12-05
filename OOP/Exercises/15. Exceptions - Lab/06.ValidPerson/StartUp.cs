namespace ValidPerson
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Person pesho = new Person("Pesho", "Peshev", 24);
                //Person noname = new Person(string.Empty, "Gochev", 31);
                //Person noLastName = new Person("Ivan", null, 63);
                //Person negativeAge = new Person("Stoyan", "Kolev", -1);
                //Person tooOldforThisProgram = new Person("Iskren", "Ivanov", 121);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}