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
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            ////check table name
            //cmd.CommandText = "select MagazineId from Magazines";
            //cmd.CommandType = CommandType.Text;

            //OracleDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox2.Items.Add(dr[0]);
            //}
            //dr.Close();
        }
        //task 1
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
            string cmdstring = "insert into Magazines Values(:mId,:aId,:Cat,:Title,TO_DATE(:PubDate, 'DD-MON-RR'),0,0,0)";
            OracleCommand cmdSelect = new OracleCommand(cmdstring, conn);
            cmdSelect.Parameters.Add(":mId", comboBox2.Text);
            cmdSelect.Parameters.Add(":aId", richTextBox2.Text);
            cmdSelect.Parameters.Add(":Cat", richTextBox5.Text);
            cmdSelect.Parameters.Add(":Title", richTextBox3.Text);
            cmdSelect.Parameters.Add(":PubDate", richTextBox4.Text);
            int r = cmdSelect.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Added Successfully");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = " GetAllMagazines";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
                richTextBox2.Text = dr[1].ToString();
                richTextBox3.Text = dr[3].ToString();
                richTextBox4.Text = dr[4].ToString();
                richTextBox5.Text = dr[2].ToString();
                textBox2.Text = dr[7].ToString();
                textBox3.Text = dr[6].ToString();
                textBox4.Text = dr[5].ToString();
            }
            dr.Close();
        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetMagazineByID";
            cmd.CommandType= CommandType.StoredProcedure;
           // cmd.Parameters.Add("p_MagazineID", OracleDbType.Int32).Value = int.Parse(comboBox2.Text);
            cmd.Parameters.Add("p_MagazineID", Convert.ToInt32(comboBox2.SelectedItem.ToString()));
            cmd.Parameters.Add("p_AuthorID",OracleDbType.Int32,ParameterDirection.Output);
            cmd.Parameters.Add("p_Category", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("p_Title", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("p_PublishedOn", OracleDbType.Date, ParameterDirection.Output);
            cmd.Parameters.Add("p_Likes", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add("p_Reports", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add("p_Shares", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();

            richTextBox2.Text = cmd.Parameters["p_AuthorID"].Value.ToString();
            richTextBox3.Text = cmd.Parameters["p_Title"].Value.ToString();
            richTextBox4.Text = cmd.Parameters["p_PublishedOn"].Value.ToString();
            richTextBox5.Text = cmd.Parameters["p_Category"].Value.ToString();
            textBox4.Text = cmd.Parameters["p_Likes"].Value.ToString();
            textBox3.Text = cmd.Parameters["p_Reports"].Value.ToString();
            textBox2.Text = cmd.Parameters["p_Shares"].Value.ToString();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }
    }
}
