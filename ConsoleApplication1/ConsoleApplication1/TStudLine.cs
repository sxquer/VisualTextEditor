using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class TStudLine : AStudTools
    {
        private int A, B, C;
        private int currentY;
        private float xStep = .1f;

        private float accuracy = .15f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accuracy">Точность. Если расстояние от точки до целого значения y больше, чем точность, точка не отрисуется</param>
        /// <param name="isSolid">Игнорировать ли точность</param>
        /// <param name="backChar">Фоновый символ</param>
        public TStudLine(float accuracy = .15f, bool isSolid = true, char backChar = '#')
        {
            this.accuracy = accuracy;
            this.IsSolid = isSolid;
            this.BackChar = backChar;
        }
        
        /// <summary>
        /// Выставляет точность. Если y отклоняется от целого значения более, чем на эту величину, он не будет нарисован на канве.
        /// </summary>
        public float Accuracy
        {
            get { return accuracy; }
            set
            {
                if (value < 0.01) value = 0.01f;
                accuracy = value;
                //IsSolid = false;
            }
        }

        /// <summary>
        /// Рисует прямую линию на канве
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        override public void Draw(TStudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            #region Подготовка параметров для вычисления
            A = y1 - y2;
            B = x2 - x1;
            C = x1 * y2 - x2 * y1;

            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);
            DevTools.CheckRightX(ref x2, canvas);
            DevTools.CheckRightX(ref y2, canvas);
            #endregion

            for (float i = x1; i <= x2; i += xStep)
            {
                for (int j = y1; j <= y2; j++)
                {
                    //На случай, если x2-x1 == 0
                    currentY = j;

                    if (checkXY(i, j))
                    {
                        if (currentY > canvas.GetHeight()) continue;
                        canvas.Field[(int)Math.Round(i), currentY] = BackChar;

                    }
                }
            }
        }

        /// <summary>
        /// Вычисляет y и проверяет, проходит ли точка по точности.
        /// </summary>
        /// <param name="x">Точка из области определения функции</param>
        /// <param name="y">Точка из области определения функции</param>
        /// <returns></returns>
        private bool checkXY(float x, int y)
        {
            float tempY = -(A * x + C);
            tempY = (B != 0) ? tempY / B : currentY;
            float fract = tempY - (int) tempY;
            if ((fract < accuracy) || (fract > (1 - accuracy)) || IsSolid)
            {
                currentY = (int) Math.Round(tempY);
                if (currentY == y) return true;
            }
            currentY = -1;
            return false;
        }

        public void DrawWo(TStudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);
  
            int dx = x2 - x1;
            int dy = y2 - y1;
            double gradient = dy / dx;
  
            // обработать начальную точку
            double xend = DevTools.round(x1); 
            double yend = y1 + gradient * (xend - x1);
           
            double xgap = 1 - DevTools.fpart(x1 + 0.5);
            double xpxl1 = xend;  // будет использоваться в основном цикле
            int ypxl1 = DevTools.ipart(yend);
            DevTools.plot(canvas, Convert.ToInt32(xpxl1), Convert.ToInt32(ypxl1), Convert.ToDouble(1 - DevTools.fpart(yend) * xgap));
           
            DevTools.plot(canvas, Convert.ToInt32(xpxl1), Convert.ToInt32(ypxl1 + 1), Convert.ToDouble(DevTools.fpart(yend) * xgap));
            double intery = yend + gradient; // первое y-пересечение для цикла
        
            // обработать конечную точку
            xend = DevTools.round(x2);
            yend = y2 + gradient * (xend - x2);
            xgap = DevTools.fpart(x2 + 0.5);
            double xpxl2 = xend;  // будет использоваться в основном цикле
            double ypxl2 = DevTools.ipart(yend);
            DevTools.plot(canvas, Convert.ToInt32(xpxl2), Convert.ToInt32(ypxl2), Convert.ToDouble(1 - DevTools.fpart(yend) * xgap));
            DevTools.plot(canvas, Convert.ToInt32(xpxl2), Convert.ToInt32(ypxl2 + 1), Convert.ToDouble(DevTools.fpart(yend) * xgap));
     
           // основной цикл
            for (double i = xpxl1 + 1; i < xpxl2; i++)
		    {
                DevTools.plot(canvas, (int)i, DevTools.ipart(intery), 1 - DevTools.fpart(intery));
                DevTools.plot(canvas, (int)i, DevTools.ipart(intery) + 1, DevTools.fpart(intery));
                intery = intery + gradient;
		    }
        }
    }
}
