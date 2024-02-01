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
using WindowsFormsApp1.Classes;
using WindowsFormsApp1.Interfaces;

namespace WindowsFormsApp1
{
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

            ChangeFigure = new ChangeFigure(pictureBox1);
        }
        
        public List<Points> FigurePoints = new List<Points>();
        public List<Lines> FigureLines = new List<Lines>();
        public Cube Cube;
        public Pyramid Pyramid;
        public Parallelepiped Parallelepiped;
        private bool _figureOnPictureBox = false;
        public ChangeFigure ChangeFigure;
        private bool isMouseDown = false;
        private Point lastMousePos;
        public float distance = 300;
        
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Width > 0 && pictureBox1.Height > 0)
                {
                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    ChangeFigure.Redraw(FigurePoints, FigureLines, distance);
                }
            }
            catch (Exception ex)
            {
                HandlingError(ex);
            }
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

        public void UpdateComboBoxes()
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            
            for (int i = 0; i < FigureLines.Count; i++)
            {
                comboBox2.Items.Add($"Line {i + 1}");
            }

            for (int i = 0; i < FigurePoints.Count; i++)
            {
                comboBox3.Items.Add($"Point {i + 1}");
            }
        }
        
        private void CubeButton_Click(object sender, EventArgs e)
        {
            _figureOnPictureBox = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Cube = new Cube(pictureBox1);
            Cube.Draw();
            FigurePoints = Cube.CubePoints;
            FigureLines = Cube.CubeLines;
            
            UpdateDataGridView();
            UpdateComboBoxes();
        }

        
        private void PyramidButton_Click(object sender, EventArgs e)
        {
            _figureOnPictureBox = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Pyramid = new Pyramid(pictureBox1);
            Pyramid.Draw();
            FigurePoints = Pyramid.PyramidPoints;
            FigureLines = Pyramid.PyramidLines;
            
            UpdateDataGridView();
            UpdateComboBoxes();
        }
        

        private void ParallelepipedButton_Click(object sender, EventArgs e)
        {
            _figureOnPictureBox = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Parallelepiped = new Parallelepiped(pictureBox1);
            Parallelepiped.Draw();
            FigurePoints = Parallelepiped.ParallelepipedPoints;
            FigureLines = Parallelepiped.ParallelepipedLines;
            
            UpdateDataGridView();
            UpdateComboBoxes();
        }

        public void X_Rotate(float angle)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ChangeFigure.TransformX(FigurePoints, FigureLines, angle);
        }
        
        private void X_Coordinate_Click(object sender, EventArgs e)
        {
            float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
            X_Rotate(angle);
        }

        public void Y_Rotate(float angle)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ChangeFigure.TransformY(FigurePoints, FigureLines, angle);
        }

        private void Y_Coordinate_Click(object sender, EventArgs e)
        {
            float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
            Y_Rotate(angle);
        }

        public void Z_Rotate(float angle)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ChangeFigure.TransformZ(FigurePoints, FigureLines, angle);
        }

        private void Z_Coordinate_Click(object sender, EventArgs e)
        {
            float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
            Z_Rotate(angle);
        }

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
                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    ChangeFigure.TransformX(FigurePoints, FigureLines, -angleY);
                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    ChangeFigure.TransformY(FigurePoints, FigureLines, angleX);

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
                if(!_figureOnPictureBox)
                {
                    MessageBox.Show(@"Вы не вызвали фигуру!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                if (textBoxRotationAngle.Text == "")
                {
                    MessageBox.Show(@"Введите угол поворота!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Введён неверный формат числа!(Пример: 1,01)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Bounds.Contains(e.Location))
            {
                int delta = e.Delta;
                float changeSize = (delta > 0) ? 1.01f : 0.99f;
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                ChangeFigure.Zoom(FigurePoints, FigureLines, changeSize);
            }
        }
        
        private void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < FigurePoints.Count; i++)
            {
                dataGridView1.Rows.Add(Math.Round(FigurePoints[i].Coordinate.X, 1), Math.Round(FigurePoints[i].Coordinate.Y, 1), Math.Round(FigurePoints[i].Coordinate.Z, 1), $"Point {i + 1}");
            }
        }

        private void UpdateDataGrid_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDataGridView();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вы не вызвали фигуру!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ColorDialog _colorDialog = new ColorDialog();
        private Color _newColor;
        enum LastSelectedType
        {
            None,
            Point,
            Line
        }

        private LastSelectedType _lastSelectedType = LastSelectedType.None;
        private void ColorButton_Click(object sender, EventArgs e)
        {
            _colorDialog.ShowDialog();
            ChangeColor.BackColor = _colorDialog.Color;
            if (_lastSelectedType == LastSelectedType.Point)
            {
                ApplyColorForPoint(_colorDialog.Color);
            }
            else if (_lastSelectedType == LastSelectedType.Line)
            {
                ApplyColorForLine(_colorDialog.Color);
            }

            ChangeFigure.Redraw(FigurePoints, FigureLines, distance);
        }

        private void ApplyColorForPoint(Color color)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int count = comboBox3.SelectedIndex;
            FigurePoints[count].PointColor = color;
            FigurePoints[count].PointBrush = new SolidBrush(color);
        }

        private void ApplyColorForLine(Color color)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int count = comboBox2.SelectedIndex;
            FigureLines[count].LineColor = color;
            FigureLines[count].LinePen = new Pen(color);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedType = LastSelectedType.Line;
            Color color = FigureLines[comboBox2.SelectedIndex].LinePen.Color;
            ChangeColor.BackColor = color;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedType = LastSelectedType.Point;
            Color color = ((SolidBrush)FigurePoints[comboBox3.SelectedIndex].PointBrush).Color;
            ChangeColor.BackColor = color;
        }
  }
}