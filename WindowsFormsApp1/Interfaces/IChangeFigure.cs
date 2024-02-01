using System.Collections.Generic;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1.Interfaces
{
    public interface IChangeFigure
    {
        void TransformX(List<Points> figurePoints, List<Lines> figureLines, float angle);
        void TransformY(List<Points> figurePoints, List<Lines> figureLines, float angle);
        void TransformZ(List<Points> figurePoints, List<Lines> figureLines, float angle);
        void Redraw(List<Points> figurePoints, List<Lines> figureLines, float distance);
        void Zoom(List<Points> figurePoints, List<Lines> figureLines, float changeSize);
        
    }
}