using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class Cube : AbstractDrawer
    {
        public List<Coordinate> Coordinates;
        public Cube(PictureBox pictureBox) : base(pictureBox)
        {
            PictureBox = pictureBox;
            Lines = new List<Lines>();
            Points = new List<Points>();
            InitializeData();
        }

        protected sealed override void InitializeData()
        {
            float x = (float)PictureBox.Height / 5;
            float z = (float)PictureBox.Height / 5;
            float y = (float)PictureBox.Height / 5;

            List<Coordinate> cubePoints = new List<Coordinate>()
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

            List<List<int>> cubeLineIndices = new List<List<int>>()
            {
                new List<int> { 0, 1 },
                new List<int> { 1, 2 },
                new List<int> { 2, 3 },
                new List<int> { 3, 0 },
                new List<int> { 4, 5 },
                new List<int> { 5, 6 },
                new List<int> { 6, 7 },
                new List<int> { 7, 4 },
                new List<int> { 0, 4 },
                new List<int> { 1, 5 },
                new List<int> { 2, 6 },
                new List<int> { 3, 7 }
            };

            for (int i = 0; i < cubeLineIndices.Count; i++)
            {
                List<Coordinate> lineVertices = cubeLineIndices[i].Select(index => cubePoints[index]).ToList();
                Lines cubeLine = new Lines(lineVertices, Pens.Black);
                Lines.Add(cubeLine);
            }

            for (int i = 0; i < cubePoints.Count; i++)
            {
                Points cubePoint = new Points(cubePoints[i], Brushes.Black);
                Points.Add(cubePoint);
            }
        }
    }
}
