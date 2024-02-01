using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class Cube : IDraw
    {
        public List<Lines> CubeLines = new List<Lines>();
        public List<Points> CubePoints = new List<Points>();
        private PictureBox PictureBox;

        public Cube(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            CubeLines = new List<Lines>();
            CubePoints = new List<Points>();

            InitializeCubeData();
        }

        private void InitializeCubeData()
        {
            int x = PictureBox.Height / 5;
            int y = PictureBox.Height / 5;
            int z = PictureBox.Height / 5;

            List<Coordinate> cubeCoordinates = new List<Coordinate>()
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
                List<Coordinate> lineVertices = cubeLineIndices[i].Select(index => cubeCoordinates[index]).ToList();
                Lines cubeLine = new Lines(lineVertices, Pens.Black);
                CubeLines.Add(cubeLine);
            }

            for (int i = 0; i < cubeCoordinates.Count; i++)
            {
                Points cubePoint = new Points(cubeCoordinates[i], Brushes.Black);
                CubePoints.Add(cubePoint);
            }
        }

        public void Draw()
        {
            Graphics graphics = PictureBox.CreateGraphics();
            float distance = 300;

            foreach (Lines cubeLine in CubeLines)
            {
                cubeLine.Draw(PictureBox, distance);
            }

            foreach (Points cubePoint in CubePoints)
            {
                cubePoint.Draw(PictureBox, distance);
            }

            graphics.Dispose();
        }
    }
}
