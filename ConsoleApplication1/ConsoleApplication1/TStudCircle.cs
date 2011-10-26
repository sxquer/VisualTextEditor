using System;


namespace ConsoleApplication1
{
    class StudCircle : AStudTools
    {
        private int _currentY1, _currentY2 = -1;
        
        private double _x0, _y0;
        private double _radius;

        public float Step { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xStep">Точность прохода по x</param>
        /// <param name="isSolid">Является ли фигура заполненой внутри контура</param>
        /// <param name="backChar">Фоновый символ</param>
        public StudCircle(float xStep = 0.1f, bool isSolid = true, char backChar = '#')
        {
            Step = xStep;
            IsSolid = isSolid;
            BackChar = backChar;
        }
        
        /// <summary>
        /// Рисует круг
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        override public void Draw(StudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            #region Подготовка параметров для вычисления
            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);

            // Приводим прямоугольник к квадрату максимального размера, левый верхний угол остается на месте
            if ((x2 - x1) > (y2 - y1))
            {
                x2 = Convert.ToUInt16(x1 + y2 - y1);
            }

            _radius = (double) (x2 - x1) / 2;

            _x0 = x1 + _radius;
            _y0 = y1 + _radius;

            DevTools.CheckRightX(ref x2, canvas);
            #endregion

            for (float i = x1; i <= x2; i += Step)
            {
                CheckY(i);
                if (IsSolid)
                {
                    DevTools.CheckLowY(ref _currentY2, canvas);
                    for (int j = _currentY1; j <= _currentY2; j++) 
                    {
                        canvas.Field[(int)Math.Round(i), j] = BackChar;
                    }
                }
                else
                {
                    if (_currentY1 >= canvas.GetHeight()) continue;
                    canvas.Field[(int) Math.Round(i), _currentY1] = BackChar;
                        
                    if (_currentY2 >= canvas.GetHeight()) continue;
                    canvas.Field[(int) Math.Round(i), _currentY2] = BackChar;
                }
            }
        }

        //TODO: Обработать выход за границы канвы
        /// <summary>
        /// Рисует круг методом Брезенхейма
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="radius"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        public void DrawBresenham(StudCanvas canvas, int radius, int x0, int y0)
        {
            int x = 0;
            int y = radius;
            int delta = 2 - 2 * radius;
            while (y >= 0)
            {
                canvas.Field[x0 + x, y0 + y] = BackChar;
                canvas.Field[x0 + x, y0 - y] = BackChar;
                canvas.Field[x0 - x, y0 + y] = BackChar;
                canvas.Field[x0 - x, y0 - y] = BackChar;
                int error = 2 * (delta + y) - 1;
                if (delta < 0 && error <= 0)
                {
                    ++x;
                    delta += 2 * x + 1;
                    continue;
                }
                error = 2 * (delta - x) - 1;
                if (delta > 0 && error > 0)
                {
                    --y;
                    delta += 1 - 2 * y;
                    continue;
                }
                ++x;
                delta += 2 * (x - y);
                --y;
            }

        }

        /// <summary>
        /// Вычисляет y и проверяет, проходит ли точка по точности.
        /// </summary>
        /// <param name="x">Точка из области определения функции</param>
        /// <returns></returns>
        private void CheckY(float x)
        {
            double tempY1 = _y0 - Math.Sqrt(Math.Pow(_radius, 2) - Math.Pow(x - _x0, 2));
            double tempY2 = _y0 + Math.Sqrt(Math.Pow(_radius, 2) - Math.Pow(x - _x0, 2));

            if ((tempY1 - (int) tempY1) == (tempY2 - (int) tempY2))
            {
                _currentY1 = (int) Math.Floor(tempY1);
                _currentY2 = (int) Math.Ceiling(tempY2);
                return;
            }

            _currentY1 = (int) Math.Round(tempY1);
            _currentY2 = (int) Math.Round(tempY2);

            return;
        }
    }
}
