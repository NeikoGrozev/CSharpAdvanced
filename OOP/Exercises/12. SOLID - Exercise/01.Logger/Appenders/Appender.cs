namespace Logger.Appenders
{
    using Logger.Enums;
    using Logger.Layouts;

    public abstract class Appender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        protected int Counter { get; set; }

        public abstract void Append(string dateTime, ReportLevel logLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.Counter}";
        }
    }
}
