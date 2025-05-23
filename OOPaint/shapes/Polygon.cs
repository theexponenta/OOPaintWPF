﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Shared;


using Brush = System.Windows.Media.Brush;
using Pen = System.Windows.Media.Pen;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;


namespace OOPaint.Shapes
{
    public class Polygon : Shape
    {
        public List<Point> Points { get; }
        public bool IsCompleted { get; set; }

        public Polygon(Color strokeColor, Color fillColor, int lineWidth) : base(strokeColor, fillColor, lineWidth)
        {
            this.Points = new List<Point>();
            IsCompleted = false;
        }

        public override void Draw(DrawingContext context)
        {
            Pen pen = new Pen(new SolidColorBrush(this.StrokeColor), this.LineWidth);
            Brush brush = new SolidColorBrush(this.FillColor);
            
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(Points[0], true, IsCompleted);
                ctx.PolyLineTo(Points, true, true);
            }
            
            context.DrawGeometry(brush, pen, geometry);
        }
    }
}
