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
    public partial class Form6 : Form
    {
        public static Form6 instance;
        public Form6()
        {
            InitializeComponent();
            instance = this; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form = new Form7();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 form = new Form8();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
    }
}
