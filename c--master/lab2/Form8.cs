using System;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form2 main = this.Owner as Form2;
            if (main != null)
            {
                //string s = main.col;
                main.col = this.textBox1.Text;
            }
            this.Close();
        }
    }
}
