using System;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form5 : Form
    {
        public int shag = 0;
        int proverka = 0;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proverka = Convert.ToInt32(textBox1.Text);
            if (shag == 0)
            {
                MessageBox.Show("число должно быть больше нуля");
            }
            else
            {
                shag = proverka;
            }
        }
    }
}
