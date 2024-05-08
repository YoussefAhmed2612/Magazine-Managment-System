using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Magazine_System
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;"; 
        OracleConnection conn;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
           
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstring = "SELECT TITLE FROM Magazines WHERE MagazineCategory = :category";
            OracleCommand cmdSelect = new OracleCommand(cmdstring, conn);
            cmdSelect.Parameters.Add(":category", textBox1.Text);
            OracleDataReader reader = cmdSelect.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
        
    }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

       
    }
}
