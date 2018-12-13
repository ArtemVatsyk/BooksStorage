using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storehouse.WFA
{
    public partial class Product : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Product()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseOneDataSet1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.warehouseOneDataSet1.Product);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RQ486KL;Initial Catalog=WarehouseOne;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            sda = new SqlDataAdapter(@"select * from Product", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
                
            }
        }

        private void providersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Provider p = new Provider();
            p.ShowDialog();
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Types types = new Types();
            types.ShowDialog();
        }

        private void storagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
