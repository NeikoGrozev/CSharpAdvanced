namespace Hospital
{
    public class Engine
    {
        public static void Run()
        {

            Hospital hospital = new Hospital();

            AddArgumentsInHospital.Add(hospital);

            PrintInfo.Print(hospital);
        }
    }
}
