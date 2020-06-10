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
    public partial class Warehouse_Management : Form
    {
        private Session4BLL bllss4; 
        const int TranID = 2;
        public Warehouse_Management()
        {
            InitializeComponent();
            bllss4 = new Session4BLL();
        }

        private void Warehouse_Management_Load(object sender, EventArgs e)
        {
            DataTable dt = bllss4.getAllWareHouses();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "WareHouseName";
            comboBox1.ValueMember = "ID";

            DataTable dt1 = bllss4.getAllWareHouses();
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "WareHouseName";
            comboBox2.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check2 = true;
            int a = 0;
            if (textBox2.Text.Trim() == "")
            {

                MessageBox.Show("Bạn cần điền Amount");
                check2 = false;

            }

            if (textBox2.Text.Trim() != "")
            {
                try
                {
                    a = int.Parse(textBox2.Text);
                    if (a < 0)
                    {
                        MessageBox.Show("Amount là số dương");
                        check2 = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Amount là chữ số");
                    check2 = false;
                }
            }


            if (check2 == true)
            {
                dataGridView1.Rows.Add(comboBox3.Text,comboBox4.Text ,textBox2.Text);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.ValueMember == "PartID")
            {
                DataTable dt = bllss4.getBatchByPartAndDes(int.Parse(comboBox1.SelectedValue.ToString()),
                    int.Parse(comboBox3.SelectedValue.ToString()));
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "BathNumber";
                comboBox4.ValueMember = "BathNumber";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("Dữ liệu Warehouse không được trùng");
            }
            else
            {
                if (dataGridView1.Rows.Count >= 2)
                {
                    bllss4.insertIntoOrdersAdj(TranID, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), dateTimePicker1.Value.ToString());
                    DataTable dt = bllss4.getIDOrders();
                    dt.Rows[0][0].ToString();
                    int OrderId = int.Parse(dt.Rows[0][0].ToString());
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        DataTable dt1 = bllss4.getIdByPartName(dataGridView1.Rows[i].Cells["PartName"].Value.ToString());
                        int PartID = int.Parse(dt1.Rows[0][0].ToString());
                        string BathNumber = dataGridView1.Rows[i].Cells["BatchNumber"].Value.ToString();
                        int Amount = int.Parse(dataGridView1.Rows[i].Cells["Amount"].Value.ToString());
                        bllss4.insertIntoOrderItems(OrderId, PartID, BathNumber, Amount);
                        
                    }
                    MessageBox.Show("Thêm dữ liệu thành công");
                }
                else
                {
                    MessageBox.Show("Bạn cần thêm dữ liệu vào bảng");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Bạn muốn xóa", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                int a = int.Parse(comboBox1.SelectedValue.ToString());
                DataTable dt = bllss4.getPartBySource(a);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "PartName";
                comboBox3.ValueMember = "PartID";
            }
            catch (Exception)
            {
               
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
