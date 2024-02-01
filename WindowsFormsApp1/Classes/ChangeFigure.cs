using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Interfaces;

namespace WindowsFormsApp1.Classes
{
    public class ChangeFigure : IChangeFigure
    {
        private PictureBox PictureBox;
        public List<Points> NewPoints = new List<Points>();
        public List<Lines> NewLines = new List<Lines>();
        private List<Color> savedPointColors = new List<Color>();
        private List<Color> savedLineColors = new List<Color>();

        public ChangeFigure(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }
        
        public void TransformX(List<Points> figurePoints, List<Lines> figureLines, float angle)
        {
            float distance = 300;
            Graphics graphics = Graphics.FromImage(PictureBox.Image);
            graphics.TranslateTransform(PictureBox.Width / 2, PictureBox.Height / 2);
            
            SaveColors(figurePoints, figureLines);
            
            NewPoints.Clear();
            NewLines.Clear();
            
            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].Coordinate.X;
                float y = figurePoints[i].Coordinate.Y;
                float z = figurePoints[i].Coordinate.Z;

                float newY = y * (float)Math.Cos(angle) - z * (float)Math.Sin(angle);
                float newZ = z * (float)Math.Cos(angle) + y * (float)Math.Sin(angle);
                
                Coordinate newCoordinate = new Coordinate(x, newY, newZ);
                Points newPoints = new Points(newCoordinate, figurePoints[i].PointBrush)
                {
                    PointColor = savedPointColors[i]
                };
                NewPoints.Add(newPoints);
            }

            for (int i = 0; i < figureLines.Count; i++)
            {
                List<Coordinate> newCoordinates = new List<Coordinate>();
                for (int j = 0; j < 2; j++)
                {
                    float x = figureLines[i].Vertices[j].X;
                    float y = figureLines[i].Vertices[j].Y;
                    float z = figureLines[i].Vertices[j].Z;
                    
                    float newY = y * (float)Math.Cos(angle) - z * (float)Math.Sin(angle);
                    float newZ = z * (float)Math.Cos(angle) + y * (float)Math.Sin(angle);

                    Coordinate newCoordinate = new Coordinate(x, newY, newZ);
                    newCoordinates.Add(newCoordinate);
                }

                Lines newLines = new Lines(newCoordinates, figureLines[i].LinePen)
                {
                    LineColor = savedLineColors[i]
                };
                NewLines.Add(newLines);
            }
            
            figurePoints.Clear();
            figurePoints.AddRange(NewPoints);

            figureLines.Clear();
            figureLines.AddRange(NewLines);
            
            RestoreColors(figurePoints, figureLines);
            
