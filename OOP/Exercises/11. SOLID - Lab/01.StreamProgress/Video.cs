namespace StreamProgress
{
    public class Video : IStream
    {
        public Video(int bytesSent, int lenght)
        {
            this.BytesSent = bytesSent;
            this.Length = lenght;
        }
        public int Length { get ; set ; }

        public int BytesSent { get; set ; }
    }
}