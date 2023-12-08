using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace lab2
{
    public partial class Form6 : Form
    {
        Form2 form;
        int list_number;
        TextBox textBox;
        TextBox SizeBox;
        TextBox LineSize;
        Button LineColor;
        CheckBox checkBox;
        Label label;
        Button BrushColor;
        TextBox Textbox;
        Button Textcol;

        public Form6(Form2 form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            ListView listView1 =  new ListView();
            listView1.Location = new Point(12, 12);
            listView1.Size = new Size(305, 200);
            listView1.View = View.Details;

            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;


            ListViewItem[] ListViewItems = new ListViewItem[form.list.Count];
            int i = 0;
            foreach (figure figure in form.list)
            {
                ListViewItems[i] = new ListViewItem($"{i + 1}");
                if (figure is rect)
                    ListViewItems[i].SubItems.Add("Rectangle");
                if (figure is ellipse)
                    ListViewItems[i].SubItems.Add("Ellipse");
                if (figure is line)
                    ListViewItems[i].SubItems.Add("Line");
                if (figure is curve)
                    ListViewItems[i].SubItems.Add("Curve");
                if (figure is text)
                    ListViewItems[i].SubItems.Add("Text");

                ListViewItems[i].SubItems.Add($"{figure.p1.X}:{figure.p1.Y}");
                i++;
            }

            listView1.Columns.Add("Номер элемента", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Тип фигуры", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Координаты начальной точки", 100, HorizontalAlignment.Left);

            listView1.Items.AddRange(ListViewItems);
            Controls.Add(listView1);
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;

            textBox = new TextBox();
            textBox.Location = new Point(322, 12);
            textBox.Size = new Size(100, 50);
            textBox.Visible = false;
            this.Controls.Add(textBox);
            

            SizeBox = new TextBox();
            SizeBox.Location = new Point(322, 62);
            SizeBox.Size = new Size(100, 50);
            SizeBox.Visible = false;
            this.Controls.Add(SizeBox);
            

            LineSize = new TextBox();
            LineSize.Location = new Point(322, 132);
            LineSize.Size = new Size(100, 50);
            LineSize.Visible = false;
            this.Controls.Add(LineSize);
            

            LineColor = new Button();
            LineColor.Location = new Point(322, 102);
            LineColor.Visible = false;
            LineColor.Size = new Size(100, 20);
            LineColor.Padding = new Padding(0);
            this.Controls.Add(LineColor);
            LineColor.Click += LineColor_Click;
           

            checkBox = new CheckBox();
            checkBox.Location = new Point(402, 182);
            checkBox.Size = new Size(20, 20);
            checkBox.Visible = false;
            this.Controls.Add(checkBox);
            

            label = new Label();
            label.Location = new Point(332, 182);
            label.Visible = false;
            label.Size = new Size(60, 50);
            this.Controls.Add(label);

            BrushColor = new Button();
            BrushColor.Location = new Point(332, 232);
            BrushColor.Visible = false;
            BrushColor.Size = new Size(100, 20);
            BrushColor.Padding = new Padding(0);
            this.Controls.Add(BrushColor);
            BrushColor.Click += BrushColor_Click;
                    

            Textbox = new TextBox();
            Textbox.Location = new Point(422, 232);
            Textbox.Size = new Size(100, 200);
            Textbox.Multiline = true;
            Textbox.ScrollBars = ScrollBars.Vertical;
            Textbox.AcceptsReturn = true;
            Textbox.Visible = false;
            this.Controls.Add(Textbox);

            Textcol = new Button();
            Textcol.Location = new Point(742, 12);
            Textcol.Visible = false;
            Textcol.Size = new Size(100, 50);
            Textcol.Padding = new Padding(0);
            this.Controls.Add(Textcol);
            Textcol.Click += Text_Click;


        }

        private void LineColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();//Создание объекта класса ColorDialog;
            color.ShowDialog();//Отображение диалогового окна;
            
            Controls[10].BackColor = color.Color;
        }

        private void Text_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();//Создание объекта класса FontDialog;
            dialog.ShowDialog();// Отображение диалогового окна;

            Controls[15].Font = dialog.Font;
        }

        private void BrushColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();//Создание объекта класса ColorDialog;
            color.ShowDialog();//Отображение диалогового окна;
            Controls[13].BackColor = color.Color;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textBox.Visible = false;
            SizeBox.Visible = false;
            LineSize.Visible = false;
            LineColor.Visible = false;
            checkBox.Visible = false;
            label.Visible = false;
            BrushColor.Visible = false;
            Textbox.Visible = false;
            Textcol.Visible = false;

            list_number = Convert.ToInt32(e.Item.SubItems[0].Text) - 1;
            form.choosed.Clear();
            form.choosed.Add(form.list[list_number]);
            form.Invalidate();
            if ((e.Item.SubItems[1].Text == "Rectangle") || (e.Item.SubItems[1].Text == "Ellipse"))
            {
                
                textBox.Text = e.Item.SubItems[2].Text;
                textBox.Visible = true;

                
                SizeBox.Text = $"{form.list[list_number].p2.X}:{form.list[list_number].p2.Y}";
                SizeBox.Visible = true;

                
                LineSize.Text = $"{form.list[list_number].size}";
                LineSize.Visible = true;


                
                LineColor.Text = "Цвет линии";
                LineColor.BackColor = form.list[list_number].lc;
                LineColor.Visible = true;

                
                checkBox.Checked = form.list[list_number].br;
                checkBox.Visible = true;

               
                label.Text = "Заливка";
                label.Visible = true;



                
                BrushColor.BackColor = form.list[list_number].f;
                BrushColor.Text = "Цвет заливки";
                BrushColor.Visible = true;




            }
            if (e.Item.SubItems[1].Text == "Line")
            {
                
                textBox.Text = e.Item.SubItems[2].Text;
                textBox.Visible = true;

                
                SizeBox.Text = $"{form.list[list_number].p2.X}:{form.list[list_number].p2.Y}";
                SizeBox.Visible = true;

                
                LineSize.Text = $"{form.list[list_number].size}";
                LineSize.Visible = true;

                
                LineColor.BackColor = form.list[list_number].lc;
                LineColor.Text = "Цвет линии";
                LineColor.Visible = true;

               
            }
            if (e.Item.SubItems[1].Text == "Curve")
            {
                
                foreach (PointF p in ((curve)form.list[list_number]).points)
                Textbox.Text += $"{p.X}:{p.Y}\r\n";
                Textbox.Visible = true;

                LineSize.Text = $"{form.list[list_number].size}";
                LineSize.Visible = true;

                
                LineColor.BackColor = form.list[list_number].lc;
                LineColor.Text = "Цвет линии";
                LineColor.Visible = true;

             

            }
            if (e.Item.SubItems[1].Text == "Text")
            {

                textBox.Text = e.Item.SubItems[2].Text;
                textBox.Visible = true;


                SizeBox.Text = $"{form.list[list_number].p2.X}:{form.list[list_number].p2.Y}";
                SizeBox.Visible = true;

                LineColor.BackColor = form.list[list_number].lc;
                LineColor.Text = "Цвет линии";
                LineColor.Visible = true;

                Textcol.Font = form.list[list_number].font;
                Textcol.Text = "Шрифт";
                Textcol.Visible = true;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox.Visible)
            {
                if ((!String.IsNullOrEmpty(((TextBox)this.Controls[7]).Text)) && (Regex.IsMatch(((TextBox)this.Controls[7]).Text, @"[0-9]{1,}:[0-9]{1,}")))
                {
                    form.list[list_number].p1 = new Point(Convert.ToInt32(((TextBox)this.Controls[7]).Text.Split(':').First()), Convert.ToInt32(((TextBox)this.Controls[7]).Text.Split(':').Skip(1).First()));
                    form.list[list_number].p11 = new Point(Convert.ToInt32(((TextBox)this.Controls[7]).Text.Split(':').First()), Convert.ToInt32(((TextBox)this.Controls[7]).Text.Split(':').Skip(1).First()));
                }
            }
            if (SizeBox.Visible)
            {
                if ((!String.IsNullOrEmpty(((TextBox)this.Controls[8]).Text)) && (Regex.IsMatch(((TextBox)this.Controls[8]).Text, @"[0-9]{1,}:[0-9]{1,}")))
                {
                    form.list[list_number].p2 = new Point(Convert.ToInt32(((TextBox)this.Controls[8]).Text.Split(':').First()), Convert.ToInt32(((TextBox)this.Controls[8]).Text.Split(':').Skip(1).First()));
                    form.list[list_number].p21 = new Point(Convert.ToInt32(((TextBox)this.Controls[8]).Text.Split(':').First()), Convert.ToInt32(((TextBox)this.Controls[8]).Text.Split(':').Skip(1).First()));
                }
            }
            if (LineSize.Visible)
            {
                if (!String.IsNullOrEmpty((((TextBox)this.Controls[9]).Text)) && (Convert.ToInt32(((TextBox)this.Controls[9]).Text) > 0))
                    form.list[list_number].size = Convert.ToInt32(((TextBox)this.Controls[9]).Text);
            }
            if (LineColor.Visible)
            {
                
                form.list[list_number].lc = Controls[10].BackColor;//Присвоение переменной выбранного цвета;
                
            }
            if (checkBox.Visible)
            {
                form.list[list_number].br = ((CheckBox)this.Controls[11]).Checked;
                
            }
            if (BrushColor.Visible)
            {
                
                form.list[list_number].f = Controls[13].BackColor;//Присвоение переменной выбранного цвета;
                
            }
            if (Textbox.Visible)
            {
                String[] accpass = ((TextBox)Controls[14]).Text.Split(new Char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                PointF[] points = new PointF[accpass.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    if ((!String.IsNullOrEmpty(accpass[i])) && (Regex.IsMatch(accpass[i], @"[0-9]{1,}:[0-9]{1,}\r")))
                        points[i] = new PointF(Convert.ToInt32((accpass[i].Split(':').First())), Convert.ToInt32(accpass[i].Split(':').Skip(1).First()));
                }
            ((curve)form.list[list_number]).list.Clear();
                ((curve)form.list[list_number]).list.AddRange(points);

            }
            if (Textcol.Visible)
            {

                form.list[list_number].font = Controls[15].Font;//Присвоение переменной выбранного цвета;

            }

            form.Invalidate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.choosed.Clear();
            form.choosed.Add(form.list[list_number]);
            form.Delete();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            (form.list[list_number], form.list[list_number - 1]) = (form.list[list_number - 1], form.list[list_number]);
            ((ListView)Controls[6]).Items.Clear();
            ListViewItem[] ListViewItems = new ListViewItem[form.list.Count];
            int i = 0;
            foreach (figure figure in form.list)
            {
                ListViewItems[i] = new ListViewItem($"{i + 1}");
                if (figure is rect)
                    ListViewItems[i].SubItems.Add("Rectangle");
                if (figure is ellipse)
                    ListViewItems[i].SubItems.Add("Ellipse");
                if (figure is line)
                    ListViewItems[i].SubItems.Add("Line");
                if (figure is curve)
                    ListViewItems[i].SubItems.Add("Curve");
                if (figure is text)
                    ListViewItems[i].SubItems.Add("Text");

                ListViewItems[i].SubItems.Add($"{figure.p1.X}:{figure.p1.Y}");
                i++;
            }


            ((ListView)Controls[6]).Items.AddRange(ListViewItems);

        }

        private void button6_Click(object sender, EventArgs e)
        {

            (form.list[list_number], form.list[list_number + 1]) = (form.list[list_number + 1], form.list[list_number]);
            ((ListView)Controls[6]).Items.Clear();
            ListViewItem[] ListViewItems = new ListViewItem[form.list.Count];
            int i = 0;
            foreach (figure figure in form.list)
            {
                ListViewItems[i] = new ListViewItem($"{i + 1}");
                if (figure is rect)
                    ListViewItems[i].SubItems.Add("Rectangle");
                if (figure is ellipse)
                    ListViewItems[i].SubItems.Add("Ellipse");
                if (figure is line)
                    ListViewItems[i].SubItems.Add("Line");
                if (figure is curve)
                    ListViewItems[i].SubItems.Add("Curve");
                if (figure is text)
                    ListViewItems[i].SubItems.Add("Text");

                ListViewItems[i].SubItems.Add($"{figure.p1.X}:{figure.p1.Y}");
                i++;
            }


            ((ListView)Controls[6]).Items.AddRange(ListViewItems);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
            string type = form7.type;
            switch (type)
            {
                case "Прямоугольник":
                    form.list.Add(new rect(0, 0, Color.White, Color.Black, 1, form.s, true, form.font));
                    break;
                case "Эллипс":
                    form.list.Add(new ellipse(0, 0, Color.White, Color.Black, 1, form.s, true, form.font));
                    break;
                case "Линия":
                    form.list.Add(new line(0, 0, Color.White, Color.Black, 1, form.s, true, form.font));
                    break;
                case "Кривая":
                    form.list.Add(new curve(0, 0, Color.White, Color.Black, 1, form.s, true, form.font));
                    break;
                case "Текст":
                        form.list.Add(new text(0, 0, Color.White, Color.Black, 1, form.s, true, form.font)); 
                    break;

                default:
                    break;
            }

                        ((ListView)Controls[6]).Items.Clear();
            ListViewItem[] ListViewItems = new ListViewItem[form.list.Count];
            int i = 0;
            foreach (figure figure in form.list)
            {
                ListViewItems[i] = new ListViewItem($"{i + 1}");
                if (figure is rect)
                    ListViewItems[i].SubItems.Add("Rectangle");
                if (figure is ellipse)
                    ListViewItems[i].SubItems.Add("Ellipse");
                if (figure is line)
                    ListViewItems[i].SubItems.Add("Line");
                if (figure is curve)
                    ListViewItems[i].SubItems.Add("Curve");
                if (figure is text)
                    ListViewItems[i].SubItems.Add("Text");

                ListViewItems[i].SubItems.Add($"{figure.p1.X}:{figure.p1.Y}");
                i++;
            }


            ((ListView)Controls[6]).Items.AddRange(ListViewItems);
        }
    }
}
