using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    class line : figure//Наследование от абстрактного класса figure;
    {
        [NonSerialized] Pen pen;//Объявление объекта класса pen;
        public line(int x, int y, Color f, Color lc, int size, Size s, bool br, Font font) : base(x, y, f, lc, size, s, br, font)//Передача переменных в конструктор наследуемого класса;
        {

        }

        public override void Draw(Graphics g, int x, int y)//Реализация наследуемого абстрактного метода;
        {
            pen = new Pen(lc, size);// Инициализация объекта класса Pen;
            g.DrawLine(pen, p1.X + x, p1.Y + y, p2.X + x, p2.Y + y);
            //g.DrawLine(pen, p1, p2);// Вызов метода класса Graphics, отоброжающего линию на экране;
        }

        public override void DrawDash(Graphics g, bool k)//Реализация наследуемого абстрактного метода;
        {
            
            pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
            if (k)
            {
                g.DrawLine(pen, p11, p21);// Вызов метода класса Graphics, отоброжающего линию на экране;
            }
            else
                g.DrawLine(pen, p1, p2);// Вызов метода класса Graphics, отоброжающего линию на экране;
        }

        public override void Clear(Graphics g)//Реализация наследуемого абстрактного метода;
        {
            pen = new Pen(Color.White, size);// Инициализация объекта класса Pen;
            g.DrawLine(pen, p1, p2);// Вызов метода класса Graphics, отоброжающего линию на экране;
        }
        public override void MouseMove(int x, int y, Graphics g)
        {
            Clear(g);
            p2.X = x;
            p2.Y = y;
            DrawDash(g, false);
        }
        
    }
}
