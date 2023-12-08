using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
