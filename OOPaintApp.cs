using System.Collections.Generic;
using OOPaint.Shapes;

namespace OOPaint
{
    public class OOPaintApp
    {
        public List<Shape> Shapes { get; private set; }

        public OOPaintApp()
        {
            Shapes = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void Undo()
        {
            
        }

        public void Redo()
        {
            
        }
    }
}