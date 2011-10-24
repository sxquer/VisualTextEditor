using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Canvas = new TStudCanvas();
            var Rec = new TStudRectangle();
            var Line = new TStudLine();
            var Circle = new TStudCircle();

            #region Тест 1 (Прямоугольники)

            Canvas = new TStudCanvas(15, 15);

            Rec.IsSolid = false;
            Rec.Draw(Canvas, 8, 1, 1, 8);

            Rec.IsSolid = true;
            Rec.BackChar = '*';
            Rec.Draw(Canvas, 3, 3, 6, 6);

            Rec.BackChar = ' ';
            Rec.Draw(Canvas, 10, 10, 10, 3);

            Rec.BackChar = 'S';
            Rec.Draw(Canvas, 12, 12, 20, 20);

            Rec.Draw(Canvas, 4000, 3000, 2000, 1000);

            Canvas.Draw("tests/1.txt");

            #endregion

            #region Тест 2 (Линии)

            Canvas = new TStudCanvas(40, 40);

            Line.IsSolid = true;
            Line.Accuracy = 0.1f;
            Line.Draw(Canvas, 5, 5, 20, 15);

            Line.IsSolid = false;
            Line.Draw(Canvas, 1, 1, 40, 4);

            Line.Draw(Canvas, 5, 10, 20, 20);

            Line.Accuracy = 0.1f;
            Line.Draw(Canvas, 5, 21, 20, 15);

            Line.BackChar = '@';
            Line.Draw(Canvas, 1000, 1000, 2000, 2000);

            Line.Draw(Canvas, 20, 20, 50, 20);

            Line.Draw(Canvas, 20, 20, 20, 50);

            Line.Draw(Canvas, 15, 20, 16, 30);

            Canvas.Draw("tests/2.txt");

            #endregion

            #region Тест 3 (Круги)

            Canvas = new TStudCanvas(height: 50);
            Circle.IsSolid = true;
            Circle.Draw(Canvas, 5, 5, 20, 15);

            Circle.IsSolid = false;
            Circle.Step = 1;
            Circle.Draw(Canvas, 1, 1, 40, 4);

            Circle.Step = .1f;
            Circle.Draw(Canvas, 80, 30, 130, 80);

            Circle.BackChar = '%';
            Circle.IsSolid = true;
            Circle.Draw(Canvas, 20, 40, 60, 5000);

            Circle.Draw(Canvas, 50000, 60000, 1000, 2000);

            Circle.Step = .3f;
            Circle.IsSolid = false;
            Circle.Draw(Canvas, 45, 15, 80, 50);

            Circle.Step = .1f;
            Circle.IsSolid = true;
            Circle.Draw(Canvas, 55, 25, 70, 40);

            Canvas.Draw("tests/3.txt");

            #endregion

            #region Тест 4 (Canvas.Mask && Canavs.Paste)

            Canvas.Mask('%', 'U');
            Canvas.Mask('.', ' ');

            var Canvas2 = new TStudCanvas(10, 10, 'x');
            Canvas.Paste(Canvas2, 5, 5);
            Canvas.Paste(Canvas2, 95, 10);
            Canvas.Paste(Canvas2, 10, 45);
            Canvas.Paste(Canvas2, 1000, 4500);

            Canvas.Draw("tests/4.txt");

            #endregion

            #region Тест 5 (Смайлик)

            Canvas = new TStudCanvas();
            Circle.Draw(Canvas, 5, 5, 95, 95);

            Circle.IsSolid = false;
            Circle.BackChar = '$';
            Circle.Step = .05f;
            Circle.Draw(Canvas, 4, 4, 96, 96);

            Circle = new TStudCircle(.5f, backChar: '*');
            Circle.Draw(Canvas, 25, 25, 45, 45);
            Circle.Draw(Canvas, 55, 25, 75, 45);

            Circle = new TStudCircle(.1f, backChar: '%');
            Circle.Draw(Canvas, 27, 35, 35, 45);
            Circle.Draw(Canvas, 57, 35, 65, 45);

            Circle = new TStudCircle(.1f, backChar: '@');
            Circle.Draw(Canvas, 35, 50, 65, 80);

            Canvas.Draw("tests/5.txt");

            #endregion

            #region Тест 6 (Линии)

            Canvas = new TStudCanvas();
            Line = new TStudLine(0.51f, false);
            Line.Draw(Canvas, 10, 10, 50, 50);

            Line.Draw(Canvas, 10, 50, 90, 70);

            Canvas.Draw("tests/6.txt");

            #endregion

            #region Тест 7 (Круги Брезенхейма)

            Canvas = new TStudCanvas();
            Circle = new TStudCircle();
            Circle.DrawBresenham(Canvas, 10, 30, 30);
            //Circle.DrawBresenham(Canvas, 50, 80, 80);
            Canvas.Draw("tests/7.txt");

            #endregion

            #region Тест 8 (Линия Ву)

            Canvas = new TStudCanvas(emptyChar:' ');
            Line = new TStudLine();
            Line.DrawWo(Canvas, 10, 10, 50, 50);
            Line.DrawWo(Canvas, 10, 50, 90, 70);
            Canvas.Draw("tests/8.txt");

            #endregion
        }
    }
}
