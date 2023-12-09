using System;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form7 : Form
    {
        public string type = "Прямоугольник";
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            type = comboBox1.Text;
        }
    }
}
