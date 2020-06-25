using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4
{
    public partial class frmIventoryReport : Form
    {
        private Session4BLL bllss4;
        public frmIventoryReport()
        {
            InitializeComponent();
            bllss4 = new Session4BLL();
        }
        DataTable dt2 = new DataTable();
        private void frmIventoryReport_Load(object sender, EventArgs e)
        {
            DataTable dt1 = bllss4.getAllWareHouses();
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "WareHouseName";
            comboBox1.ValueMember = "ID";

            dt2 = bllss4.getIventoryReport(int.Parse(comboBox1.SelectedValue.ToString()));
            dataGridView1.DataSource = dt2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt2 = bllss4.getIventoryReport(int.Parse(comboBox1.SelectedValue.ToString()));
                dataGridView1.DataSource = dt2;
            }
            catch { }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dt2 = bllss4.getReportNotNull(int.Parse(comboBox1.SelectedValue.ToString()));
            dataGridView1.DataSource = dt2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dt2 = bllss4.getReportNull(int.Parse(comboBox1.SelectedValue.ToString()));
            dataGridView1.DataSource = dt2;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dt2 = bllss4.getIventoryReport(int.Parse(comboBox1.SelectedValue.ToString()));
            dataGridView1.DataSource = dt2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                frmViewBatch frmViewBatch = new frmViewBatch();
                frmViewBatch.ID = int.Parse(comboBox1.SelectedValue.ToString());
                frmViewBatch.partName = dataGridView1.Rows[e.RowIndex].Cells["PartName"].FormattedValue.ToString();
                frmViewBatch.Show();
            }
        }
    }
}
