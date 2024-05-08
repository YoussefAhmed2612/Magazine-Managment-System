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
    public partial class Form3 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet dataset;

        public static Form3 instance;
        public Form3()
        {
            InitializeComponent();
            instance=this;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data source=orcl;User Id=hr; Password=hr;";
            string cmdstr = @"select MagazineID, Title, PublishedOn, likes , shares, reports
                            from Magazines m ,Authors a
                            where m.AuthorId = a.AuthorId and a.AuthorName = :name";
            adapter =new OracleDataAdapter(cmdstr,constr);
            adapter.SelectCommand.Parameters.Add("name",textBox1.Text);
            dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            builder=new OracleCommandBuilder(adapter);
            adapter.Update(dataset.Tables[0]);

        }
    }
}
