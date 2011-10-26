using System;

namespace ConsoleApplication1
{
    class StudLine : AStudTools
    {
        private int _a, _b, _c;
        private int _currentY;
        private const float XStep = .1f;

        private float _accuracy = .15f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accuracy">Точность. Если расстояние от точки до целого значения y больше, чем точность, точка не отрисуется</param>
        /// <param name="isSolid">Игнорировать ли точность</param>
        /// <param name="backChar">Фоновый символ</param>
        public StudLine(float accuracy = .15f, bool isSolid = true, char backChar = '#')
        {
            _accuracy = accuracy;
            IsSolid = isSolid;
            BackChar = backChar;
        }
        
        /// <summary>
        /// Выставляет точность. Если y отклоняется от целого значения более, чем на эту величину, он не будет нарисован на канве.
        /// </summary>
        public float Accuracy
        {
            get { return _accuracy; }
            set
            {
                if (value < 0.01) value = 0.01f;
                _accuracy = value;
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
        override public void Draw(StudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            #region Подготовка параметров для вычисления
            _a = y1 - y2;
            _b = x2 - x1;
            _c = x1 * y2 - x2 * y1;

            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);
            DevTools.CheckRightX(ref x2, canvas);
            DevTools.CheckRightX(ref y2, canvas);
            #endregion

            for (float i = x1; i <= x2; i += XStep)
            {
                for (int j = y1; j <= y2; j++)
                {
                    //На случай, если x2-x1 == 0
                    _currentY = j;

                    if (CheckXY(i, j))
                    {
                        if (_currentY > canvas.GetHeight()) continue;
                        canvas.Field[(int)Math.Round(i), _currentY] = BackChar;

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
        private bool CheckXY(float x, int y)
        {
            float tempY = -(_a * x + _c);
            tempY = (_b != 0) ? tempY / _b : _currentY;
            float fract = tempY - (int) tempY;
            if ((fract < _accuracy) || (fract > (1 - _accuracy)) || IsSolid)
            {
                _currentY = (int) Math.Round(tempY);
                if (_currentY == y) return true;
            }
            _currentY = -1;
            return false;
        }

        public void DrawWo(StudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);
  
            int dx = x2 - x1;
            int dy = y2 - y1;
            double gradient = (double)dy / dx;

            // обработать начальную точку
            double xend = DevTools.Round(x1); 
            double yend = y1 + gradient * (xend - x1);
           
            double xgap = 1 - DevTools.Fpart(x1 + 0.5);
            double xpxl1 = xend;  // будет использоваться в основном цикле
            int ypxl1 = DevTools.Ipart(yend);
            DevTools.Plot(canvas, Convert.ToInt32(xpxl1), Convert.ToInt32(ypxl1), Convert.ToDouble(1 - DevTools.Fpart(yend) * xgap));
           
            DevTools.Plot(canvas, Convert.ToInt32(xpxl1), Convert.ToInt32(ypxl1 + 1), Convert.ToDouble(DevTools.Fpart(yend) * xgap));
            double intery = yend + gradient; // первое y-пересечение для цикла
        
            // обработать конечную точку
            xend = DevTools.Round(x2);
            yend = y2 + gradient * (xend - x2);
            xgap = DevTools.Fpart(x2 + 0.5);
            double xpxl2 = xend;  // будет использоваться в основном цикле
            double ypxl2 = DevTools.Ipart(yend);
            DevTools.Plot(canvas, Convert.ToInt32(xpxl2), Convert.ToInt32(ypxl2), Convert.ToDouble(1 - DevTools.Fpart(yend) * xgap));
            DevTools.Plot(canvas, Convert.ToInt32(xpxl2), Convert.ToInt32(ypxl2 + 1), Convert.ToDouble(DevTools.Fpart(yend) * xgap));
     
           // основной цикл
            for (double i = xpxl1 + 1; i < xpxl2; i++)
		    {
                DevTools.Plot(canvas, (int)i, DevTools.Ipart(intery), 1 - DevTools.Fpart(intery));
                DevTools.Plot(canvas, (int)i, DevTools.Ipart(intery) + 1, DevTools.Fpart(intery));
                intery = intery + gradient;
		    }
        }
    }
}
