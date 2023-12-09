using System;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form3 : Form
    {
        public int size = 1;// Переменная для обмена данными с Form1;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// Метод, вызываемый при нажатии на кнопку "ОК"
        {

            size = Convert.ToInt32(comboBox1.Text.ToString());// Присвоение переменной выбранного значения;
        }
    }
}
