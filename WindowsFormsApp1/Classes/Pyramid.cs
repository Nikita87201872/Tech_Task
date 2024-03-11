using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class Pyramid : AbstractDrawer
    {
        public Pyramid(PictureBox pictureBox) : base(pictureBox)
        {
            
            PictureBox = pictureBox;
            Lines = new List<Lines>();
            Points = new List<Points>();
            InitializeData();
            
        }

        protected sealed override void InitializeData()
        {
            float x = (float)PictureBox.Height / 5;
            float y = (float)PictureBox.Height / 5;
            float z = (float)PictureBox.Height / 5;
            

            List<Coordinate> pyramidPoint = new List<Coordinate>()
            {
                new Coordinate(-x, y, z),
                new Coordinate(-x, y, -z),
                new Coordinate(x, y, -z),
                new Coordinate(x, y, z),
                new Coordinate(0, -2 * y, 0)
            };

            List<List<int>> pyramidLineIndices = new List<List<int>>()
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

            for (int i = 0; i < pyramidLineIndices.Count; i++)
            {
                List<Coordinate> lineVertices = pyramidLineIndices[i].Select(index => pyramidPoint[index]).ToList();
                Lines cubeLine = new Lines(lineVertices, Pens.Black);
                Lines.Add(cubeLine);
            }

            for (int i = 0; i < pyramidPoint.Count; i++)
            {
                Points cubePoint = new Points(pyramidPoint[i], Brushes.Black);
                Points.Add(cubePoint);
            }
        }
    }
}