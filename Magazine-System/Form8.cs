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
    public partial class Form8 : Form
    {
        CrystalReport2 CR;
        public static Form8 instance;
        public Form8()
        {
            InitializeComponent();
            instance = this;
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport2();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }


    }
}
