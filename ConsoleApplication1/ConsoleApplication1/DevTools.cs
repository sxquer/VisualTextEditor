using System;

namespace ConsoleApplication1
{
    static class DevTools
    {
        /// <summary>
        /// Меняет местами значения параметров, так, чтобы первый был не больше второго.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static public void Normalize(ref ushort a, ref ushort b)
        {
            if (a > b)
            {
                ushort buffer = a;
                a = b;
                b = buffer;
            }
        }

        /// <summary>
        /// Проверяет, не выходит ли данный х за правый край канвы. Если выходит - устанавливает его на предельно допустимое значение
        /// </summary>
        /// <param name="x">Проверяемое значение</param>
        /// <param name="canvas">Ссылка на канву</param>
        static public void CheckRightX(ref ushort x, StudCanvas canvas)
        {
            ushort width = Convert.ToUInt16(canvas.GetWidth() - 1);
            x = (x > width) ? width : x;
        }

        /// <summary>
        /// Проверяет, не выходит ли данный y за нижний край канвы. Если выходит - устанавливает его на предельно допустимое значение
        /// </summary>
        /// <param name="y">Проверяемое значение</param>
        /// <param name="canvas">Ссылка на канву</param>
        static public void CheckLowY(ref int y, StudCanvas canvas)
        {
            int height = canvas.GetHeight() - 1;
            y = (y > canvas.GetHeight()) ? height : y;
        }

        /// <summary>
        /// Проверяет, не выходит ли данный y за нижний край канвы. Если выходит - устанавливает его на предельно допустимое значение
        /// </summary>
        /// <param name="y">Проверяемое значение</param>
        /// <param name="canvas">Ссылка на канву</param>
        static public void CheckLowY(ref ushort y, StudCanvas canvas)
        {
            ushort height = Convert.ToUInt16(canvas.GetHeight() - 1);
            y = (y > height) ? height : y;
        }

        //TODO: Причесать функции
        #region Функции для алгоритма Wo

        static public int Ipart(double x)
        {
            return (int)x;
        }

        static public double Fpart(double x)
        {
            return x - Ipart(x);
        }
        
        static public int Round(double x)
        {
            return Ipart(x + .5f);
        }

        static public void Plot(StudCanvas canvas, int x, int y, double br)
        {
            char[] backChars = { ',', '/', '%', '$', 'A' };
            if (br < 0 || br >= 1) br = 0.99;
            canvas.Field[x, y] = backChars[(int) (br / .20f)];
        }

        #endregion
    }
}
