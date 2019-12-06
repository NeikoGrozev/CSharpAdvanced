namespace Logger.Factory
{
    using Logger.Layouts;
    using System;

    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invlid Layout!");
            }
        }
    }
}
