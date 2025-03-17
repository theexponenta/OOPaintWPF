using System;
using System.Collections.Generic;
using OOPaint.Shapes;
using System.Windows.Media;
using OOPaint.Tools;


namespace OOPaint
{
    public class OOPaintApp
    {
        public List<Shape> Shapes { get; private set; }
        public Color SelectedStrokeColor { get; set; }
        public Color SelectedFillColor { get;  set; }
        public int SelectedLineWidth { get; set; }

        public int SelectedToolIndex { get; set;  }

        private List<Tool> tools;
        private CustomCanvas canvas;

        public OOPaintApp(CustomCanvas canvas)
        {
            Shapes = new List<Shape>();
            tools = new List<Tool>();
            this.canvas = canvas;
            SelectedFillColor = Colors.Black;
            SelectedStrokeColor = Colors.Black;
            SelectedLineWidth = 2;
            SelectedToolIndex = 0;
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void DeleteLastShape()
        {
            Shapes.RemoveAt(Shapes.Count - 1);
        }
        
        public void Undo()
        {
            
        }

        public void Redo()
        {
        }

        public void DispatchEvent(EventType eventType, object sender, EventArgs e)
        {
            tools[SelectedToolIndex].HandleEvent(eventType, sender, e);
        }

        public void Redraw()
        {
            canvas.InvalidateVisual();
        }

        public void AddTool(Tool tool)
        {
            tools.Add(tool);
        }
    }
}