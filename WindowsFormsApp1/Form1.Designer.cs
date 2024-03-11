namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CubeButton = new System.Windows.Forms.Button();
            this.PyramidButton = new System.Windows.Forms.Button();
            this.ParallelepipedButton = new System.Windows.Forms.Button();
            this.X_Coordinate = new System.Windows.Forms.Button();
            this.Y_Coordinate = new System.Windows.Forms.Button();
            this.Z_Coordinate = new System.Windows.Forms.Button();
            this.textBoxRotationAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChangeColor = new System.Windows.Forms.Button();
            this.LineComboBox = new System.Windows.Forms.ComboBox();
            this.ColorButton = new System.Windows.Forms.Button();
            this.RotateButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.PointComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(554, 440);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // CubeButton
            // 
            this.CubeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CubeButton.Location = new System.Drawing.Point(12, 12);
            this.CubeButton.Name = "CubeButton";
            this.CubeButton.Size = new System.Drawing.Size(134, 59);
            this.CubeButton.TabIndex = 1;
            this.CubeButton.Text = "Cube";
            this.CubeButton.UseVisualStyleBackColor = true;
            this.CubeButton.Click += new System.EventHandler(this.CubeButton_Click);
            // 
            // PyramidButton
            // 
            this.PyramidButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PyramidButton.Location = new System.Drawing.Point(152, 12);
            this.PyramidButton.Name = "PyramidButton";
            this.PyramidButton.Size = new System.Drawing.Size(134, 59);
            this.PyramidButton.TabIndex = 2;
            this.PyramidButton.Text = "Pyramid";
            this.PyramidButton.UseVisualStyleBackColor = true;
            this.PyramidButton.Click += new System.EventHandler(this.PyramidButton_Click);
            // 
            // ParallelepipedButton
            // 
            this.ParallelepipedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ParallelepipedButton.Location = new System.Drawing.Point(292, 12);
            this.ParallelepipedButton.Name = "ParallelepipedButton";
            this.ParallelepipedButton.Size = new System.Drawing.Size(134, 59);
            this.ParallelepipedButton.TabIndex = 3;
            this.ParallelepipedButton.Text = "Parallelepiped";
            this.ParallelepipedButton.UseVisualStyleBackColor = true;
            this.ParallelepipedButton.Click += new System.EventHandler(this.ParallelepipedButton_Click);
            // 
            // X_Coordinate
            // 
            this.X_Coordinate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.X_Coordinate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.X_Coordinate.Location = new System.Drawing.Point(754, 500);
            this.X_Coordinate.Name = "X_Coordinate";
            this.X_Coordinate.Size = new System.Drawing.Size(60, 60);
            this.X_Coordinate.TabIndex = 4;
            this.X_Coordinate.Text = "X";
            this.X_Coordinate.UseVisualStyleBackColor = true;
            this.X_Coordinate.Click += new System.EventHandler(this.X_Coordinate_Click);
            // 
            // Y_Coordinate
            // 
            this.Y_Coordinate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Y_Coordinate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Y_Coordinate.Location = new System.Drawing.Point(820, 500);
            this.Y_Coordinate.Name = "Y_Coordinate";
            this.Y_Coordinate.Size = new System.Drawing.Size(60, 60);
            this.Y_Coordinate.TabIndex = 5;
            this.Y_Coordinate.Text = "Y";
            this.Y_Coordinate.UseVisualStyleBackColor = true;
            this.Y_Coordinate.Click += new System.EventHandler(this.Y_Coordinate_Click);
            // 
            // Z_Coordinate
            // 
            this.Z_Coordinate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z_Coordinate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Z_Coordinate.Location = new System.Drawing.Point(886, 500);
            this.Z_Coordinate.Name = "Z_Coordinate";
            this.Z_Coordinate.Size = new System.Drawing.Size(60, 60);
            this.Z_Coordinate.TabIndex = 6;
            this.Z_Coordinate.Text = "Z";
            this.Z_Coordinate.UseVisualStyleBackColor = true;
            this.Z_Coordinate.Click += new System.EventHandler(this.Z_Coordinate_Click);
            // 
            // textBoxRotationAngle
            // 
            this.textBoxRotationAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRotationAngle.Location = new System.Drawing.Point(792, 118);
            this.textBoxRotationAngle.Name = "textBoxRotationAngle";
            this.textBoxRotationAngle.Size = new System.Drawing.Size(155, 26);
            this.textBoxRotationAngle.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(792, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Angle rotate";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(572, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(375, 332);
            this.dataGridView1.TabIndex = 10;
            // 
            // ChangeColor
            // 
            this.ChangeColor.Enabled = false;
            this.ChangeColor.Location = new System.Drawing.Point(498, 47);
            this.ChangeColor.Name = "ChangeColor";
            this.ChangeColor.Size = new System.Drawing.Size(25, 25);
            this.ChangeColor.TabIndex = 13;
            this.ChangeColor.UseVisualStyleBackColor = true;
            // 
            // LineComboBox
            // 
            this.LineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineComboBox.FormattingEnabled = true;
            this.LineComboBox.Location = new System.Drawing.Point(498, 12);
            this.LineComboBox.Name = "LineComboBox";
            this.LineComboBox.Size = new System.Drawing.Size(173, 28);
            this.LineComboBox.TabIndex = 16;
            this.LineComboBox.SelectedIndexChanged += new System.EventHandler(this.LineComboBox_SelectedIndexChanged);
            // 
            // ColorButton
            // 
            this.ColorButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_rgb_круг_2_601;
            this.ColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ColorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColorButton.Location = new System.Drawing.Point(432, 12);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(60, 60);
            this.ColorButton.TabIndex = 12;
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(12, 77);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(134, 79);
            this.RotateButton.TabIndex = 17;
            this.RotateButton.Text = "Stop / Continue";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(152, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(44, 24);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "X";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(152, 105);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(44, 24);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Y";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(152, 133);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(44, 24);
            this.checkBox3.TabIndex = 20;
            this.checkBox3.Text = "Z";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(202, 93);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(321, 69);
            this.trackBar1.TabIndex = 21;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(202, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Speed: ";
            // 
            // PointComboBox
            // 
            this.PointComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PointComboBox.FormattingEnabled = true;
            this.PointComboBox.Location = new System.Drawing.Point(677, 12);
            this.PointComboBox.Name = "PointComboBox";
            this.PointComboBox.Size = new System.Drawing.Size(173, 28);
            this.PointComboBox.TabIndex = 23;
            this.PointComboBox.SelectedIndexChanged += new System.EventHandler(this.PointComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(958, 614);
            this.Controls.Add(this.PointComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.LineComboBox);
            this.Controls.Add(this.ChangeColor);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRotationAngle);
            this.Controls.Add(this.Z_Coordinate);
            this.Controls.Add(this.Y_Coordinate);
            this.Controls.Add(this.X_Coordinate);
            this.Controls.Add(this.ParallelepipedButton);
            this.Controls.Add(this.PyramidButton);
            this.Controls.Add(this.CubeButton);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Location = new System.Drawing.Point(15, 15);
            this.MinimumSize = new System.Drawing.Size(965, 495);
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox PointComboBox;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TrackBar trackBar1;

        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;

        private System.Windows.Forms.Button ColorButton;

        private System.Windows.Forms.Button RotateButton;

        private System.Windows.Forms.ComboBox LineComboBox;

        private System.Windows.Forms.Button ChangeColor;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBoxRotationAngle;

        private System.Windows.Forms.Button X_Coordinate;
        private System.Windows.Forms.Button Y_Coordinate;
        private System.Windows.Forms.Button Z_Coordinate;

        private System.Windows.Forms.Button PyramidButton;
        private System.Windows.Forms.Button ParallelepipedButton;

        private System.Windows.Forms.Button CubeButton;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}