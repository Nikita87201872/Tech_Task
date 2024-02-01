using System.Drawing;
using System.Windows.Forms;

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

        public void Draw(PictureBox pictureBox, float distance)
        {
            Graphics graphics = Graphics.FromImage(pictureBox.Image);
            graphics.TranslateTransform(pictureBox.Width / 2, pictureBox.Height / 2);
            
            using (Brush brush = new SolidBrush(PointColor))
            {
                graphics.FillEllipse(brush, Coordinate.Project(distance).X - 5, Coordinate.Project(distance).Y - 5, 10, 10);
            }
            
            graphics.Dispose();
        }
    }
}