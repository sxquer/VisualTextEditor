namespace ConsoleApplication1
{
    abstract class AStudTools
    {
        private char _backChar = '#';

        
        /// <summary>
        /// Символ, которым рисуется фигура
        /// </summary>
        public char BackChar
        {
            get { return _backChar; }
            set { _backChar = value; }
        }

        private bool _isSolid = true;
        /// <summary>
        /// Закрашивается ли фигура, или рисуется только контур. Для линий при значении true игнорируется точность.
        /// </summary>
        public bool IsSolid
        {
            get { return _isSolid; }
            set { _isSolid = value; }
        }

        /// <summary>
        /// Реализация должна отрисовать фигуры в заданном прямоугольнике, на заданной канве
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        abstract public void Draw(StudCanvas canvas, ushort x1, ushort y1, ushort x2, ushort y2);
        
    }
}