            Redraw(figurePoints, figureLines, distance);
        }

        public void TransformY(List<Points> figurePoints, List<Lines> figureLines, float angle)
        {
            float distance = 300;
            Graphics graphics = Graphics.FromImage(PictureBox.Image);
            graphics.TranslateTransform(PictureBox.Width / 2, PictureBox.Height / 2);
            
            SaveColors(figurePoints, figureLines);
            
            NewPoints.Clear();
            NewLines.Clear();
            
            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].Coordinate.X;
                float y = figurePoints[i].Coordinate.Y;
                float z = figurePoints[i].Coordinate.Z;

                float newX = x * (float)Math.Cos(angle) + z * (float)Math.Sin(angle);
                float newZ = z * (float)Math.Cos(angle) - x * (float)Math.Sin(angle);
                
                Coordinate newCoordinate = new Coordinate(newX, y, newZ);
                Points newPoints = new Points(newCoordinate, figurePoints[i].PointBrush)
                {
                    PointColor = savedPointColors[i]
                };
                NewPoints.Add(newPoints);
            }

            for (int i = 0; i < figureLines.Count; i++)
            {
                List<Coordinate> newCoordinates = new List<Coordinate>();
                for (int j = 0; j < 2; j++)
                {
                    float x = figureLines[i].Vertices[j].X;
                    float y = figureLines[i].Vertices[j].Y;
                    float z = figureLines[i].Vertices[j].Z;
                    
                    float newX = x * (float)Math.Cos(angle) + z * (float)Math.Sin(angle);
                    float newZ = z * (float)Math.Cos(angle) - x * (float)Math.Sin(angle);

                    Coordinate newCoordinate = new Coordinate(newX, y, newZ);
                    newCoordinates.Add(newCoordinate);
                }

                Lines newLines = new Lines(newCoordinates, figureLines[i].LinePen)
                {
                    LineColor = savedLineColors[i]
                };
                NewLines.Add(newLines);
            }
            
            figurePoints.Clear();
            figurePoints.AddRange(NewPoints);

            figureLines.Clear();
            figureLines.AddRange(NewLines);
            
            RestoreColors(figurePoints, figureLines);
            
            Redraw(figurePoints, figureLines, distance);
        }

        public void TransformZ(List<Points> figurePoints, List<Lines> figureLines, float angle)
        {
            float distance = 300;
            Graphics graphics = Graphics.FromImage(PictureBox.Image);
            graphics.TranslateTransform(PictureBox.Width / 2, PictureBox.Height / 2);
            
            SaveColors(figurePoints, figureLines);
            
            NewPoints.Clear();
            NewLines.Clear();
            
            for (int i = 0; i < figurePoints.Count; i++)
            {
                float x = figurePoints[i].Coordinate.X;
                float y = figurePoints[i].Coordinate.Y;
                float z = figurePoints[i].Coordinate.Z;

                float newX = x * (float)Math.Cos(angle) - y * (float)Math.Sin(angle);
                float newY = y * (float)Math.Cos(angle) + x * (float)Math.Sin(angle);
                
                Coordinate newCoordinate = new Coordinate(newX, newY, z);
                Points newPoints = new Points(newCoordinate, figurePoints[i].PointBrush)
                {
                    PointColor = savedPointColors[i]
                };
                NewPoints.Add(newPoints);
            }

            for (int i = 0; i < figureLines.Count; i++)
            {
                List<Coordinate> newCoordinates = new List<Coordinate>();
                for (int j = 0; j < 2; j++)
                {
                    float x = figureLines[i].Vertices[j].X;
                    float y = figureLines[i].Vertices[j].Y;
                    float z = figureLines[i].Vertices[j].Z;
                    
                    float newX = x * (float)Math.Cos(angle) - y * (float)Math.Sin(angle);
                    float newY = y * (float)Math.Cos(angle) + x * (float)Math.Sin(angle);

                    Coordinate newCoordinate = new Coordinate(newX, newY, z);
                    newCoordinates.Add(newCoordinate);
                }

                Lines newLines = new Lines(newCoordinates, figureLines[i].LinePen)
                {
                    LineColor = savedLineColors[i]
                };
                NewLines.Add(newLines);
            }
            
            figurePoints.Clear();
            figurePoints.AddRange(NewPoints);

            figureLines.Clear();
            figureLines.AddRange(NewLines);
            
            RestoreColors(figurePoints, figureLines);
            
            Redraw(figurePoints, figureLines, distance);
        }

        public void Redraw(List<Points> figurePoints, List<Lines> figureLines, float distance)
        {
            for (int i = 0; i < figureLines.Count; i++)
            {
                figureLines[i].Draw(PictureBox, distance);
            }

            for (int i = 0; i < figurePoints.Count; i++)
            {
                figurePoints[i].Draw(PictureBox, distance);
            }
        }

        public void Zoom(List<Points> figurePoints, List<Lines> figureLines, float changeSize)
        {
            float distance = 300;
            Graphics graphics = Graphics.FromImage(PictureBox.Image);
            graphics.TranslateTransform(PictureBox.Width / 2, PictureBox.Height / 2);
            
            SaveColors(figurePoints, figureLines);
            
            NewPoints.Clear();
            NewLines.Clear();
            
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
                    PointColor = savedPointColors[i]
                };
                NewPoints.Add(newPoints);
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
                    LineColor = savedLineColors[i]
                };
                NewLines.Add(newLines);
            }
            
            figurePoints.Clear();
            figurePoints.AddRange(NewPoints);

            figureLines.Clear();
            figureLines.AddRange(NewLines);
            
            RestoreColors(figurePoints, figureLines);
            
            Redraw(figurePoints, figureLines, distance);
        }
        
        private void SaveColors(List<Points> figurePoints, List<Lines> figureLines)
        {
            savedPointColors.Clear();
            savedLineColors.Clear();

            foreach (var point in figurePoints)
            {
                savedPointColors.Add(point.PointColor);
            }

            foreach (var line in figureLines)
            {
                savedLineColors.Add(line.LineColor);
            }
        }

        private void RestoreColors(List<Points> figurePoints, List<Lines> figureLines)
        {
            for (int i = 0; i < figurePoints.Count; i++)
            {
                figurePoints[i].PointColor = savedPointColors[i];
            }

            for (int i = 0; i < figureLines.Count; i++)
            {
                figureLines[i].LineColor = savedLineColors[i];
            }
        }
    }
}