using System;
using System.Drawing;

namespace lab2
{
    [Serializable]
    class text : figure//Наследование от абстрактного класса figure;
    {
        [NonSerialized] Pen pen;//Объявление объекта класса pen;
        public string str;
        public text(int x, int y, Color f, Color lc, int size, Size s, bool br, Font font) : base(x, y, f, lc, size, s, br, font)//Передача переменных в конструктор наследуемого класса;
        {

        }

        public override void Draw(Graphics g, int x, int y)//Реализация наследуемого абстрактного метода;
        {
            rectangle = Rectangle.FromLTRB(p1.X + x, p1.Y + y, p2.X + x, p2.Y + y);// Объявление и инициализация объекта класса Rectangle;
            g.DrawString(str, font, new SolidBrush(lc), rectangle);
            if (red)
            {
                redRect(g);
            }

        }

        public override void DrawDash(Graphics g, bool k)//Реализация наследуемого абстрактного метода;
        {
            rectangle = Rectangle.FromLTRB(p1.X, p1.Y, p2.X, p2.Y);// Объявление и инициализация объекта класса Rectangle;
            pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
            g.DrawRectangle(pen, rectangle);// Вызов метода класса Graphics, отоброжающего прямоугольник на экране;
        }

        public override void Clear(Graphics g)//Реализация наследуемого абстрактного метода;
        {
        }

    }
}

