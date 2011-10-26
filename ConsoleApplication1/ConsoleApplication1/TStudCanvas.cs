using System;
using System.IO;

namespace ConsoleApplication1
{
    class StudCanvas
    {
        public char[,] Field { get; set; }

        /// <summary>
        /// Создает канву заданного размера
        /// </summary>
        /// <param name="width">Ширина канвы</param>
        /// <param name="height">Высота канвы</param>
        /// <param name="backChar">Фоновый символ</param>
        public StudCanvas(ushort width = 100, ushort height = 100, char backChar = '.')
        {
            Field = new char[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Field[j, i] = backChar;
                }
            }
        }

        /// <summary>
        /// Рисует канву в заданный файл
        /// </summary>
        /// <param name="filename">Имя файла, куда нужно вывести канву</param>
        public void Draw(string filename)
        {
            var sw = new StreamWriter(filename);
            for (int i = 0; i < Field.GetLength(1); i++)
            {
                for (int j = 0; j < Field.GetLength(0); j++)
                {
                    sw.Write(Field[j, i]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }


        /// <summary>
        /// Заменяет один символ на другой на всей канве
        /// </summary>
        /// <param name="oldSym">Старый символ</param>
        /// <param name="newSym">Новый символ</param>
        public void Mask(char oldSym, char newSym)
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == oldSym) Field[i, j] = newSym;
                }
            }
        }

        /// <summary>
        /// Вставляет одну канву в другую
        /// </summary>
        /// <param name="newCanvas">Ссылка на вставляемую канву</param>
        /// <param name="x1">Место вставки (левый верхний угол)</param>
        /// <param name="y1">Место вставки (левый верхний угол)</param>
        public void Paste(StudCanvas newCanvas, ushort x1, ushort y1)
        {
            ushort x2 = Convert.ToUInt16(newCanvas.Field.GetLength(0) - 1 + x1);
            ushort y2 = Convert.ToUInt16(newCanvas.Field.GetLength(1) - 1 + y1);

            if (x1 >= Field.GetLength(0) || y1 >= Field.GetLength(1)) return;

            DevTools.CheckRightX(ref x2, this);
            DevTools.CheckLowY(ref y2, this);

            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    Field[i, j] = newCanvas.Field[i - x1, j - y1];
                }
            }
        }

        /// <summary>
        /// Возвращает ширину поля
        /// </summary>
        /// <returns></returns>
        public int GetWidth()
        {
            return Field.GetLength(0);
        }

        /// <summary>
        /// Возвращает высоту поля
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            return Field.GetLength(1);
        }

    }
}
