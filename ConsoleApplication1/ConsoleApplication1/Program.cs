using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rec = new StudRectangle();
            var line = new StudLine();
            var circle = new StudCircle();

            #region Тест 1 (Прямоугольники)

            var canvas = new StudCanvas(15, 15);

            rec.IsSolid = false;
            rec.Draw(canvas, 8, 1, 1, 8);

            rec.IsSolid = true;
            rec.BackChar = '*';
            rec.Draw(canvas, 3, 3, 6, 6);

            rec.BackChar = ' ';
            rec.Draw(canvas, 10, 10, 10, 3);

            rec.BackChar = 'S';
            rec.Draw(canvas, 12, 12, 20, 20);

            rec.Draw(canvas, 4000, 3000, 2000, 1000);

            canvas.Draw("tests/1.txt");

            #endregion

            #region Тест 2 (Линии)

            canvas = new StudCanvas(40, 40);

            line.IsSolid = true;
            line.Accuracy = 0.1f;
            line.Draw(canvas, 5, 5, 20, 15);

            line.IsSolid = false;
            line.Draw(canvas, 1, 1, 40, 4);

            line.Draw(canvas, 5, 10, 20, 20);

            line.Accuracy = 0.1f;
            line.Draw(canvas, 5, 21, 20, 15);

            line.BackChar = '@';
            line.Draw(canvas, 1000, 1000, 2000, 2000);

            line.Draw(canvas, 20, 20, 50, 20);

            line.Draw(canvas, 20, 20, 20, 50);

            line.Draw(canvas, 15, 20, 16, 30);

            canvas.Draw("tests/2.txt");

            #endregion

            #region Тест 3 (Круги)

            canvas = new StudCanvas(height: 50);
            circle.IsSolid = true;
            circle.Draw(canvas, 5, 5, 20, 15);

            circle.IsSolid = false;
            circle.Step = 1;
            circle.Draw(canvas, 1, 1, 40, 4);

            circle.Step = .1f;
            circle.Draw(canvas, 80, 30, 130, 80);

            circle.BackChar = '%';
            circle.IsSolid = true;
            circle.Draw(canvas, 20, 40, 60, 5000);

            circle.Draw(canvas, 50000, 60000, 1000, 2000);

            circle.Step = .3f;
            circle.IsSolid = false;
            circle.Draw(canvas, 45, 15, 80, 50);

            circle.Step = .1f;
            circle.IsSolid = true;
            circle.Draw(canvas, 55, 25, 70, 40);

            canvas.Draw("tests/3.txt");

            #endregion

            #region Тест 4 (Canvas.Mask && Canavs.Paste)

            canvas.Mask('%', 'U');
            canvas.Mask('.', ' ');

            var canvas2 = new StudCanvas(10, 10);
            canvas.Paste(canvas2, 5, 5);
            canvas.Paste(canvas2, 95, 10);
            canvas.Paste(canvas2, 10, 45);
            canvas.Paste(canvas2, 1000, 4500);

            canvas.Draw("tests/4.txt");

            #endregion

            #region Тест 5 (Смайлик)

            canvas = new StudCanvas();
            circle.Draw(canvas, 5, 5, 95, 95);

            circle.IsSolid = false;
            circle.BackChar = '$';
            circle.Step = .05f;
            circle.Draw(canvas, 4, 4, 96, 96);

            circle = new StudCircle(.5f, backChar: '*');
            circle.Draw(canvas, 25, 25, 45, 45);
            circle.Draw(canvas, 55, 25, 75, 45);

            circle = new StudCircle(.1f, backChar: '%');
            circle.Draw(canvas, 27, 35, 35, 45);
            circle.Draw(canvas, 57, 35, 65, 45);

            circle = new StudCircle(.1f, backChar: '@');
            circle.Draw(canvas, 35, 50, 65, 80);

            canvas.Draw("tests/5.txt");

            #endregion

            #region Тест 6 (Линии)

            canvas = new StudCanvas();
            line = new StudLine(0.51f, false);
            line.Draw(canvas, 10, 10, 50, 50);

            line.Draw(canvas, 10, 50, 90, 70);

            canvas.Draw("tests/6.txt");

            #endregion

            #region Тест 7 (Круги Брезенхейма)

            canvas = new StudCanvas();
            circle = new StudCircle();
            circle.DrawBresenham(canvas, 10, 30, 30);
            //Circle.DrawBresenham(Canvas, 50, 80, 80);
            canvas.Draw("tests/7.txt");

            #endregion

            #region Тест 8 (Линия Ву)

            canvas = new StudCanvas(backChar: ' ');
            line = new StudLine();
            line.DrawWo(canvas, 10, 10, 50, 50);
            line.DrawWo(canvas, 10, 50, 90, 70);
            line.DrawWo(canvas, 10, 50, 90, 63);
            canvas.Draw("tests/8.txt");

            #endregion

            #region Тест 9 (Функция Plot)

            canvas = new StudCanvas();
            DevTools.Plot(canvas, 5, 5, 0.27);
            DevTools.Plot(canvas, 5, 6, 0.12);
            DevTools.Plot(canvas, 5, 7, .57);
            DevTools.Plot(canvas, 5, 8, .81);
            canvas.Draw("tests/9.txt");

            #endregion
        }

    }
}
