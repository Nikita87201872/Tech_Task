using System.Drawing;
namespace WindowsFormsApp1.Classes
{
    public class Points
    {
        public Coordinate Coordinate { get; set; }

        public Brush PointBrush { get; set; }
        
        public Color PointColor { get; set; } = Color.Black;

        public Points(Coordinate coordinate, Brush pointBrush)
        {
            Coordinate = coordinate;
            PointBrush = pointBrush;
        }
    }
}