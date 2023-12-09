using System;
using System.Drawing;

namespace lab2
{
    [Serializable]
    class rect : figure//Наследование от абстрактного класса figure;
    {
        [NonSerialized] Pen pen;//Объявление объекта класса pen;
        public rect(int x, int y, Color f, Color lc, int size, Size s, bool br, Font font) : base(x, y, f, lc, size, s, br, font)//Передача переменных в конструктор наследуемого класса;
        {

        }

        public override void Draw(Graphics g, int x, int y)//Реализация наследуемого абстрактного метода;
        {

            pen = new Pen(lc, size);// Инициализация объекта класса Pen;
            rectangle = Rectangle.FromLTRB(p1.X + x, p1.Y + y, p2.X + x, p2.Y + y);// Объявление и инициализация объекта класса Rectangle;
            if (br)
            {
                SolidBrush brush = new SolidBrush(f);// Создание объекта класса SolidBrush, хранящего цвет заливки;
                g.FillRectangle(brush, rectangle);// Заливка фона прямоугольника;
            }
            g.DrawRectangle(pen, rectangle);// Вызов метода класса Graphics, отоброжающего прямоугольник на экране;
            if (red)
            {
                redRect(g);
            }
        }

        public override void DrawDash(Graphics g, bool k)//Реализация наследуемого абстрактного метода;
        {
            if (k)
            {
                rectangle = Rectangle.FromLTRB(p11.X, p11.Y, p21.X, p21.Y);// Объявление и инициализация объекта класса Rectangle;
            }
            else
            {
                rectangle = Rectangle.FromLTRB(p1.X, p1.Y, p2.X, p2.Y);// Объявление и инициализация объекта класса Rectangle;
            }
            pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
            g.DrawRectangle(pen, rectangle);// Вызов метода класса Graphics, отоброжающего прямоугольник на экране;

        }

        public override void Clear(Graphics g)//Реализация наследуемого абстрактного метода;
        {
            pen = new Pen(Color.White, size);// Инициализация объекта класса Pen;
            rectangle = Rectangle.FromLTRB(p1.X, p1.Y, p2.X, p2.Y);// Объявление и инициализация объекта класса Rectangle;
            if (br)
            {
                SolidBrush brush = new SolidBrush(Color.White);// Создание объекта класса SolidBrush, хранящего цвет заливки;
                g.FillRectangle(brush, rectangle);// Заливка фона прямоугольника;
            }
            g.DrawRectangle(pen, rectangle);// Вызов метода класса Graphics, отоброжающего прямоугольник на экране;
        }
    }
}
