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
    public partial class frmViewBatch : Form
    {
        Session4BLL bllss4;
        public int ID { set; get; }
        public string partName { set; get; }
        public frmViewBatch()
        {
            InitializeComponent();
            bllss4 = new Session4BLL();
        }

        private void frmViewBatch_Load(object sender, EventArgs e)
        {
            DataTable dt = bllss4.getDetailsBatch(ID, partName);
            dataGridView1.DataSource = dt;
        }
    }
}
