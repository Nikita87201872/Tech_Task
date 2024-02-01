using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class Parallelepiped : IDraw
    {
        public List<Lines> ParallelepipedLines = new List<Lines>();
        public List<Points> ParallelepipedPoints = new List<Points>();
        private PictureBox PictureBox;

        public Parallelepiped(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            ParallelepipedLines = new List<Lines>();
            ParallelepipedPoints = new List<Points>();
            
            InitializeParallelepipedData();
        }

        private void InitializeParallelepipedData()
        {
            float distance = 300;

            Pen pen = new Pen(Color.Black);
            
            int x = PictureBox.Height / 5;
            int y = PictureBox.Height / 7 * 2;
            int z = PictureBox.Height / 5;
            

            List<Coordinate> ParallelepipedPoint = new List<Coordinate>()
            {
                new Coordinate(-x, y, z),
                new Coordinate(-x, -y, z),
                new Coordinate(x, -y, z),
                new Coordinate(x, y, z),
                new Coordinate(-x, y, -z),
                new Coordinate(-x, -y, -z),
                new Coordinate(x, -y, -z),
                new Coordinate(x, y, -z)
            };

            List<List<int>> ParallelepipedLineIndices = new List<List<int>>()
            {
                new List<int> {0, 1},
                new List<int> {1, 2},
                new List<int> {2, 3},
                new List<int> {3, 0},
                
                new List<int> {4, 5},
                new List<int> {5, 6},
                new List<int> {6, 7},
                new List<int> {7, 4},
                
                new List<int> {0, 4},
                new List<int> {1, 5},
                new List<int> {2, 6},
                new List<int> {3, 7}
            };
            
            for (int i = 0; i < ParallelepipedLineIndices.Count; i++)
            {
                List<Coordinate> lineVertices = ParallelepipedLineIndices[i].Select(index => ParallelepipedPoint[index]).ToList();
                Lines parallelepipedLines = new Lines(lineVertices, Pens.Black);
                ParallelepipedLines.Add(parallelepipedLines);
            }

            for (int i = 0; i < ParallelepipedPoint.Count; i++)
            {
                Points points = new Points(ParallelepipedPoint[i], Brushes.Black);
                ParallelepipedPoints.Add(points);
            }
        }
        
        public void Draw()
        {
            Graphics graphics = PictureBox.CreateGraphics();
            float distance = 300;

            foreach (Lines pyramidLine in ParallelepipedLines)
            {
                pyramidLine.Draw(PictureBox, distance);
            }

            foreach (Points pyramidPoint in ParallelepipedPoints)
            {
                pyramidPoint.Draw(PictureBox, distance);
            }

            graphics.Dispose();
        }
    }
}