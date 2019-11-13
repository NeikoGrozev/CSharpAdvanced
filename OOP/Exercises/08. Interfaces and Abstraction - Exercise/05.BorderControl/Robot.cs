namespace BorderControl
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

        public override bool FindingFakeId(string number)
        {
            if (this.Id.EndsWith(number))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
