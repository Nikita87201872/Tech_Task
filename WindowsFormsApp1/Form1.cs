using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using Exception = System.Exception;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();

            Resize += Form1_Resize;

            MouseWheel += Form1_MouseWheel;
            
            textBoxRotationAngle.Text = @"10";
            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            AddMouseHandlers();
            
            AddKeyHandlers();
            
            pictureBox1.BackColor = Color.White;

            _changeFigure = new ChangeFigure(pictureBox1);
            timer1 = new Timer();
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;

            label2.Text = @"Speed: " + trackBar1.Value.ToString();
            
            _checkBoxActions = new Dictionary<CheckBox, Action>
            {
                { checkBox1, () => Rotate(_rotationAngle, 0, 0) },
                { checkBox2, () => Rotate(0, _rotationAngle, 0) },
                { checkBox3, () => Rotate(0, 0, _rotationAngle) }
            };
            _rotationAngle = trackBar1.Value * 0.0015f;

            _height = pictureBox1.Height;
        }

        private List<Points> _figurePoints;
        private List<Lines> _figureLines;
        private Cube _cube;
        private Pyramid _pyramid;
        private Parallelepiped _parallelepiped;
        private bool _figureOnPictureBox;
        private readonly ChangeFigure _changeFigure;
        private bool _isMouseDown;
        private Point _lastMousePos;
        private float _rotationAngle;
        private readonly Dictionary<CheckBox, Action> _checkBoxActions;

        private float _height;


        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Width > 0 && pictureBox1.Height > 0 && _figureOnPictureBox)
                {
                    float delta = pictureBox1.Height / _height;
                    _height = pictureBox1.Height;
                    
                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    _changeFigure.Zoom(_figurePoints, _figureLines, delta);
                }
            }
            catch (Exception)
            {
                HandlingError();
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
            dataGridView1.ReadOnly = true;
        }

        private void UpdateColorButton()
        {
            if (_lastSelectedType == LastSelectedType.Line)
            {
                Color color1 = _figureLines[0].LinePen.Color;
                ChangeColor.BackColor = color1;
            }
            else
            {
                Color color2 = ((SolidBrush)_figurePoints[0].PointBrush).Color;
                ChangeColor.BackColor = color2;
            }
        }
        
        private void CubeButton_Click(object sender, EventArgs e)
        {
            _figureOnPictureBox = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _cube = new Cube(pictureBox1);
            _figureLines = _cube.Lines;
            _figurePoints = _cube.Points;
            _cube.Draw(_figureLines, _figurePoints);
            UpdateDataGridView();
            UpdateColorButton();
            UpdateComboBoxes();
        }

        
        private void PyramidButton_Click(object sender, EventArgs e)
        {
            _figureOnPictureBox = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _pyramid = new Pyramid(pictureBox1);
            _figurePoints = _pyramid.Points;
            _figureLines = _pyramid.Lines;
           _pyramid.Draw(_figureLines, _figurePoints);
           UpdateDataGridView();
           UpdateColorButton();
           UpdateComboBoxes();
        }
        

        private void ParallelepipedButton_Click(object sender, EventArgs e)
        {
            _figureOnPictureBox = true;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _parallelepiped = new Parallelepiped(pictureBox1);
            _figurePoints = _parallelepiped.Points;
            _figureLines = _parallelepiped.Lines;
            _parallelepiped.Draw(_figureLines, _figurePoints);
            UpdateDataGridView();
            UpdateColorButton();
            UpdateComboBoxes();
        }

        private void Rotate(float angleX, float angleY, float angleZ)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _changeFigure.Rotate(_figurePoints, _figureLines, angleX, 'X');
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _changeFigure.Rotate(_figurePoints, _figureLines, angleY, 'Y');
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _changeFigure.Rotate(_figurePoints, _figureLines, angleZ, 'Z');
        }
        
        private void X_Coordinate_Click(object sender, EventArgs e)
        {
            try
            {
                float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
                Rotate(angle, 0, 0);
            }
            catch (Exception)
            {
                HandlingError();
            }
        }

        private void Y_Coordinate_Click(object sender, EventArgs e)
        {
            try
            {
                float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180; 
                Rotate(0, angle, 0);
            }
            catch (Exception)
            {
                HandlingError();
            }
        }

        private void Z_Coordinate_Click(object sender, EventArgs e)
        {
            try
            {
                float angle = float.Parse(textBoxRotationAngle.Text) * (float)Math.PI / 180;
                Rotate(0, 0,angle);
            }
            catch (Exception)
            {
                HandlingError();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _lastMousePos = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            UpdateDataGridView();
        }
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (_isMouseDown)
                {
                    int deltaX = e.X - _lastMousePos.X;
                    int deltaY = e.Y - _lastMousePos.Y;

                    float angleX = deltaX * 0.01f;
                    float angleY = deltaY * 0.01f;
                    
                    Rotate(-angleY, angleX, 0);
                    // Thread thread1 = new Thread(() => Rotate(angleX, -angleY, 0));
                    // Thread thread2 = new Thread(() => UpdateDataGridView());
                    //
                    // thread1.Start();
                    // thread2.Start();
                    
                    _lastMousePos = e.Location;
                }
            }
            catch (Exception)
            {
                HandlingError();
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
                            Rotate(angle, 0, 0);
                            break;
                        case Keys.S:
                            Rotate(-angle, 0, 0);
                            break;
                        case Keys.D:
                            Rotate(0, angle, 0);
                            break;
                        case Keys.A:
                            Rotate(0, -angle, 0);
                            break;
                    }
                }
                catch (Exception)
                {
                    HandlingError();
                }
            }
        }
        
        private void HandlingError()
        {
            _isMouseDown = false;
            try
            {
                var unused = float.Parse(textBoxRotationAngle.Text);
                if(!_figureOnPictureBox)
                {
                    MessageBox.Show(@"You didn't summon the figure!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(textBoxRotationAngle.Text == "" ? @"Enter the rotation angle!" : @"The wrong number format has been entered!(Example: 1.01)", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!pictureBox1.Bounds.Contains(e.Location) || !_figureOnPictureBox) return;
            
            var delta = e.Delta;
            var changeSize = (delta > 0) ? 1.01f : 0.99f;
            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _changeFigure.Zoom(_figurePoints, _figureLines, changeSize);
        }
        
        private void UpdateDataGridView()
        {
            if (_figurePoints != null)
            {
                Task.Run(() =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        dataGridView1.Rows.Clear();
                        for (var i = 0; i < _figurePoints.Count; i++)
                        {
                            dataGridView1.Rows.Add(
                                Math.Round(_figurePoints[i].Coordinate.X, 1), 
                                Math.Round(_figurePoints[i].Coordinate.Y, 1), 
                                Math.Round(_figurePoints[i].Coordinate.Z, 1), 
                                $"Point {i + 1}");
                        }
                    });
                });
            }
            else
            {
                HandlingError();
            }
        }
      
        private readonly ColorDialog _colorDialog = new ColorDialog();

        public enum LastSelectedType
        {
            None,
            Point,
            Line
        }

        private LastSelectedType _lastSelectedType = LastSelectedType.None;
        private Color _lastSelectedColorFL;
        private Color _lastSelectedColorFP;
        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (!_figureOnPictureBox)
            {
                MessageBox.Show(@"You didn't summon the figure!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
                _changeFigure.Draw(_figureLines, _figurePoints);
            }
        }
        
        private void ApplyColorForPoint(Color color)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int count = PointComboBox.SelectedIndex;
            if (count != 0)
            {
                _figurePoints[count - 1].PointColor = color;
                _figurePoints[count - 1].PointBrush = new SolidBrush(color);
            }
            else
            {
                foreach (Points point in _figurePoints)
                {
                    point.PointColor = color;
                    point.PointBrush = new SolidBrush(color);
                }

                _lastSelectedColorFP = color;
            }
        }

        private void ApplyColorForLine(Color color)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int count = LineComboBox.SelectedIndex;
            if (count != 0)
            {
                _figureLines[count - 1].LineColor = color;
                _figureLines[count - 1].LinePen = new Pen(color);
            }
            else
            {
                foreach (Lines line in _figureLines)
                {
                    line.LineColor = color;
                    line.LinePen = new Pen(color);
                }

                _lastSelectedColorFL = color;
            }
        }

        public void UpdateComboBoxes()
        {
            LineComboBox.Items.Clear();
            PointComboBox.Items.Clear();
            LineComboBox.Items.Add("Lines");
            PointComboBox.Items.Add("Points");
            for (int i = 0; i < _figureLines.Count; i++)
            {
                LineComboBox.Items.Add($"Line {i + 1}");
            }

            for (int i = 0; i < _figurePoints.Count; i++)
            {
                PointComboBox.Items.Add($"Point {i + 1}");
            }
        }
        private void LineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedType = LastSelectedType.Line;
            if (LineComboBox.SelectedIndex > 0 && LineComboBox.SelectedIndex <= _figureLines.Count)
            {
                Color color = _figureLines[LineComboBox.SelectedIndex - 1].LinePen.Color;
                ChangeColor.BackColor = color;
            }
            else
            {
                ChangeColor.BackColor = _lastSelectedColorFL;
            }
        }
        
        private void PointComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedType = LastSelectedType.Point;
            if (PointComboBox.SelectedIndex > 0 && PointComboBox.SelectedIndex <= _figurePoints.Count)
            {
                Color color = ((SolidBrush)_figurePoints[PointComboBox.SelectedIndex - 1].PointBrush).Color;
                ChangeColor.BackColor = color;
            }
            else
            {
                ChangeColor.BackColor = _lastSelectedColorFP;
            }
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (_figureOnPictureBox)
            {
                if (timer1.Enabled)
                    timer1.Stop();
                else
                    timer1.Start();
            }
            else
            {
                HandlingError();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (var checkBoxAction in _checkBoxActions)
                {
                    var checkBox = checkBoxAction.Key;
                    if (checkBox.Checked)
                    {
                        checkBoxAction.Value.Invoke();
                    }
                }
            });
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _rotationAngle = trackBar1.Value * 0.0015f;
            label2.Text = @"Speed: " + trackBar1.Value.ToString();
        }
  }
}