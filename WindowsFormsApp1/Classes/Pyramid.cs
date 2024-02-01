using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class Pyramid : IDraw
    {
        public List<Lines> PyramidLines = new List<Lines>();
        public List<Points> PyramidPoints = new List<Points>();
        private PictureBox PictureBox;

        public Pyramid(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            PyramidLines = new List<Lines>();
            PyramidPoints = new List<Points>();
            
            InitializePyramidData();
        }

        private void InitializePyramidData()
        {
            float distance = 300;

            Pen pen = new Pen(Color.Black);
            
            int x = PictureBox.Height / 5;
            int y = PictureBox.Height / 5;
            int z = PictureBox.Height / 5;
            

            List<Coordinate> PyramidPoint = new List<Coordinate>()
            {
                new Coordinate(-x, y, z),
                new Coordinate(-x, y, -z),
                new Coordinate(x, y, -z),
                new Coordinate(x, y, z),
                new Coordinate(0, -2 * y, 0)
            };

            List<List<int>> PyramidLineIndices = new List<List<int>>()
            {
                new List<int>() {0, 1},
                new List<int>() {1, 2},
                new List<int>() {2, 3},
                new List<int>() {3, 0},
                
                new List<int>() {0, 4},
                new List<int>() {1, 4},
                new List<int>() {2, 4},
                new List<int>() {3, 4}
            };

            for (int i = 0; i < PyramidLineIndices.Count; i++)
            {
                List<Coordinate> lineVertices = PyramidLineIndices[i].Select(index => PyramidPoint[index]).ToList();
                Lines pyramidLines = new Lines(lineVertices, Pens.Black);
                PyramidLines.Add(pyramidLines);
            }

            for (int i = 0; i < PyramidPoint.Count; i++)
            {
                Points points = new Points(PyramidPoint[i], Brushes.Black);
                PyramidPoints.Add(points);
            }
        }
        
        public void Draw()
        {
            Graphics graphics = PictureBox.CreateGraphics();
            float distance = 300;

            foreach (Lines pyramidLine in PyramidLines)
            {
                pyramidLine.Draw(PictureBox, distance);
            }

            foreach (Points pyramidPoint in PyramidPoints)
            {
                pyramidPoint.Draw(PictureBox, distance);
            }

            graphics.Dispose();
        }        
    }
}