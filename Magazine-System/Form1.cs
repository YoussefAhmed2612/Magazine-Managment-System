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
        string ordb = "Data source=orcl;User Id=hr; Password=hr;"; 
        OracleConnection conn;

        public Form1()
        {
            InitializeComponent();
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

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstring = "insert into Magazines Values(:mId,:aId,:Title,:PubDate,0,0,0,:Cat)";
            OracleCommand cmdSelect = new OracleCommand(cmdstring, conn);
            cmdSelect.Parameters.Add("mId", richTextBox3.Text);
            cmdSelect.Parameters.Add("aId", richTextBox2.Text);
            cmdSelect.Parameters.Add("Title", richTextBox1.Text);
            cmdSelect.Parameters.Add("PubDate", richTextBox4.Text);
            cmdSelect.Parameters.Add("Cat", richTextBox5.Text);
            int r = cmdSelect.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Added Successfully");
            }
        }
    }
}
