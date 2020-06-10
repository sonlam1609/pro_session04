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
    public partial class frmPurchaseOrder : Form
    {
        private Session4BLL bllss4;
        const int TranID = 1;
        public frmPurchaseOrder()
        {
            InitializeComponent();
            bllss4 = new Session4BLL();
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            DataTable dt = bllss4.getAllSuppliers();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "SupplyName";
            comboBox1.ValueMember = "ID";


            DataTable dt1 = bllss4.getAllWareHouses();
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "WareHouseName";
            comboBox2.ValueMember = "ID";

            DataTable dt2 = bllss4.getAllPart();
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "PartName";
            comboBox3.ValueMember = "ID";
        }

        bool batch;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.ValueMember == "ID")
            {
                DataTable dt = bllss4.getBatchRequired(int.Parse(comboBox3.SelectedValue.ToString()));
                batch = bool.Parse(dt.Rows[0][0].ToString());
                if (batch == true)
                {
                    textBox1.Text = "True";
                }
                else
                {
                    textBox1.Text = "";
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool check1 = true;
            bool check2 = true;

            int a = 0;
            if (batch && textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "True")
            {
                MessageBox.Show("Bạn cần điền Batch Name");
                check1 = false;

            }
            if (batch && textBox2.Text.Trim() == "")
            {

                MessageBox.Show("Bạn cần điền Amount");
                check2 = false;

            }

            if (batch && textBox2.Text.Trim() != "")
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

            if (!batch)
            {
                MessageBox.Show("Kiểm tra Part Name");
            }
            if (check1 == true && check2 == true && batch == true)
            {
                string part = comboBox3.Text;
                string batch = textBox1.Text;
                int amount = int.Parse(textBox2.Text);
                int sum = amount;

                DataTable dt = bllss4.getMiniAmount(part);
                int mini = int.Parse(dt.Rows[0][0].ToString());

                foreach (DataGridViewRow row1 in dataGridView1.Rows)
                {
                    if ((String)row1.Cells["PartName"].Value == part)
                    {
                        sum += int.Parse(row1.Cells["Amount"].Value.ToString());
                    }
                }
                int i = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    
                    if (sum <= mini)
                    {
                        int rowCount = dataGridView1.Rows.Count - 1;
                        if ((String)row.Cells["PartName"].Value == part && (String)row.Cells["BatchNumber"].Value == batch)
                        {
                            int total = int.Parse(row.Cells["Amount"].Value.ToString());
                            total += amount;
                            dataGridView1.Rows.Add(comboBox3.Text, textBox1.Text, total);
                            dataGridView1.Rows.RemoveAt(row.Index);
                            break;
                        }

                        if (i > rowCount)
                        {
                            dataGridView1.Rows.Add(comboBox3.Text, textBox1.Text, textBox2.Text);
                            break;
                        }
                        i++;
                    }
                    else
                    {
                        sum = sum - amount;
                        MessageBox.Show("MiniAmount Hiện tại: " + (mini-sum));
                        break;
                    }
                    
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Source = 0;
            if (comboBox1.SelectedValue.ToString() == "1")
            {
                Source = 1;
            }
            if (comboBox1.SelectedValue.ToString() == "2")
            {
                Source = 2;
            }
            if (comboBox1.SelectedValue.ToString() == "3")
            {
                Source = 3;
            }
            if (comboBox1.SelectedValue.ToString() == "4")
            {
                Source = 4;
            }
            //Them du lieu
                       
            if (dataGridView1.Rows.Count >= 2)
            {
                bllss4.insertIntoOrders(TranID, int.Parse(comboBox1.SelectedValue.ToString()), 
                    Source, int.Parse(comboBox2.SelectedValue.ToString()), dateTimePicker1.Value.ToString());
                DataTable dt = bllss4.getIDOrders();
                int OrderId = int.Parse(dt.Rows[0][0].ToString());
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    DataTable dt1 = bllss4.getIdByPartName(dataGridView1.Rows[i].Cells["PartName"].Value.ToString());
                    int PartID = int.Parse(dt1.Rows[0][0].ToString());
                    string BathNumber = dataGridView1.Rows[i].Cells["BatchNumber"].Value.ToString();
                    int Amount = int.Parse(dataGridView1.Rows[i].Cells["Amount"].Value.ToString());
                    bllss4.insertIntoOrderItems(OrderId, PartID, BathNumber, Amount);
                    bllss4.updateParts(PartID,Amount);
                }
                MessageBox.Show("Thêm dữ liệu thành công");
            }
            else
            {
                MessageBox.Show("Bạn cần thêm dữ liệu vào bảng");
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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
