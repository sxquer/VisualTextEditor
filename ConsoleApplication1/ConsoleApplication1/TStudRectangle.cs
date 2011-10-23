using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class TStudRectangle: AStudTools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSolid">Является ли фигура заполненой внутри контура</param>
        /// <param name="backChar">Фоновый символ</param>
        public TStudRectangle(bool isSolid = true, char backChar = '#')
        {
            this.IsSolid = isSolid;
            this.BackChar = backChar;
        }
        
        /// <summary>
        /// Строит прямоугольник с заданными параметрами
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        override public void Draw(TStudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2)
        {
            DevTools.Normalize(ref x1, ref x2);
            DevTools.Normalize(ref y1, ref y2);
            
            if (IsSolid)
            {
                DevTools.CheckRightX(ref x2, canvas);
                DevTools.CheckLowY(ref y2, canvas);
                for (int i = x1; i <= x2; i++)
                {
                    for (int j = y1; j <= y2; j++)
                    {
                        canvas.Field[i, j] = BackChar;
                    }
                }
            }
            else
            {
                int height = canvas.GetHeight();
                for (int i = x1; i <= x2; i++)
                {
                    if (y1 >= height) continue;
                    canvas.Field[i, y1] = BackChar;

                    if (y2 >= height) break;
                    canvas.Field[i, y2] = BackChar;  
                }

                int width = canvas.GetWidth();
                for (int i = y1; i <= y2; i++)
                {
                    if (x1 >= width) continue;
                    canvas.Field[x1, i] = BackChar;

                    if (x2 >= width) break;
                    canvas.Field[x2, i] = BackChar;
                }
            }
        }
    }
}
