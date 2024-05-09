using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Magazine_System
{
    public partial class Form7 : Form
    {
        CrystalReport1 CR;
        public static Form7 instance;
        public Form7()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport1();
            foreach(ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.Text);
            CR.SetParameterValue(1, Convert.ToDateTime(textBox1.Text));
            crystalReportViewer1.ReportSource = CR;
          
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
