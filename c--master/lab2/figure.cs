using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable] abstract class figure// abstract означает, что нельзя инициализировать объект этого класса;
    {
        public Point p1, p2, pabs, p11, p21;//Объявление вспомонательных переменных для рисования;
        public Color f = Color.White, lc = Color.Black;// Объекты класса Color, хранящие цвет фона и линии;
        public int size = 1;// Переменная хранящая размер линии;
        public Size s;
        public bool br;
        public Font font;
        public Rectangle rectangle;
        public Point p3 = new Point(0, 0);
        public bool red = false;
        public bool tc = false;
        Rectangle[] rectangles = new Rectangle[8];
        
        public figure(int x, int y, Color f, Color lc, int size, Size s, bool br, Font font)// Конструктор класса;
        {
            p1 = new Point(x, y);//Инициализация переменной;
            p11 = new Point(x, y);//Инициализация переменной;
            p21 = new Point(x, y);//Инициализация переменной;
            p2 = new Point(x, y);//Инициализация переменной;
            pabs = new Point(x, y);//Инициализация переменной;
            this.f = f;// Инициализация пременной;
            this.lc = lc;// Инициализация пременной;
            this.size = size;// Инициализация пременной;
            this.s = s;// Инициализация переменной;
            this.br = br; // Инициализация переменной;
            this.font = font;
            rectangle = new Rectangle(p1, new Size(0, 0));
        }

        public abstract void Draw(Graphics g, int x, int y);//Объявление абстрактного метода, который будет реализован в наследующих классах;
        public abstract void DrawDash(Graphics g, bool k);//Объявление абстрактного метода, который будет реализован в наследующих классах;
        public abstract void Clear(Graphics g);//Объявление абстрактного метода, который будет реализован в наследующих классах;
        public virtual void MouseMove(int x, int y, Graphics g)// Метод, реализующий изменение координат по которым рисуется фигура;
        {
            Clear(g);//Вызов метода очистки предыдущего изображения;
            if (x > pabs.X)
            {
                p2.X = x;
                p21.X = x;
            }
            else
            {
                p1.X = x;
                p11.X = x;
            }
            if (y > pabs.Y)
            {
                p2.Y = y;
                p21.Y = y;
            }
            else
            {
                p1.Y = y;
                p11.Y = y;
            }// Нормализация координат;
            DrawDash(g, false);//Вызов метода рисования пунктиром;
        }
        public virtual void scroll(Point pos)
        {
            p1.X -= pos.X;// Отображение относительно смещения экрана при скроллинге;
            p1.Y -= pos.Y;// Отображение относительно смещения экрана при скроллинге;
            p2.X -= pos.X;// Отображение относительно смещения экрана при скроллинге;
            p2.Y -= pos.Y;// Отображение относительно смещения экрана при скроллинге;
            p11.X -= pos.X;// Отображение относительно смещения экрана при скроллинге;
            p11.Y -= pos.Y;// Отображение относительно смещения экрана при скроллинге;
            p21.X -= pos.X;// Отображение относительно смещения экрана при скроллинге;
            p21.Y -= pos.Y;// Отображение относительно смещения экрана при скроллинге;
        }
        public void DrawDashRect(Graphics g)
        {
           
            Pen pen = new Pen(Color.Black, 1);// Инициализация объекта класса Pen;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
            g.DrawRectangle(pen, rectangle);// Вызов метода класса Graphics, отоброжающего прямоугольник на экране;
        }

        public bool ChooseCheck(Rectangle rect)
        {
            return (rectangle.IntersectsWith(rect));
        }
        public virtual void ChoosedMove(Graphics g, int x, int y)
        {
            if (p3.X == 0)
            {
                p3.X = x;
                p3.Y = y;
            }
            else if (x == 0)
            {
                p3.X = 0;
                p3.Y = 0;
            }
            else
            {
                p11.X += x - p3.X;
                p11.Y += y - p3.Y;
                p21.X += x - p3.X;
                p21.Y += y - p3.Y;
                p3.X = x;
                p3.Y = y;
            }
            if (x != 0)
                DrawDash(g, true);
            else if (rectangle.IntersectsWith(new Rectangle(new Point(0, 0), s)))
            {
                p1.X = p11.X;
                p1.Y = p11.Y;
                p2.X = p21.X;
                p2.Y = p21.Y;
            }
            

        }
        public virtual void virovniat(int d)
        {
            int razn = p1.X % d;
            if (razn > d/2)
            {
                p1.X += d - razn;
                p2.X += d - razn;
               
            }
            else
            {
                p1.X -= razn;
                p2.X -= razn;
            }
            razn = p1.Y % d;
            if (razn > d / 2)
            {
                p1.Y += d - razn;
                p2.Y += d - razn;

            }
            else
            {
                p1.Y -= razn;
                p2.Y -= razn;
            }
            razn = p2.X % d;
            if (razn > d / 2)
            {
                
                p2.X += d - razn;

            }
            else
            {
                p2.X -= razn;
            }
            razn = p2.Y % d;
            if (razn > d / 2)
            {
                p2.Y += d - razn;

            }
            else
            {
                p2.Y -= razn;
            }

            p11.X = p1.X;
            p11.Y = p1.Y;
            p21.X = p2.X;
            p21.Y = p2.Y;
        }
        public virtual void  change(int x, int y, int choosedrect)
        {
            switch (choosedrect)
            {
                case 0:
                    p11.X = x;
                    p11.Y = y;
                    break;
                case 1:
                    p11.Y = y;
                    break;
                case 2:
                    p21.X = x;
                    p11.Y = y;
                    break;
                case 3:
                    p21.X = x;
                    break;
                case 4:
                    p21.X = x;
                    p21.Y = y;
                    break;
                case 5:
                    p21.Y = y;
                    break;
                case 6:
                    p11.X = x;
                    p21.Y = y;
                    break;
                case 7:
                    p11.X = x;
                    break;
                    
            }
        }
        public void setchange()
        {
            p1.X = p11.X;
            p1.Y = p11.Y;
            p2.X = p21.X;
            p2.Y = p21.Y;
        }
        public void redRect(Graphics g)
        {
            rectangles[0] = new Rectangle(p11.X - 3, p11.Y - 3, 6, 6);
            rectangles[1] = new Rectangle(p11.X - 3 + (p21.X - p11.X) /  2, p11.Y - 3, 6, 6);
            rectangles[2] = new Rectangle(p21.X - 3, p11.Y - 3, 6, 6);
            rectangles[3] = new Rectangle(p21.X - 3, p11.Y - 3 + (p21.Y - p11.Y) / 2, 6, 6);
            rectangles[4] = new Rectangle(p21.X - 3, p21.Y - 3, 6, 6);
            rectangles[5] = new Rectangle(p11.X - 3 + (p21.X - p11.X) / 2, p21.Y - 3, 6, 6);
            rectangles[6] = new Rectangle(p11.X - 3, p21.Y - 3, 6, 6);
            rectangles[7] = new Rectangle(p11.X - 3, p11.Y - 3 + (p21.Y - p11.Y) / 2, 6, 6);
            for (int i = 0; i < 8; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Black), rectangles[i]);
            }
        }
        public int CheckRect(figure f)
        {
            int num = -1;
            for (int i = 0; i < 8; i++)
            {
                if (rectangles[i].IntersectsWith(f.rectangle))
                  num = i;
            }
            return num;
        }
    }
}
