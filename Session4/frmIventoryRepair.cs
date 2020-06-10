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
    public partial class frmIventoryRepair : Form
    {
        Session4BLL bllss4;
        public string partName { set; get; }
        public string transactionType { set; get; }
        public int amount { set; get; }
        public string source { set; get; }
        public string destination { set; get; }
        public int orderitemid { set; get; }
        public int ordersid { set; get; }

        public frmIventoryRepair()
        {
            InitializeComponent();
            bllss4 = new Session4BLL();
        }

        private void frmIventoryRepair_Load(object sender, EventArgs e)
        {
            DataTable dt = bllss4.getAllPart();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr[1]);
            }

            DataTable dt1 = bllss4.getAllTranSactionTypes();
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox2.Items.Add(dr[1]);
            }

            DataTable dt2 = bllss4.getAllWareHouses();
            foreach (DataRow dr in dt2.Rows)
            {
                comboBox4.Items.Add(dr[1]);
            }
            addValuecbb5();
            comboBox1.SelectedText = partName;
            comboBox2.SelectedText = transactionType;
            txtAmount.SelectedText = amount.ToString();
            comboBox4.SelectedText = source;
            comboBox5.SelectedText = destination;

        }

        private void addValuecbb5()
        {
            DataTable dt3 = bllss4.getAllWareHouses();
            foreach (DataRow dr in dt3.Rows)
            {
                comboBox5.Items.Add(dr[1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (comboBox1.SelectedItem != null)
            {
                dt = bllss4.getIdByPartName(comboBox1.SelectedItem.ToString());
            }
            else
            {
                dt = bllss4.getIdByPartName(partName);
            }

            DataTable dtSource = new DataTable();
            if (comboBox4.SelectedItem != null)
            {
                dtSource = bllss4.getIdByWareHouse(comboBox4.SelectedItem.ToString());
            }
            else
            {
                dtSource = bllss4.getIdByWareHouse(source);
            }

            DataTable dtDes = new DataTable();
            if(comboBox5.SelectedItem !=null)
            {
                dtDes = bllss4.getIdByWareHouse(comboBox5.SelectedItem.ToString());
            }
            else
            {
                dtDes = bllss4.getIdByWareHouse(destination);
            }

            DataTable dtTran = new DataTable();
            if (comboBox2.SelectedItem != null)
            {
                dtTran = bllss4.getIdByTranSactionName(comboBox2.SelectedItem.ToString());
            }
            else
            {
                dtTran = bllss4.getIdByTranSactionName(transactionType);
            }

            int PartID = int.Parse(dt.Rows[0][0].ToString());
            int SourceID = int.Parse(dtSource.Rows[0][0].ToString());
            int DesId = int.Parse(dtDes.Rows[0][0].ToString());
            int TranId = int.Parse(dtTran.Rows[0][0].ToString());
            int amountr = int.Parse(txtAmount.Text);

            bllss4.update(PartID, amountr, orderitemid);
            bllss4.update2(SourceID, DesId, TranId, ordersid);
            bool check1 = bllss4.update(PartID, amountr, orderitemid);
            bool check2 = bllss4.update2(SourceID, DesId, TranId, ordersid);
            if (check1 == true && check2 ==true)
            {
                MessageBox.Show("Cap nhat thanh cong");
            }
            else
            {
                MessageBox.Show("Cap nhat that bai");
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            comboBox5.ResetText();
            addValuecbb5();
            int selected1 = comboBox4.SelectedIndex;
            if (selected1 >= 0)
            {
                comboBox5.Items.RemoveAt(selected1);
            }
        }
    }
}
