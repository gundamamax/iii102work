using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專題
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 myForm2 = new Form2();
            this.Hide();
            myForm2.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 myForm3 = new Form3();
            this.Hide();
            myForm3.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ORDERSYSTEM myORDERSYSTEM = new ORDERSYSTEM();
            this.Hide();
            myORDERSYSTEM.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 myORDERSYSTEM = new Form5();
            this.Hide();
            myORDERSYSTEM.ShowDialog();
            this.Show();

        }
    }
}
