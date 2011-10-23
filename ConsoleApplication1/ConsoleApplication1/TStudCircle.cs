// Тест для коммита номер 2


using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApplication1
{
    class TStudCircle : AStudTools
    {
        private int currentY1, currentY2 = -1;
        
        private double x0, y0;
        private double radius;

        private float xStep = 0.1f;

        public float Step
        {
            get { return xStep; }
            set { xStep = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xStep">Точность прохода по x</param>
        /// <param name="isSolid">Является ли фигура заполненой внутри контура</param>
        /// <param name="backChar">Фоновый символ</param>
        public TStudCircle(float xStep = 0.1f, bool isSolid = true, char backChar = '#')
        {
            this.xStep = xStep;
            this.IsSolid = isSolid;
            this.BackChar = backChar;
        }
        
        /// <summary>
        /// Рисует круг
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        override public void Draw(TStudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            #region Подготовка параметров для вычисления
            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);

            // Приводим прямоугольник к квадрату максимального размера, левый верхний угол остается на месте
            if ((x2 - x1) > (y2 - y1))
            {
                x2 = Convert.ToUInt16(x1 + y2 - y1);
            }
            else
            {
                y2 = Convert.ToUInt16(y1 + x2 - x1);
            }

            radius = (double) (x2 - x1) / 2;

            x0 = x1 + radius;
            y0 = y1 + radius;

            DevTools.CheckRightX(ref x2, canvas);
            #endregion

            for (float i = x1; i <= x2; i += xStep)
            {
                checkY(i);
                if (IsSolid)
                {
                    DevTools.CheckLowY(ref currentY2, canvas);
                    for (int j = currentY1; j <= currentY2; j++)
                    {
                        canvas.Field[(int)Math.Round(i), j] = BackChar;
                    }
                }
                else
                {
                    if (currentY1 >= canvas.GetHeight()) continue;
                    canvas.Field[(int) Math.Round(i), currentY1] = BackChar;
                        
                    if (currentY2 >= canvas.GetHeight()) continue;
                    canvas.Field[(int) Math.Round(i), currentY2] = BackChar;
                }
            }
        }

        /// <summary>
        /// Вычисляет y и проверяет, проходит ли точка по точности.
        /// </summary>
        /// <param name="x">Точка из области определения функции</param>
        /// <param name="y">Переменная, куда попадет вычисленный y, либо -1, если точка не попала в зону точности</param>
        /// <returns></returns>
        private void checkY(float x)
        {
            double tempY1 = y0 - Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(x - x0, 2));
            double tempY2 = y0 + Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(x - x0, 2));

            if ((tempY1 - (int) tempY1) == (tempY2 - (int) tempY2))
            {
                currentY1 = (int) Math.Floor(tempY1);
                currentY2 = (int) Math.Ceiling(tempY2);
                return;
            }

            currentY1 = (int) Math.Round(tempY1);
            currentY2 = (int) Math.Round(tempY2);

            return;
        }
    }
}
