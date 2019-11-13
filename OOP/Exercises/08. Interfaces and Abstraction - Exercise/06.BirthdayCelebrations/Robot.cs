namespace BirthdayCelebrations
{
    public class Robot : Society, IRobot, IId
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }

        public override bool FindingYear(string year)
        {
            return false;
        }
    }
}