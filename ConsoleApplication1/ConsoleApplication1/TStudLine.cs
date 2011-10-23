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
    }
}
