using System.Drawing;

namespace WindowsFormsApp1.Classes
{
    public class Coordinate
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Coordinate(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public PointF Project(float distance)
        {
            float[,] transformMatrix = {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, distance / (distance - Z) }
            };

            float newX = transformMatrix[0, 0] * X + transformMatrix[0, 1] * Y + transformMatrix[0, 2] * Z;
            float newY = transformMatrix[1, 0] * X + transformMatrix[1, 1] * Y + transformMatrix[1, 2] * Z;

            return new PointF(newX, newY);
        }
    }
}