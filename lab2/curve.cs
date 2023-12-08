using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    class curve : figure//Наследование от абстрактного класса figure;
    {

        [NonSerialized] Pen pen;//Объявление объекта класса pen;
        internal List<PointF> list = new List<PointF>();
        internal PointF[] points;
        internal PointF[] points1;
        public curve(int x, int y, Color f, Color lc, int size, Size s, bool br, Font font) : base(x, y, f, lc, size, s, br, font)//Передача переменных в конструктор наследуемого класса;
        {
            list.Add(new Point(x, y));
            list.Add(new Point(x, y));
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Height = 0;
            rectangle.Width = 0;
        }

        public override void Draw(Graphics g, int x, int y)//Реализация наследуемого абстрактного метода;
        {

            pen = new Pen(lc, size);// Инициализация объекта класса Pen;
            points = new PointF[list.Count];// Инициализация массива точек;
            points1 = new PointF[list.Count];// Инициализация массива точек;
            for (int i = 0; i < list.Count; i++)// Цикл для передачи всех точек из динамического массива в статичный;
            {
                points[i] = list[i];// Передача;
                points1[i] = list[i];// Передача;
                points[i].X = points[i].X + x;
                points[i].Y = points[i].Y + y;
            }
            float xmin = 11110, xmax = 0, ymin = 11111, ymax = 0;
            foreach (PointF p in points)
            {
                if (p.X > xmax)
                    xmax = p.X;
                else if (p.X < xmin)
                    xmin = p.X;
                if (p.Y > ymax)
                    ymax = p.Y;
                else if (p.Y < ymin)
                    ymin = p.Y;
            }
            rectangle = Rectangle.FromLTRB((int)Math.Round(xmin), (int)Math.Round(ymin), (int)Math.Round(xmax), (int)Math.Round(ymax));
            p11.X = rectangle.X;
            p11.Y = rectangle.Y;
            p21.X = rectangle.Right;
            p21.Y = rectangle.Bottom;
            g.DrawCurve(pen, points);// Вызов метода класса Graphics, отоброжающего линию на экране;
            if (red)
                redRect(g);
        }

        public override void DrawDash(Graphics g, bool k)//Реализация наследуемого абстрактного метода;
        {

            pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;

            if (k)
                g.DrawCurve(pen, points1);// Вызов метода класса Graphics, отоброжающего линию на экране;
            else
            {
                points = new PointF[list.Count];// Инициализация массива точек;
                points1 = new PointF[list.Count];// Инициализация массива точек;
                for (int i = 0; i < list.Count; i++)// Цикл для передачи всех точек из динамического массива в статичный;
                {
                    points[i] = list[i];// Передача;

                }
                g.DrawCurve(pen, points);// Вызов метода класса Graphics, отоброжающего линию на экране;
            }
        }

        public override void Clear(Graphics g)//Реализация наследуемого абстрактного метода;
        {
            pen = new Pen(Color.White, size);// Инициализация объекта класса Pen;
            points = new PointF[list.Count];// Инициализация массива точек;
            points1 = new PointF[list.Count];// Инициализация массива точек;
            for(int i = 0; i < list.Count; i++)// Цикл для передачи всех точек из динамического массива в статичный;
            {
                points[i] = list[i];// Передача;
                points1[i] = list[i];// Передача;
            }
            g.DrawCurve(pen, points);// Вызов метода класса Graphics, отоброжающего линию на экране;
        }
        public override void MouseMove(int x, int y, Graphics g)
        {
            
            list.Add(new Point(x, y));// Добавление новой точки;

            DrawDash(g, false);// Вызов метода DrawDash;
        }
        public override void scroll(Point pos)
        {
            points = new PointF[list.Count];// Инициализация массива точек;
            points1 = new PointF[list.Count];// Инициализация массива точек;
            for (int i = 0; i < list.Count; i++)// Цикл для передачи всех точек из динамического массива в статичный;
            {
                points[i] = list[i];// Передача;
                points1[i] = list[i];// Передача;
            }
            for (int i = 0; i < points.Length; i++)// Проход по всем точкам;
            {
                points[i].X -= pos.X;// Отображение относительно смещения экрана при скроллинге;
                points[i].Y -= pos.Y;// Отображение относительно смещения экрана при скроллинге;
                points1[i].X -= pos.X;// Отображение относительно смещения экрана при скроллинге;
                points1[i].Y -= pos.Y;// Отображение относительно смещения экрана при скроллинге;
            }
        }
        public override void ChoosedMove(Graphics g, int x, int y)
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
                for (int i = 0; i < points1.Length; i++)// Цикл для передачи всех точек из динамического массива в статичный;
                { 
                    points1[i].X += x - p3.X;
                    points1[i].Y += y - p3.Y;
                }
                rectangle.X += x - p3.X;
                
                rectangle.Y += y - p3.Y;
                
                p3.X = x;
                p3.Y = y;
                DrawDash(g, true);
                if (x != 0)
                   
                
                if (rectangle.IntersectsWith(new Rectangle(new Point(0, 0), s)))
                {
                        list.Clear();
                        list.AddRange(points1);
                }
            }
        }
        public override void change(int x, int y, int choosedrect)
        {
            p11.X = rectangle.X;
            p11.Y = rectangle.Y;
            p21.X = rectangle.Right;
            p21.Y = rectangle.Bottom;
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
            if (rectangle.X < p11.X)
            {
                double kf = (double)(rectangle.Right - p11.X) / rectangle.Width;
                for (int i = 0; i < points1.Length; i++)// Цикл для передачи всех точек из динамического массива в статичный;
                {
                    points1[i].X += (float)((rectangle.Right - points1[i].X) * (1.0 - kf));
                   
                }
                list.Clear();
                list.AddRange(points1);

            }
            if (rectangle.Y < p11.Y)
            {
                double kf = (double)(rectangle.Bottom - p11.Y) / rectangle.Height;
                for (int i = 0; i < points1.Length; i++)// Цикл для передачи всех точек из динамического массива в статичный;
                {
                    points1[i].Y += (float)((rectangle.Bottom - points1[i].Y) * (1.0 - kf));

                }
                list.Clear();
                list.AddRange(points1);
            }
            if (rectangle.X > p11.X)
            {
                double kf = (double)(rectangle.Right - p11.X) / rectangle.Width;
                for (int i = 0; i < points1.Length; i++)// Цикл для передачи всех точек из динамического массива в статичный;
                {
                    points1[i].X += (float)((rectangle.Right - points1[i].X) * (1.0 - kf));

                }
                list.Clear();
                list.AddRange(points1);
            }
            if (rectangle.Y > p11.Y)
            {
                double kf = (double)(rectangle.Bottom - p11.Y) / rectangle.Height;
                for (int i = 0; i < points1.Length; i++)// Цикл для передачи всех точек из динамического массива в статичный;
                {
                    points1[i].Y += (float)((rectangle.Bottom - points1[i].Y) * (1.0 - kf));

                }
                list.Clear();
                list.AddRange(points1);
            }
        }

    }
}
