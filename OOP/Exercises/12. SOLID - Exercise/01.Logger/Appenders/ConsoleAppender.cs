namespace Logger.Appenders
{
    using Layouts;
    using Logger.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {         
        }                

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.Counter++;

                Console.WriteLine(this.Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}