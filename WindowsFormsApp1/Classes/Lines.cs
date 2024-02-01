using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        public void Draw(PictureBox pictureBox, float distance)
        {
            Graphics graphics = Graphics.FromImage(pictureBox.Image);
            graphics.TranslateTransform(pictureBox.Width / 2, pictureBox.Height / 2);

            using (Pen pen = new Pen(LineColor))
            {
                graphics.DrawLine(pen, Vertices[0].Project(distance), Vertices[1].Project(distance));
            }
            
            graphics.Dispose();
        }
    }
}