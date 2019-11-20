namespace StreamProgress
{
    public class StartUp
    {
        public static void Main()
        {
            IStream stream = new Video(1000, 8);
            StreamProgressInfo info = new StreamProgressInfo(stream);
            System.Console.WriteLine(info.CalculateCurrentPercent());
        }
    }
}