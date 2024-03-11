using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1.Classes
{
    public class Lines
    {
        public List<Coordinate> Vertices { get; private set; }
        public Pen LinePen { get; set; }
        
        public Color LineColor { get; set; } = Color.Black;

        public Lines(List<Coordinate> vertices, Pen linePen)
        {
            Vertices = vertices;
            LinePen = linePen;
        }
    }
}