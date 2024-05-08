using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazine_System
{
    public partial class Form4 : Form
    {
        public static Form4 instance;
        public Form4()
        {
            InitializeComponent();
            instance = this;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        //back button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form = new Form5();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form = new Form7();
            form.Show();
        }
    }
}
