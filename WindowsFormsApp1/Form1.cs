using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CoordinateIn3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public CoordinateIn3D(float x, float y, float z)
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
  public partial class Form1 : Form
  {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();

            this.Resize += Form1_Resize;

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            
            textBoxRotationAngle.Text = "10";
            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            AddMouseHandlers();
            
            AddKeyHandlers();
            
            pictureBox1.BackColor = Color.White;
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            RedrawFigure();
        }
        
        private void AddKeyHandlers()
        {
            this.KeyDown -= Form1_KeyDown;
            this.KeyDown += Form1_KeyDown;
            this.Focus();
            pictureBox1.TabStop = true;
            this.KeyPreview = true;
        }

        private void AddMouseHandlers()
        {
            pictureBox1.MouseDown -= pictureBox1_MouseDown;
            pictureBox1.MouseMove -= pictureBox1_MouseMove;
            pictureBox1.MouseUp -= pictureBox1_MouseUp;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
        }
        
        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "X";
            dataGridView1.Columns[1].Name = "Y";
            dataGridView1.Columns[2].Name = "Z";
            dataGridView1.Columns[3].Name = "Point index";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < figurePoints.Count; i++)
            {
                dataGridView1.Rows.Add(figurePoints[i].X, figurePoints[i].Y, figurePoints[i].Z, $"Point {i + 1}");
            }
        }

        private List<CoordinateIn3D> figurePoints;
        
        private bool figureOnPictureBox = false;

        public void FigureDraw()
        {
            float distance = 300;
            
            Pen p = new Pen(Color.Black);
            
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            GraphicsPath graphicsPath = new GraphicsPath();

            PointF[] points = new PointF[figurePoints.Count];
            
            for (int i = 0; i < figurePoints.Count; i++)
            {
                points[i] = figurePoints[i].Project(distance);
            }
            
            graphicsPath.AddPolygon(points);
            
            graphics.DrawPolygon(p, points);

            pictureBox1.Invalidate();
        }
        
        public void CubeDraw()
        {
            int x = pictureBox1.Height / 5;
            int y = pictureBox1.Height / 5;
            int z = pictureBox1.Height / 5;
            List<CoordinateIn3D> cubePoints = new List<CoordinateIn3D>()
            {
                new CoordinateIn3D(-x, -y, -z),
                new CoordinateIn3D(x, -y, -z),
                new CoordinateIn3D(x, y, -z),
                new CoordinateIn3D(-x, y, -z),
                new CoordinateIn3D(-x, -y, -z),
                
                new CoordinateIn3D(-x, -y, z),
                new CoordinateIn3D(x, -y, z),
                new CoordinateIn3D(x, y, z),
                new CoordinateIn3D(-x, y, z),
                new CoordinateIn3D(-x, -y, z),
                new CoordinateIn3D(-x, y, z),
                new CoordinateIn3D(-x, y, -z),
                
                new CoordinateIn3D(x, y, -z),
                new CoordinateIn3D(x, y, z),
                new CoordinateIn3D(x, -y, z),
                new CoordinateIn3D(x, -y, -z),
            };

            figurePoints = cubePoints;
        }
        
        private void CubeButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            CubeDraw();
            FigureDraw();
            figureOnPictureBox = true;
            UpdateDataGridView();
        }

        public void PyramidDraw()
        {
            int x = pictureBox1.Height / 5;
            int y = pictureBox1.Height / 5;
            int z = pictureBox1.Height / 5;
            List<CoordinateIn3D> pyramidPoints = new List<CoordinateIn3D>()
            {
                new CoordinateIn3D(-x, y, -z),
                new CoordinateIn3D(x, y, -z),
                new CoordinateIn3D(x, y, z),
                new CoordinateIn3D(-x, y, z),
                new CoordinateIn3D(0, -2 * y, 0),
                new CoordinateIn3D(x, y, -z),
                new CoordinateIn3D(x, y, z),
                new CoordinateIn3D(0, -2 * y, 0),
                new CoordinateIn3D(-x, y, -z),
                new CoordinateIn3D(-x, y, z)
            };

            figurePoints = pyramidPoints;
        }
        
        private void PyramidButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            PyramidDraw();
            FigureDraw();
            figureOnPictureBox = true;
            UpdateDataGridView();
        }
        
        public void ParallelepipedDraw()
        {
            int x = pictureBox1.Height / 5;
            int y = pictureBox1.Height / 7 * 2;
            int z = pictureBox1.Height / 5;
            List<CoordinateIn3D> parallelepipedPoints = new List<CoordinateIn3D>()
            {
                new CoordinateIn3D(-x, -y, -z),
                new CoordinateIn3D(x, -y, -z),
                new CoordinateIn3D(x, y, -z),
                new CoordinateIn3D(-x, y, -z),
                new CoordinateIn3D(-x, -y, -z),
                
                new CoordinateIn3D(-x, -y, z),
                new CoordinateIn3D(x, -y, z),
                new CoordinateIn3D(x, y, z),
                new CoordinateIn3D(-x, y, z),
                new CoordinateIn3D(-x, -y, z),
                new CoordinateIn3D(-x, y, z),
                new CoordinateIn3D(-x, y, -z),
                
                new CoordinateIn3D(x, y, -z),
                new CoordinateIn3D(x, y, z),
                new CoordinateIn3D(x, -y, z),
                new CoordinateIn3D(x, -y, -z),
            };

            figurePoints = parallelepipedPoints;
        }

        private void ParallelepipedButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ParallelepipedDraw();
            FigureDraw();
            figureOnPictureBox = true;
            UpdateDataGridView();
        }

        private void RedrawFigure()
        {
            if (figureOnPictureBox)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                FigureDraw();
            }
        }

        public void X_Rotate(float angle)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].X;
                float y = figurePoints[i].Y;
                float z = figurePoints[i].Z;

                float newY = y * (float)Math.Cos(angle) - z * (float)Math.Sin(angle);
                float newZ = z * (float)Math.Cos(angle) + y * (float)Math.Sin(angle);

                figurePoints[i] = new CoordinateIn3D(x, newY, newZ);
            }
            RedrawFigure();
        }

        private void X_Coordinate_Click(object sender, EventArgs e)
        {
            try
            {
                float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
                X_Rotate(angle);
            }
            catch (Exception exception)
            {
                HandlingError(exception);
            }
        }

        public void Y_Rotate(float angle)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].X;
                float y = figurePoints[i].Y;
                float z = figurePoints[i].Z;

                float newX = x * (float)Math.Cos(angle) + z * (float)Math.Sin(angle);
                float newZ = z * (float)Math.Cos(angle) - x * (float)Math.Sin(angle);

                figurePoints[i] = new CoordinateIn3D(newX, y, newZ);
            }
            RedrawFigure();
        }
        
        private void Y_Coordinate_Click(object sender, EventArgs e)
        {
            try
            {
                float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
                Y_Rotate(angle);
            }
            catch (Exception exception)
            {
                HandlingError(exception);
            }
        }

        public void Z_Rotate(float angle)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].X;
                float y = figurePoints[i].Y;
                float z = figurePoints[i].Z;

                float newX = x * (float)Math.Cos(angle) - y * (float)Math.Sin(angle);
                float newY = y * (float)Math.Cos(angle) + x * (float)Math.Sin(angle);

                figurePoints[i] = new CoordinateIn3D(newX, newY, z);
            }
            RedrawFigure();
        }
        
        private void Z_Coordinate_Click(object sender, EventArgs e)
        {
            try
            {
                float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
                Z_Rotate(angle);
            }
            catch (Exception exception)
            {
                HandlingError(exception);
            }
        }

        private bool isMouseDown = false;
        private Point lastMousePos;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            lastMousePos = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isMouseDown)
                {
                    int deltaX = e.X - lastMousePos.X;
                    int deltaY = e.Y - lastMousePos.Y;

                    float angleX = deltaX * 0.01f;
                    float angleY = deltaY * 0.01f;

                    X_Rotate(-angleY);
                    Y_Rotate(angleX);

                    lastMousePos = e.Location;
                }
            }
            catch (Exception exception)
            {
                HandlingError(exception);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float angle = 0.05f;
            if (!textBoxRotationAngle.Focused)
            {
                try
                {
                    switch (e.KeyCode)
                    {
                        case Keys.W:
                            X_Rotate(angle);
                            break;
                        case Keys.S:
                            X_Rotate(-angle);
                            break;
                        case Keys.D:
                            Y_Rotate(angle);
                            break;
                        case Keys.A:
                            Y_Rotate(-angle);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    HandlingError(exception);
                }
            }
        }
        
        private void HandlingError(Exception exception)
        {
            isMouseDown = false;
            try
            {
                float value = float.Parse(textBoxRotationAngle.Text);
                if (textBoxRotationAngle.Text == "")
                {
                    MessageBox.Show(@"Введите угол поворота!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(@"Вы не вызвали фигуру!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Введён неверный формат числа!(Пример: 1,01)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FigureScaling(float changeSize)
        {
            for (int i = 0; i < figurePoints.Count; i++)
            {
                figurePoints[i].X *= changeSize;
                figurePoints[i].Y *= changeSize;
                figurePoints[i].Z *= changeSize;
            }

            RedrawFigure();
        }
        
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Bounds.Contains(e.Location) && figureOnPictureBox)
            {
                int delta = e.Delta;
                float changeSize = (delta > 0) ? 1.01f : 0.99f;
                FigureScaling(changeSize);
            }
        }

        private void UpdateDataGrid_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }
  }
}