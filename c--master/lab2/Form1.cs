using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form // Наследование класса об абстрактного класса Form;
    {
        public Color f = Color.White, lc = Color.Black;// Объекты класса Color, хранящие цвет фона и линии;
        public int size = 1;// Переменная хранящая размер линии;
        public Size s = new Size(800, 600);// Хранит размер рисунка;
        public int choosen = 1;// Хранит номер выбранной фигуры;
        public bool br = true;// Хранит состояние кнопки "Заливка";
        public Font font = new Font("Times New Roman", 12);// Хранит тип шрифта;
        public int ssetka = 10;
        public bool actsetka = false;

        public Form1()// Конструктор класса;
        {

            InitializeComponent();
        }

        private void новоеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form f = new Form2(s);// Создание объекта класса Form2;

            f.MdiParent = this;// Присвоение полю "Родительская форма" созданного объекта ссылки на эту форму;

            f.Text = "Рисунок " + this.MdiChildren.Length.ToString();// Присвоения названия окну ;

            f.Show();// Отоброжение окна на экране;
            this.сохранитьToolStripMenuItem.Enabled = true;// Установка кнопки меню "Сохранить" в активное состояние;
            this.сохранитьКакToolStripMenuItem.Enabled = true;// Установка кнопки меню "Сохранить как" в активное состояние;
            this.toolStripButton3.Enabled = true;// Установка кнопки "Сохранить" в активное состояние;

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(s);//Создание объекта класса Form2;
            f.MdiParent = this;// Присвоение полю "Родительская форма" созданного объекта ссылки на эту форму;
            f.openfile();//Вызов метода openfile класса Form2;
            f.Show();//Оборажение окна на экране;
            this.сохранитьToolStripMenuItem.Enabled = true;// Установка кнопки меню "Сохранить" в активное состояние;
            this.сохранитьКакToolStripMenuItem.Enabled = true;// Установка кнопки меню "Сохранить как" в активное состояние;
            this.toolStripButton3.Enabled = true;// Установка кнопки "Сохранить" в активное состояние;

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;//Объявление объекта класса Form2 и присвоение ему ссылки на активное дочернее окно;
            f.save();//Вызов метода save класса Form2;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;//Объявление объекта класса Form2 и присвоение ему ссылки на активное дочернее окно;
            f.savefile();//Вызов метода savefile класса Form2;
        }

        public void saveactive()
        {
            if (this.MdiChildren.Length == 1)//Проверка кол-ва открытых дочерних окон;
            {
                this.сохранитьToolStripMenuItem.Enabled = false;// Установка кнопки меню "Сохранить" в неактивное состояние;
                this.сохранитьКакToolStripMenuItem.Enabled = false;// Установка кнопки меню "Сохранить как" в неактивное состояние;
                this.toolStripButton3.Enabled = false;// Установка кнопки "Сохранить" в неактивное состояние;
            }
        }

        private void цветЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();//Создание объекта класса ColorDialog;
            color.ShowDialog();//Отображение диалогового окна;
            lc = color.Color;//Присвоение переменной выбранного цвета;
            refresh();//Метод, отрисосывающий строку состояния;
            if (MdiChildren.Length > 0)
            {
                Form2 f = (Form2)ActiveMdiChild;
                f.changeParametr();
            }
        }

        private void толщинаЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();// Создание объекта класса Form3;
            f.size = size;// Присвоение полю size класса Form3 текущего значения толщины линии;

            f.ShowDialog();// Отображение диалогового окна;
            size = f.size;// Получение значения из диалога;
            refresh();//Метод, отрисосывающий строку состояния;
            if (MdiChildren.Length > 0)
            {
                Form2 form2 = (Form2)ActiveMdiChild;
                form2.changeParametr();
            }
        }

        private void размерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();// Создание объекта класса Form3;
            f.ShowDialog();// Отображение диалогового окна;
            s = f.s;// Получение значения из диалога;
            refresh();//Метод, отрисосывающий строку состояния;

        }

        private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosen = 1;// Установка номера выбранной фигуры;
            заливкаToolStripMenuItem.Enabled = true;// Установка кнопки заливка в активное состояние;
            прямоугольникToolStripMenuItem.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            прямаяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            криваяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            эллипсToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            текстToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;

            toolStripButton12.Enabled = true;// Установка кнопки заливка в активное состояние;
            toolStripButton8.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton14.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
        }

        private void прямаяЛинияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosen = 2;// Установка номера выбранной фигуры;
            заливкаToolStripMenuItem.Enabled = false;// Установка кнопки заливка в неактивное состояние;
            прямоугольникToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            прямаяЛинияToolStripMenuItem.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            криваяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            эллипсToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            текстToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;

            toolStripButton12.Enabled = false;// Установка кнопки заливка в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton14.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
        }

        private void криваяЛинияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosen = 3;// Установка номера выбранной фигуры;
            заливкаToolStripMenuItem.Enabled = false;// Установка кнопки заливка в неактивное состояние;
            прямоугольникToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            прямаяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            криваяЛинияToolStripMenuItem.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            эллипсToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton12.Enabled = false;// Установка кнопки заливка в неактивное состояние;
            текстToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;

            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            toolStripButton14.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
        }

        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosen = 4;// Установка номера выбранной фигуры;
            заливкаToolStripMenuItem.Enabled = true;// Установка кнопки заливка в активное состояние;
            прямоугольникToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            прямаяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            криваяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            эллипсToolStripMenuItem.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            текстToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton12.Enabled = true;// Установка кнопки заливка в активное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton14.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
        }

        private void заливкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (br)
            {
                br = false;//Смена состояния;
                toolStripButton12.Checked = false;//Смена состояния;
            }
            else
            {
                br = true;//Смена состояния;
                toolStripButton12.Checked = true;//Смена состояния;

            }
            if (MdiChildren.Length > 0)
            {
                Form2 f = (Form2)ActiveMdiChild;
                f.changeParametr();
            }
        }

        private void statusBar1_DrawItem(object sender, StatusBarDrawItemEventArgs sbdevent)
        {

            statusBarPanel1.Text = $"Размер пера: {size}";//Изменение показателя размера пера;

            sbdevent.Graphics.DrawString("Цвет пера: ", new Font("Times New Roman", 10), new SolidBrush(Color.Black), new Point(100, 3));//текст;
            sbdevent.Graphics.FillRectangle(new SolidBrush(lc), new Rectangle(new Point(170, 3), new Size(15, 15)));//Изменение показателя цвета линии;
            sbdevent.Graphics.DrawString("Цвет заливки: ", new Font("Times New Roman", 10), new SolidBrush(Color.Black), new Point(200, 3));//Текст;
            sbdevent.Graphics.FillRectangle(new SolidBrush(f), new Rectangle(new Point(290, 3), new Size(15, 15)));//Изменение показателя цвета заливки;
            statusBarPanel4.Text = $"Указатель: {Cursor.Position.X}:{Cursor.Position.Y}";//Изменение показателя положения указателя;
            statusBarPanel5.Text = $"Рисунок: {s.Width}x{s.Height}";//Изменение показателя размера рисунка;
            statusBarPanel6.Text = $"Шрифт: {font.Name}";//Изменение показателя типа шрифта;
            statusBarPanel7.Text = $"Размер шрифта: {font.Size}";//Изменение показателя размера шрифта;

        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();//Создание объекта класса ColorDialog;
            color.ShowDialog();//Отображение диалогового окна;
            f = color.Color;//Присвоение переменной выбранного цвета;
            refresh();
            if (MdiChildren.Length > 0)
            {
                Form2 f = (Form2)ActiveMdiChild;
                f.changeParametr();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            новоеToolStripMenuItem_Click_1(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            открытьToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            цветЛинииToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            толщинаЛинииToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            цветФонаToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            размерToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            прямоугольникToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            эллипсToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            прямаяЛинияToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            криваяЛинияToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            заливкаToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();//Создание объекта класса FontDialog;
            dialog.ShowDialog();// Отображение диалогового окна;
            font = dialog.Font;//Получение шрифта из диалога;
            if (MdiChildren.Length > 0)
            {
                Form2 form2 = (Form2)ActiveMdiChild;
                form2.changeParametr();
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            шрифтToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;
        }

        private void текстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosen = 5;// Установка номера выбранной фигуры;
            заливкаToolStripMenuItem.Enabled = false;// Установка кнопки заливка в неактивное состояние;
            прямоугольникToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в активное состояние;
            прямаяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            криваяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            эллипсToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            текстToolStripMenuItem.Checked = true;// Установка датчика выбранной фигуры в активное состояние;
            toolStripButton12.Enabled = false;// Установка кнопки заливка в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton14.Checked = true;// Установка датчика выбранной фигуры в активное состояние;


        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            текстToolStripMenuItem_Click(sender, e);//Вызов события нажатия на соответствующую кнопку меню;

        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            choosen = 6;// Установка номера выбранной фигуры;
            заливкаToolStripMenuItem.Enabled = false;// Установка кнопки заливка в активное состояние;
            прямоугольникToolStripMenuItem.Checked = false;// Установка датчика выбранной фигуры в активное состояние;
            прямаяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            криваяЛинияToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            эллипсToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            текстToolStripMenuItem.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;

            toolStripButton12.Enabled = false;// Установка кнопки заливка в активное состояние;
            toolStripButton8.Checked = false;// Установка датчика выбранной фигуры в активное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton8.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
            toolStripButton14.Checked = false;// Установка датчика не выбранной фигуры в неактивное состояние;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

            удалитьToolStripMenuItem_Click(sender, e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 f = (Form2)this.ActiveMdiChild;
                f.Delete();
            }
            catch (NullReferenceException) { return; }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;
            f.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;
            f.Paste();
        }

        private void копироватьКакМетафайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;
            f.CopyAsMeta();

        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;
            f.SelectAll();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;
            f.Cut();
        }

        private void правкаToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;

            if (this.MdiChildren.Length >= 1)//Проверка кол-ва открытых дочерних окон;
            {
                копироватьToolStripMenuItem.Enabled = true;
                выделитьВсеToolStripMenuItem.Enabled = true;
                вырезатьToolStripMenuItem.Enabled = true;
                копироватьКакМетафайлToolStripMenuItem.Enabled = true;
                if (f.pasteflag == true)
                {
                    вставитьToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                копироватьToolStripMenuItem.Enabled = false;
                выделитьВсеToolStripMenuItem.Enabled = false;
                вырезатьToolStripMenuItem.Enabled = false;
                копироватьКакМетафайлToolStripMenuItem.Enabled = false;
                вставитьToolStripMenuItem.Enabled = false;
            }
        }

        private void сеткаToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (actsetka)
            {
                сеткаToolStripMenuItem1.Checked = false;
                actsetka = false;
            }
            else
            {
                сеткаToolStripMenuItem1.Checked = true;

                actsetka = true;
            }
            Form2 f = (Form2)this.ActiveMdiChild;
            f.printSetka(ssetka, actsetka);
        }

        private void шагСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.shag = ssetka;
            f.ShowDialog();
            ssetka = f.shag;
            Form2 d = (Form2)this.ActiveMdiChild;
            d.printSetka(ssetka, actsetka);
        }

        private void выровнятьПоСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 f = (Form2)this.ActiveMdiChild;
            f.virovniat();

        }

        private void привязкаКСеткеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (привязкаКСеткеToolStripMenuItem.Checked)
                привязкаКСеткеToolStripMenuItem.Checked = false;
            else
                привязкаКСеткеToolStripMenuItem.Checked = true;
            Form2 f = (Form2)ActiveMdiChild;
            f.withsetka = привязкаКСеткеToolStripMenuItem.Checked;
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6((Form2)ActiveMdiChild);
            form.Show();
        }

        private void вставаРисункаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;
            f.openImage();//Вызов метода openfile класса Form2;
        }

        private void экспортРисункаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = (Form2)this.ActiveMdiChild;//Объявление объекта класса Form2 и присвоение ему ссылки на активное дочернее окно;
            f.saveImage();//Вызов метода savefile класса Form2;
        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        public void setMousePositionCaption(int x, int y)
        {
            if (x >= 0 && y >= 0)
                statusBarPanel4.Text = x + "," + y;
            else
                statusBarPanel4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void сеткаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void refresh()
        {

            statusBar1.Refresh();//Перерисовка строки состояния;
        }

    }
}
