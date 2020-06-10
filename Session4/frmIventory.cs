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

    public partial class frmIventory : Form
    {
        Session4BLL bllss4;
        public frmIventory()
        {
            InitializeComponent();
            bllss4 = new Session4BLL();
        }
        DataTable dtAll = new DataTable();
        public void frmIventory_Load(object sender, EventArgs e)
        {
            dtAll = bllss4.getAllOrders();
            dataGridView1.DataSource = dtAll;
            DataView view = dtAll.DefaultView;
            view.Sort = "OrderDate ASC, TranSactionName ASC";

            DataTable dt1 = bllss4.getAllWareHouses();
            AmountColor();
        }

        public void AmountColor()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if ((String)row.Cells["TransactionName"].Value == "Purchase Order")
                {
                    row.Cells["Amount"].Style.BackColor = Color.LightGreen;
                }
            }
        }


        private void purchaseOrderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder frmPurchaseOrder = new frmPurchaseOrder();
            frmPurchaseOrder.Show();
        }

        private void warehouseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouse_Management wm = new Warehouse_Management();
            wm.Show();
        }

        

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIventoryReport frmIventoryReport = new frmIventoryReport();
            frmIventoryReport.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {               
                frmIventoryRepair frmIventoryRepair = new frmIventoryRepair();
                DataTable dt = bllss4.getAllOrders();
                frmIventoryRepair.partName = dataGridView1.Rows[e.RowIndex].Cells["PartName"].FormattedValue.ToString();
                frmIventoryRepair.transactionType = dataGridView1.Rows[e.RowIndex].Cells["TransactionName"].FormattedValue.ToString();
                frmIventoryRepair.amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Amount"].FormattedValue.ToString());
                frmIventoryRepair.source = dataGridView1.Rows[e.RowIndex].Cells["Source"].FormattedValue.ToString();
                frmIventoryRepair.destination = dataGridView1.Rows[e.RowIndex].Cells["Destination"].FormattedValue.ToString();
                frmIventoryRepair.orderitemid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["OrderItemId"].FormattedValue.ToString());
                frmIventoryRepair.ordersid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["OrdersId"].FormattedValue.ToString());
                frmIventoryRepair.Show();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!bllss4.delete(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["OrderItemId"].FormattedValue.ToString())))
                    {
                        MessageBox.Show("Xoa that bai");
                    }
                }
                
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIventory_Load(sender,e);
        }

        private int Order = -1;

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ListSortDirection sortDirection;

            if (dataGridView1.SortedColumn.Name == "PartName")
            {
                
                if (this.Order == -1)
                {
                    DataView view = dtAll.DefaultView;
                    view.Sort = "PartName DESC";
                    this.Order = 1;
                    AmountColor();
                }
                else
                {
                    DataView view = dtAll.DefaultView;
                    view.Sort = "PartName ASC";
                    this.Order = -1;
                    AmountColor();
                }
            }

        }
    }
}
