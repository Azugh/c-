using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form4 : Form
    {
        public Size s;// Хранит размер рисунка;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)// Проверка, что выбрано: Пользовательский ввод или заранее определенные варианты;
            {
                s.Width = Convert.ToInt32(textBox1.Text.ToString());//Считывание значения из поля textbox;
                s.Height = Convert.ToInt32(textBox2.Text.ToString());//Считывание значения из поля textbox;

            }
            else
            {
                if (radioButton1.Checked)//Проверка какой из вариантов выбран;
                {
                    s.Width = 320;// Заданее выбранного значения;
                    s.Height = 240;// Заданее выбранного значения;

                }
                else if (radioButton2.Checked)//Проверка какой из вариантов выбран;
                {
                    s.Width = 640;// Заданее выбранного значения;
                    s.Height = 480;// Заданее выбранного значения;

                }
                else
                {
                    s.Width = 800;// Заданее выбранного значения;
                    s.Height = 600;// Заданее выбранного значения;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)// Проверка состояния ChekBox
            {
                this.groupBox1.Enabled = false;// Установка элементов выбора в неактивное состояние;
                this.textBox1.Enabled = true;// Установка поля для ввода ширины в активное состояние;
                this.textBox2.Enabled = true;// Установка поля для ввода длины в активное состояние;
            }
            else
            {
                this.groupBox1.Enabled = true;// Установка элементов выбора в активное состояние;
                this.textBox1.Enabled = false;// Установка поля для ввода ширины в неактивное состояние;
                this.textBox2.Enabled = false;// Установка поля для ввода длины в неактивное состояние;

            }
        }
    }
}
