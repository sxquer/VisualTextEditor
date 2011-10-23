using System;
using System.Collections.Generic;
using System.Text;

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
            ushort buffer = b;
            if (a > b)
            {
                buffer = a;
                a = b;
                b = buffer;
            }
        }

        /// <summary>
        /// Проверяет, не выходит ли данный х за правый край канвы. Если выходит - устанавливает его на предельно допустимое значение
        /// </summary>
        /// <param name="x">Проверяемое значение</param>
        /// <param name="canvas">Ссылка на канву</param>
        static public void CheckRightX(ref ushort x, TStudCanvas canvas)
        {
            ushort width = Convert.ToUInt16(canvas.GetWidth() - 1);
            x = (x > width) ? width : x;
        }

        /// <summary>
        /// Проверяет, не выходит ли данный y за нижний край канвы. Если выходит - устанавливает его на предельно допустимое значение
        /// </summary>
        /// <param name="y">Проверяемое значение</param>
        /// <param name="canvas">Ссылка на канву</param>
        static public void CheckLowY(ref int y, TStudCanvas canvas)
        {
            int height = canvas.GetHeight() - 1;
            y = (y > canvas.GetHeight()) ? height : y;
        }

        /// <summary>
        /// Проверяет, не выходит ли данный y за нижний край канвы. Если выходит - устанавливает его на предельно допустимое значение
        /// </summary>
        /// <param name="y">Проверяемое значение</param>
        /// <param name="canvas">Ссылка на канву</param>
        static public void CheckLowY(ref ushort y, TStudCanvas canvas)
        {
            ushort height = Convert.ToUInt16(canvas.GetHeight() - 1);
            y = (y > height) ? height : y;
        }
    }
}
