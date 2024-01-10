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
            this.UpdateDataGrid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(554, 452);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // CubeButton
            // 
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
            this.dataGridView1.Location = new System.Drawing.Point(572, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(375, 344);
            this.dataGridView1.TabIndex = 10;
            // 
            // UpdateDataGrid
            // 
            this.UpdateDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDataGrid.Location = new System.Drawing.Point(572, 500);
            this.UpdateDataGrid.Name = "UpdateDataGrid";
            this.UpdateDataGrid.Size = new System.Drawing.Size(134, 59);
            this.UpdateDataGrid.TabIndex = 11;
            this.UpdateDataGrid.Text = "Update";
            this.UpdateDataGrid.UseVisualStyleBackColor = true;
            this.UpdateDataGrid.Click += new System.EventHandler(this.UpdateDataGrid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(958, 614);
            this.Controls.Add(this.UpdateDataGrid);
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
            this.Location = new System.Drawing.Point(15, 15);
            this.MinimumSize = new System.Drawing.Size(650, 430);
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button UpdateDataGrid;

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