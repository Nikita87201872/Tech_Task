using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public class ChangeFigure : AbstractDrawer
    {
        private readonly PictureBox _pictureBox;
        private readonly List<Points> _newPoints = new List<Points>();
        private readonly List<Lines> _newLines = new List<Lines>();
        private readonly List<Color> _savedPointColors = new List<Color>();
        private readonly List<Color> _savedLineColors = new List<Color>();

        public ChangeFigure(PictureBox pictureBox) : base(pictureBox)
        {
            _pictureBox = pictureBox;
        }
        public void Rotate(List<Points> figurePoints, List<Lines> figureLines, float angle, char axis)
        {
            SaveColors(figurePoints, figureLines);

            List<Points> newPoints = new List<Points>();
            List<Lines> newLines = new List<Lines>();

            foreach (Points point in figurePoints)
            {
                float x = point.Coordinate.X;
                float y = point.Coordinate.Y;
                float z = point.Coordinate.Z;

                float newX = x, newY = y, newZ = z;

                switch (axis)
                {
                    case 'X':
                        newY = y * (float)Math.Cos(angle) - z * (float)Math.Sin(angle);
                        newZ = z * (float)Math.Cos(angle) + y * (float)Math.Sin(angle);
                        break;
                    case 'Y':
                        newX = x * (float)Math.Cos(angle) + z * (float)Math.Sin(angle);
                        newZ = z * (float)Math.Cos(angle) - x * (float)Math.Sin(angle);
                        break;
                    case 'Z':
                        newX = x * (float)Math.Cos(angle) - y * (float)Math.Sin(angle);
                        newY = y * (float)Math.Cos(angle) + x * (float)Math.Sin(angle);
                        break;
                }

                Coordinate newCoordinate = new Coordinate(newX, newY, newZ);
                Points newPoint = new Points(newCoordinate, point.PointBrush)
                {
                    PointColor = point.PointColor
                };
                newPoints.Add(newPoint);
            }

            foreach (Lines line in figureLines)
            {
                List<Coordinate> newCoordinates = new List<Coordinate>();
                foreach (Coordinate coordinate in line.Vertices)
                {
                    float x = coordinate.X;
                    float y = coordinate.Y;
                    float z = coordinate.Z;

                    float newX = x, newY = y, newZ = z;

                    switch (axis)
                    {
                        case 'X':
                            newY = y * (float)Math.Cos(angle) - z * (float)Math.Sin(angle);
                            newZ = z * (float)Math.Cos(angle) + y * (float)Math.Sin(angle);
                            break;
                        case 'Y':
                            newX = x * (float)Math.Cos(angle) + z * (float)Math.Sin(angle);
                            newZ = z * (float)Math.Cos(angle) - x * (float)Math.Sin(angle);
                            break;
                        case 'Z':
                            newX = x * (float)Math.Cos(angle) - y * (float)Math.Sin(angle);
                            newY = y * (float)Math.Cos(angle) + x * (float)Math.Sin(angle);
                            break;
                    }

                    Coordinate newCoordinate = new Coordinate(newX, newY, newZ);
                    newCoordinates.Add(newCoordinate);
                }

                Lines newLine = new Lines(newCoordinates, line.LinePen)
                {
                    LineColor = line.LineColor
                };
                newLines.Add(newLine);
            }

            figurePoints.Clear();
            figurePoints.AddRange(newPoints);

            figureLines.Clear();
            figureLines.AddRange(newLines);

            Draw(figureLines, figurePoints);
        }

        public void Zoom(List<Points> figurePoints, List<Lines> figureLines, float changeSize)
        {
            Graphics graphics = Graphics.FromImage(_pictureBox.Image);
            graphics.TranslateTransform((float)_pictureBox.Width / 2, (float)_pictureBox.Height / 2);
            
            SaveColors(figurePoints, figureLines);
            
            _newPoints.Clear();
            _newLines.Clear();
            
            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].Coordinate.X;
                float y = figurePoints[i].Coordinate.Y;
                float z = figurePoints[i].Coordinate.Z;

                float newX = x * changeSize;
                float newY = y * changeSize;
                float newZ = z * changeSize;
                
                Coordinate newCoordinate = new Coordinate(newX, newY, newZ);
                Points newPoints = new Points(newCoordinate, figurePoints[i].PointBrush)
                {
                    PointColor = _savedPointColors[i]
                };
                _newPoints.Add(newPoints);
            }

            for (int i = 0; i < figureLines.Count; i++)
            {
                List<Coordinate> newCoordinates = new List<Coordinate>();
                for (int j = 0; j < 2; j++)
                {
                    float x = figureLines[i].Vertices[j].X;
                    float y = figureLines[i].Vertices[j].Y;
                    float z = figureLines[i].Vertices[j].Z;
                    
                    float newX = x * changeSize;
                    float newY = y * changeSize;
                    float newZ = z * changeSize;

                    Coordinate newCoordinate = new Coordinate(newX, newY, newZ);
                    newCoordinates.Add(newCoordinate);
                }

                Lines newLines = new Lines(newCoordinates, figureLines[i].LinePen)
                {
                    LineColor = _savedLineColors[i]
                };
                _newLines.Add(newLines);
            }
            
            figurePoints.Clear();
            figurePoints.AddRange(_newPoints);

            figureLines.Clear();
            figureLines.AddRange(_newLines);
            
            RestoreColors(figurePoints, figureLines);
            Draw(figureLines, figurePoints);
        }
        
        private void SaveColors(List<Points> figurePoints, List<Lines> figureLines)
        {
            _savedPointColors.Clear();
            _savedLineColors.Clear();

            foreach (Points point in figurePoints)
            {
                _savedPointColors.Add(point.PointColor);
            }

            foreach (Lines line in figureLines)
            {
                _savedLineColors.Add(line.LineColor);
            }
        }

        private void RestoreColors(List<Points> figurePoints, List<Lines> figureLines)
        {
            for (int i = 0; i < figurePoints.Count; i++)
            {
                figurePoints[i].PointColor = _savedPointColors[i];
            }

            for (int i = 0; i < figureLines.Count; i++)
            {
                figureLines[i].LineColor = _savedLineColors[i];
            }
        }
    }
}