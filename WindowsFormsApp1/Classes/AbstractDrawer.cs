using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public abstract class AbstractDrawer
    {
        public List<Lines> Lines;
        public List<Points> Points;
        public PictureBox PictureBox;
        
        protected AbstractDrawer(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            Lines = new List<Lines>();
            Points = new List<Points>();
        }

        protected virtual void InitializeData()
        {
        }

        public void Draw(List<Lines> figureLines, List<Points> figurePoints)
        {
            float distance = 300;
            using (var graphics = Graphics.FromImage(PictureBox.Image))
            {
                graphics.TranslateTransform((float)PictureBox.Width / 2, (float)PictureBox.Height / 2);

                for (int i = 0; i < figurePoints.Count; i++)
                {
                    using (Brush brush = new SolidBrush(figurePoints[i].PointColor))
                    {
                        graphics.FillEllipse(brush, figurePoints[i].Coordinate.Project(distance).X - 5, figurePoints[i].Coordinate.Project(distance).Y - 5, 10, 10);
                    }
                }
                for (int i = 0; i < figureLines.Count; i++)
                {
                    using (Pen pen = new Pen(figureLines[i].LineColor))
                    {
                        graphics.DrawLine(pen, figureLines[i].Vertices[0].Project(distance), figureLines[i].Vertices[1].Project(distance));
                    }
                }
            }
        }
    }
}