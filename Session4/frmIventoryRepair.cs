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
        public float amount { set; get; }
        public string source { set; get; }
        public string destination { set; get; }

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
            textBox1.SelectedText = amount.ToString();
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
            DataTable dt = bllss4.getIdByPartName(comboBox1.SelectedItem.ToString());

            try
            {
                MessageBox.Show(dt.Rows[0][0].ToString());
            }
            catch (Exception)
            {

                MessageBox.Show("Pls select combobox");
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
