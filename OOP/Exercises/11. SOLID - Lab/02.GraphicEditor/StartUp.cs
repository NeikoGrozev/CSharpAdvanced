namespace GraphicEditor
{
    public class StartUp
    {
        public static void Main()
        {
            Cube cube = new Cube();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(cube);
        }
    }
}