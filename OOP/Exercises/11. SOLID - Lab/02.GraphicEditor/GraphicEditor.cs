namespace GraphicEditor
{
    using System;

    public class GraphicEditor
    {
        public virtual void DrawShape(IShape shape)
        {
           Console.WriteLine(shape.Draw());
        }
    }
}