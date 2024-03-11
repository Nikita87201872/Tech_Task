using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class Parallelepiped : AbstractDrawer
    {

        public Parallelepiped(PictureBox pictureBox) : base(pictureBox)
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
            

            List<Coordinate> parallelepipedPoint = new List<Coordinate>()
            {
                new Coordinate(-x, 1.5f*y, z),
                new Coordinate(-x, -1.5f*y, z),
                new Coordinate(x, -1.5f*y, z),
                new Coordinate(x, 1.5f*y, z),
                new Coordinate(-x, 1.5f*y, -z),
                new Coordinate(-x, -1.5f*y, -z),
                new Coordinate(x, -1.5f*y, -z),
                new Coordinate(x, 1.5f*y, -z)
            };

            List<List<int>> parallelepipedLineIndices = new List<List<int>>()
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
            
            for (int i = 0; i < parallelepipedLineIndices.Count; i++)
            {
                List<Coordinate> lineVertices = parallelepipedLineIndices[i].Select(index => parallelepipedPoint[index]).ToList();
                Lines parallelepipedLines = new Lines(lineVertices, Pens.Black);
                Lines.Add(parallelepipedLines);
            }

            for (int i = 0; i < parallelepipedPoint.Count; i++)
            {
                Points points = new Points(parallelepipedPoint[i], Brushes.Black);
                Points.Add(points);
            }
        }
    }
}