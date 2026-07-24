using System;
using System.Collections.Generic;
using System.Windows;

namespace NBoard.Models
{
    public class DrawingAction
    {
        public string Type { get; set; } // "pen", "eraser", "shape", "text"
        public string Color { get; set; }
        public int Size { get; set; }
        public List<Point> Points { get; set; }
        public string ShapeType { get; set; } // "line", "circle", "rectangle", etc.
        public string TextContent { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public int PageId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DrawingAction()
        {
            Points = new List<Point>();
            CreatedAt = DateTime.Now;
        }
    }

    public enum ToolType
    {
        Pen,
        Eraser,
        Line,
        Circle,
        Rectangle,
        Square,
        Triangle,
        Hexagon,
        Pentagon,
        Oval,
        Text
    }
}