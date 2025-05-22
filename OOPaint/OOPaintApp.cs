using System;
using System.Collections.Generic;
using System.IO;
using OOPaint.Shapes;
using System.Windows.Media;
using Newtonsoft.Json;
using OOPaint.Tools;
using Shared;


using Color = System.Windows.Media.Color;


namespace OOPaint
{

    public class OOPaintApp : IPaintApp
    {
        public List<Shape> Shapes
        {
            get { return shapes; }
            private set { shapes = value; UndoIndex = value.Count - 1; }
        }
        
        private List<Shape> shapes;

        public Color SelectedStrokeColor { get; set; }
        public Color SelectedFillColor { get;  set; }
        public int SelectedLineWidth { get; set; }

        public int SelectedToolIndex { get; set;  }

        public int UndoIndex { get; private set; }

        private List<Tool> tools;
        private CustomCanvas canvas;

        public OOPaintApp(CustomCanvas canvas)
        {
            UndoIndex = -1;
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
            if (UndoIndex != Shapes.Count - 1)
            {
                Shapes.RemoveRange(UndoIndex + 1, Shapes.Count  - UndoIndex - 1);
            }

            Shapes.Add(shape);
            UndoIndex++;
        }

        public void DeleteLastShape()
        {
            Shapes.RemoveAt(Shapes.Count - 1);
        }
        
        public void Undo()
        {
            UndoIndex = Math.Max(UndoIndex - 1, -1);
        }

        public void Redo()
        {
            UndoIndex = Math.Min(UndoIndex + 1, Shapes.Count - 1);
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

        public void SaveToFile(String fileName)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            
            File.WriteAllText(fileName, JsonConvert.SerializeObject(shapes, settings));
        }

        public void LoadFromFile(string fileName)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            
            Shapes = JsonConvert.DeserializeObject<List<Shape>>(File.ReadAllText(fileName), settings);
        }
    }
}