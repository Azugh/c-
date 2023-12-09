using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace lab2
{

    public partial class Form2 : Form// Наследование класса об абстрактного класса Form;
    {
        internal List<figure> list = new List<figure>();// Объявление структуры динамического массива List;
        internal List<figure> choosed = new List<figure>();// Объявление структуры динамического массива List;
        figure figure;
        private bool mb = false;// Объявление переменной-датчика нажатия кнопки мыши;
        private bool ch = false;// Объявление переменной-датчика изменения в рисунке;
        private bool bit = false;
        public Color f = Color.White, lc = Color.Black;// Объекты класса Color, хранящие цвет фона и линии;
        public int size = 1;// Переменная хранящая размер линии;
        internal Size s;
        private int choosen = 1;// Хранит номер выбранной фигуры;
        private bool br = true;// Хранит состояние кнопки "Заливка";
        private BufferedGraphics bf;
        internal Font font = new Font("Times New Roman", 12);
        private TextBox textBox;
        bool dat = false;
        bool choosedmove = false;
        int shag = 10;
        bool setka = false;
        public bool withsetka = false;
        int choosedrect = -1;
        public string col;
        public bool pasteflag = false;
        Bitmap image;

        public Form2(Size s)//Конструктор класса;

        {
            this.s = s;// Получение размера рисунка;
            InitializeComponent();
            AutoScrollMinSize = s;// Задание минимального размера;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bf = new BufferedGraphicsContext().Allocate(this.CreateGraphics(), new Rectangle(new Point(0, 0), s));// Инициализация объекта хранящего буфер;

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)// Метод-обработчик события нажатия на кнопку мыши;
        {
            Form1 form = (Form1)this.ParentForm;// Объявление объекта класса Form1 и присвоение ему ссылки на родительскую форму;
            f = form.f;//Получение значения из родительской формы;
            lc = form.lc;//Получение значения из родительской формы;
            size = form.size;//Получение значения из родительской формы;
            if (choosen != 7)
                choosen = form.choosen;//Получение значения из родительской формы;
            br = form.br;//Получение значения из родительской формы;
            font = form.font;
            switch (choosen)//Выбор фигуры;
            {
                case 1:
                    figure = new rect(e.X, e.Y, f, lc, size, s, br, font);// Инициализация объекта класса rect;
                    break;
                case 2:
                    figure = new line(e.X, e.Y, f, lc, size, s, br, font);// Инициализация объекта класса line;
                    break;
                case 3:
                    figure = new curve(e.X, e.Y, f, lc, size, s, br, font);// Инициализация объекта класса curve;
                    break;
                case 4:
                    figure = new ellipse(e.X, e.Y, f, lc, size, s, br, font);// Инициализация объекта класса ellipse;
                    break;
                case 5:
                    figure = new text(e.X, e.Y, f, lc, size, s, br, font);// Инициализация объекта класса text;
                    break;
                case 6:
                    Graphics g = CreateGraphics();
                    dat = false;
                    mb = true;
                    figure = new rect(e.X, e.Y, f, lc, size, s, false, font);
                    foreach (figure f in list)
                    {

                        if (f.ChooseCheck(figure.rectangle))
                        {
                            foreach (figure fi in choosed)
                            {
                                if (f == fi)
                                {
                                    choosedmove = true;
                                }
                            }
                            choosed.Add(f);
                            dat = true;

                        }

                    }
                    if (!dat)
                    {
                        choosed.Clear();
                    }

                    Invalidate();


                    break;

                case 7:
                    figure fig = new rect(e.X, e.Y, f, lc, size, s, false, font);

                    choosedrect = figure.CheckRect(fig);

                    if (choosedrect == -1)
                    {
                        if (figure.ChooseCheck(fig.rectangle))
                        {
                            choosedmove = true;
                        }
                        else
                        {
                            figure.red = false;
                            choosen = 1;
                        }
                    }
                    break;
            }


            mb = true;// Изменение состояния переменной-датчика на true(нажата);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)// Метод-обработчик события движения курсора;
        {
            if (mb == true)// Проверка условия нажатия кнопки мыши;
            {
                if (choosen == 6)
                {
                    if (choosedmove)
                    {
                        Graphics g = CreateGraphics();// Создание объекта класса Graphics для рисования 2D объектов;
                        foreach (figure fi in choosed)
                        {

                            fi.ChoosedMove(g, e.X, e.Y);

                        }
                        My_Paint();
                    }
                    else
                    {
                        Graphics g = CreateGraphics();// Создание объекта класса Graphics для рисования 2D объектов;

                        figure.MouseMove(e.X, e.Y, g);
                        choosed.Clear();
                        foreach (figure fi in list)
                        {

                            if (fi.ChooseCheck(figure.rectangle))
                            {
                                choosed.Add(fi);
                                fi.DrawDashRect(g);
                            }
                            My_Paint();
                        }
                    }
                }

                else if (choosen == 7)
                {
                    if (figure.red)
                    {
                        Invalidate();
                        if (choosedmove)
                        {
                            figure.ChoosedMove(CreateGraphics(), e.X, e.Y);
                        }
                        figure.change(e.X, e.Y, choosedrect);

                        figure.DrawDash(bf.Graphics, true);
                      
                    }
                }
                else
                {
                    Graphics g = CreateGraphics();// Создание объекта класса Graphics для рисования 2D объектов;

                 
                    figure.MouseMove(e.X, e.Y, g);// Вызов метода класса rect, реализующий изменение координат по которым рисуется прямоугольник;
                }



            }

            ((Form1)this.ParentForm).setMousePositionCaption(e.X - AutoScrollPosition.X, e.Y - AutoScrollPosition.Y);


        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)// Метод-обработчик события отпускания кнопки мыши;
        {
            if ((e.X > s.Width) || (e.Y > s.Height))// Проверка условия не выхода за границы рисования;
            {

            }
            else
            {
                if (choosen == 5)
                {

                    textBox = new TextBox();//Инициализация объекта класса TextBox;
                    textBox.Location = figure.p1;//Задание левой верхней точки;
                    textBox.Size = new Size(figure.p2.X - figure.p1.X, figure.p2.Y - figure.p1.Y);//Задание размера;
                    textBox.Parent = this;//Установка в поле Parent ссылки на текущую форму;
                    textBox.Multiline = true;//Установка поля Multiline в true;
                    textBox.Font = font;// Задание шрифта;
                    textBox.ForeColor = lc;//Задание цвета шрифта;
                    textBox.Focus();//Установка фокуса на элемент управления TextBox;
                    textBox.Show();// Отображение элемента;
                    textBox.KeyDown += TextBox_KeyDown;// Обработчик события Key Down;

                }
                else if (choosen == 6)
                {

                    Graphics g = CreateGraphics();
                    foreach (figure f in choosed)
                    {
                        f.DrawDashRect(bf.Graphics);
                    }

                    choosedmove = false;
                    foreach (figure fi in choosed)
                    {
                        fi.ChoosedMove(bf.Graphics, 0, 0);

                    }

                }
                else if (choosen == 7)
                {
                    if (figure.red)
                    {
                        if (choosedmove)
                        {
                            choosedmove = false;
                        }

                        figure.setchange();

                    }

                }
                else
                {

                    Graphics g = CreateGraphics();// Создание объекта класса Graphics для рисования 2D объектов;
                    figure.scroll(AutoScrollPosition);// Вызов метода класса rect, реализующий пересчет координат в зависимости от скроллинга;
                    figure.Draw(bf.Graphics, AutoScrollPosition.X, AutoScrollPosition.Y);// Вызов метода класса rect, реализующий отображение прямоугольника на экране;

                    ch = true;// Изменение состояния переменной датчика на true;
                    list.Add(figure);// Добавление нового элемента в динамический массив;
                }
                if (withsetka)
                {
                    figure.virovniat(shag);
                }
            }
            mb = false;// Изменение состояния переменной-датчика на false(не нажата);
            Invalidate();// Перерисовка;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//Проверка нажатой кнопки;
            {

                ((text)figure).str = textBox.Text;// Присвоение полю str текста из textBox;
                figure.scroll(AutoScrollPosition);// Вызов метода класса rect, реализующий пересчет координат в зависимости от скроллинга;
                figure.Draw(this.CreateGraphics(), AutoScrollPosition.X, AutoScrollPosition.Y);//Вызов метода, отображающий рисунок на экране;
                textBox.Dispose();//Освобождение ресурсов, занятых textBox;
                ch = true;// Изменение состояния переменной датчика на true;
                list.Add(figure);// Добавление нового элемента в динамический массив;
                Invalidate();
                figure.tc = false;
            }
        }

        private void My_Paint()// Метод-обработчик события перерисовки;
        {
            Graphics g = CreateGraphics();// Создание объекта класса Graphics для рисования 2D объектов;
            bf.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point(0, 0), s));// Заливка допустимой для рисования области;
            foreach (figure f in list)// Цикл перебирающий все элементы массива;
            {
                f.Draw(bf.Graphics, AutoScrollPosition.X, AutoScrollPosition.Y);//Вызов метода рисования фигуры;
                if (f.red)
                {
                    figure.DrawDash(bf.Graphics, true);
                }
            }
            foreach (figure f in choosed)
            {
                f.DrawDashRect(bf.Graphics);
                f.DrawDash(bf.Graphics, true);
            }
            if (setka)
            {
                for (int i = shag; i < s.Width; i += shag)
                {
                    Pen pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
                    bf.Graphics.DrawLine(pen, i, 0, i, s.Height);
                }
                for (int i = shag; i < s.Height; i += shag)
                {
                    Pen pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
                    bf.Graphics.DrawLine(pen, 0, i, s.Width, i);
                }
            }
            bf.Render(g);//Передача объектов из буфера в Graphics;

        }

        private void Form2_Paint(object sender, PaintEventArgs e)// Метод-обработчик события перерисовки;
        {
            Graphics g = CreateGraphics();// Создание объекта класса Graphics для рисования 2D объектов;
            bf.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point(0, 0), s));// Заливка допустимой для рисования области;
            foreach (figure f in list)// Цикл перебирающий все элементы массива;
            {
                f.Draw(bf.Graphics, AutoScrollPosition.X, AutoScrollPosition.Y);//Вызов метода рисования фигуры;
                if (f.red)
                {
                    figure.DrawDash(bf.Graphics, true);
                }
            }
            foreach (figure f in choosed)
            {
                //f.DrawDashRect(bf.Graphics);
                f.DrawDash(bf.Graphics, true);
            }
            if (setka)
            {
                for (int i = shag; i < s.Width; i += shag)
                {
                    Pen pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
                    bf.Graphics.DrawLine(pen, i, 0, i, s.Height);
                }
                for (int i = shag; i < s.Height; i += shag)
                {
                    Pen pen = new Pen(Color.Black, size);// Инициализация объекта класса Pen;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;// Присвоение полю "DashStyle" значения, меняющего тип линии на пунктир;
                    bf.Graphics.DrawLine(pen, 0, i, s.Width, i);
                }
            }
            if (bit == true)
            {


                bit = false;
            }
            bf.Render(g);//Передача объектов из буфера в Graphics;

        }

        public void openfile()// Метод, реализующий открытие рисунка из файла;
        {
            OpenFileDialog open = new OpenFileDialog();// Создание объекта класса OpenFileDialog;
            open.InitialDirectory = Environment.CurrentDirectory;// Задание стартовой папки для диалога;
            open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            open.ShowDialog();// Отображение диалогового окна;
            if (open.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();// Создание объекта класса BinaryFormatter; 
                Stream stream = new FileStream(open.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);// Создание объекта класса Stream и настройка потока на открытие файла;              
                list = (List<figure>)formatter.Deserialize(stream);// Получение динамического массива из файла;
                this.Text = Path.GetFileName(open.FileName);// Присвоение окну имени файла;
                s = list.First().s;// Получение размера из файла;
                stream.Close();// Закрытие потока; 
            }
            else
            {
            }

        }
        public void savefile()// Метод, реализующий сохранение рисунка в файла;
        {
            SaveFileDialog save = new SaveFileDialog();// Создание объекта класса SaveFileDialog;
            save.InitialDirectory = Environment.CurrentDirectory;// Задание стартовой папки для диалога;
            save.FileName = this.Text;// Присвоение полю имя файла имени текущей формы;
            save.ShowDialog();// Отображение диалогового окна;
            BinaryFormatter formatter = new BinaryFormatter();// Создание объекта класса BinaryFormatter; 
            Stream stream = new FileStream(save.FileName, FileMode.Create, FileAccess.Write, FileShare.None);// Создание объекта класса Stream и настройка потока на запись в файл;
            formatter.Serialize(stream, list);// Запись динамического массива в файл;
            this.Text = Path.GetFileName(save.FileName);// Присвоение окну имени файла;
            stream.Close();// Закрытие потока;
            ch = false;// Установка датчика изменений в false;
        }

        public void save()// Метод, реализующий сохранение рисунка в файла;
        {
            BinaryFormatter formatter = new BinaryFormatter();// Создание объекта класса BinaryFormatter; 
            Stream stream = new FileStream(this.Text, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, list);// Создание объекта класса Stream и настройка потока на запись в файл;
            stream.Close();// Закрытие потока;
            ch = false;// Установка датчика изменений в false;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            Form1 f = (Form1)ParentForm;
            f.refresh();//Метод, отрисосывающий строку состояния;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)// Метод-обработчик события закрытия формы;
        {
            if (ch == true)// Проверка были ли изменения в рисунке;
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;// Параметр MessageBox;
                DialogResult result;//Объект класса Dialog result;
                result = MessageBox.Show("Сохранить изменения?", "Закрыть", buttons);// Присвоение результата работы диалога объекту созданному ранее;
                if (result == DialogResult.Yes)// Проверка нажатия на кнопку "Да";
                {
                    save();// Вызов метода, отвечающего за сохранение;
                    Form1 f = (Form1)this.ParentForm;// Создание объекта класса Form1 и присвоение ему ссылки на родительскую форму;
                    f.saveactive();// Вызов метода saveactive класса Form1;
                }
                else if (result == DialogResult.No)// Проверка нажатия на кнопку "Нет";
                {
                    Form1 f = (Form1)this.ParentForm;// Создание объекта класса Form1 и присвоение ему ссылки на родительскую форму;
                    f.saveactive();// Вызов метода saveactive класса Form1;
                }
                else// Проверка нажатия на кнопку "Отмена";
                {
                    e.Cancel = true;//Отмена закрытия окна с рисунком;
                }
            }
        }

        public void Delete()
        {
            Predicate<figure> predicate = Checked;
            list.RemoveAll(predicate);
            choosed.Clear();
            bf.Render(CreateGraphics());
            Invalidate();
        }

        private bool Checked(figure f)
        {
            bool r = false;
            foreach (figure fi in choosed)
            {
                if (f == fi)
                {
                    r = true;
                }
            }
            return r;
        }
        public void Copy()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();// Создание объекта класса BinaryFormatter; 

            formatter.Serialize(ms, choosed);// Создание объекта класса Stream и настройка потока на запись в файл;
            Clipboard.SetDataObject(ms, true);
            pasteflag = true;



        }
        public void Paste()
        {

            IDataObject data = Clipboard.GetDataObject();
            MemoryStream ms = (MemoryStream)data.GetData(typeof(MemoryStream));
            BinaryFormatter formatter = new BinaryFormatter();// Создание объекта класса BinaryFormatter; 
            choosed.Clear();
            choosed.AddRange((List<figure>)formatter.Deserialize(ms));// Получение динамического массива из файла; 
            int x = 0, y = 0;

            foreach (figure f in choosed)
            {
                if (f.p1.X < x)
                {
                    x = f.p1.X;

                }
                if (f.p1.Y < y)
                {
                    y = f.p1.Y;
                }
            }

            for (int i = 0; i < choosed.Count; i++)
            {
                choosed[i].p1.X -= x;
                choosed[i].p1.Y -= y;
                choosed[i].p2.X -= x;
                choosed[i].p2.Y -= y;
                choosed[i].p11.X -= x;
                choosed[i].p11.Y -= y;
                choosed[i].p21.X -= x;
                choosed[i].p21.Y -= y;
            }

            int x1 = 11111, x2 = 0, y1 = 111111, y2 = 0;

            foreach (figure f in choosed)
            {
                if (f.p1.X < x1)
                    x1 = f.p1.X;
                if (f.p1.Y < y1)
                    y1 = f.p1.Y;
                if (f.p2.X > x2)
                    x2 = f.p2.X;
                if (f.p2.Y > y2)
                    y2 = f.p2.Y;
            }

            if ((s.Width > x2 - x1) && (s.Height > y2 - y1))
            {

                list.AddRange(choosed);
            }

            else
            {
                MessageBox.Show("Не соответствует размеру окна");
                choosed.Clear();
            }
            ms.Close();// Закрытие потока; 
            Invalidate();
        }

        public void CopyAsMeta()
        {

            Graphics gr = CreateGraphics();

            IntPtr dc = gr.GetHdc();

            Metafile mf = new Metafile(dc, EmfType.EmfOnly);

            gr.ReleaseHdc(dc);
            gr.Dispose();

            gr = Graphics.FromImage(mf);

            foreach (figure f in choosed)
            {
                f.Draw(gr, AutoScrollPosition.X, AutoScrollPosition.Y);
            }

            gr.Dispose();

            ClipboardMetafileHelper.PutEnhMetafileOnClipboard(this.Handle, mf);
        }

        public void SelectAll()
        {
            choosed.AddRange(list);
            foreach (figure f in choosed)
            {
                f.DrawDashRect(CreateGraphics());

            }
        }

        public void Cut()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();// Создание объекта класса BinaryFormatter; 
            formatter.Serialize(ms, choosed);// Создание объекта класса Stream и настройка потока на запись в файл;
            Clipboard.SetDataObject(ms);
            Delete();
            Invalidate();
        }
        public void printSetka(int shag, bool setka)
        {
            this.shag = shag;
            this.setka = setka;
            Invalidate();

        }

        private void Form2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            choosed.Clear();
            figure = new rect(e.X, e.Y, f, lc, size, s, false, font);
            figure fig = null;
            foreach (figure f in list)
            {

                if (f.ChooseCheck(figure.rectangle))
                {
                    fig = f;

                }

            }
            if (fig != null)
            {
                choosen = 7;
                fig.red = true;
                figure = fig;
                Invalidate();

            }
        }

        public void virovniat()
        {

            foreach (figure f in list)
            {
                f.virovniat(shag);
            }
            Invalidate();
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((figure is text) && (figure.red) && (!figure.tc))
            {
                figure.tc = true;
                textBox = new TextBox();//Инициализация объекта класса TextBox;
                textBox.Location = figure.p1;//Задание левой верхней точки;
                textBox.Size = new Size(figure.p2.X - figure.p1.X, figure.p2.Y - figure.p1.Y);//Задание размера;
                textBox.Parent = this;//Установка в поле Parent ссылки на текущую форму;
                textBox.Multiline = true;//Установка поля Multiline в true;
                textBox.Font = font;// Задание шрифта;
                textBox.ForeColor = lc;//Задание цвета шрифта;
                textBox.Focus();//Установка фокуса на элемент управления TextBox;
                textBox.Show();// Отображение элемента;
                textBox.KeyDown += TextBox_KeyDown;// Обработчик события Key Down;
            }
        }

        public void openImage()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                int x = 0, y = 0;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(openFileDialog1.FileName))
                    {
                        figure = new FigureWithBitmap(x, y, f, lc, size, s, br, font);
                        ((FigureWithBitmap)figure).bitmap = bmp;
                    }
                    Graphics g = CreateGraphics();
                    figure.scroll(AutoScrollPosition);
                    list.Add(figure);
                    MessageBox.Show("Th.");
                }

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
            }
            Invalidate();
        }

        public void saveImage()
        {

            Bitmap bmp = new Bitmap(image);
            bmp.Save("image.png", System.Drawing.Imaging.ImageFormat.Png);

        }

        public void changeParametr()
        {
            Form1 form = (Form1)this.ParentForm;// Объявление объекта класса Form1 и присвоение ему ссылки на родительскую форму;
            figure.f = form.f;//Получение значения из родительской формы;
            figure.lc = form.lc;//Получение значения из родительской формы;
            figure.br = form.br;//Получение значения из родительской формы;
            figure.size = form.size;
            figure.font = form.font;
            Invalidate();
        }

    }
}
