using ABC_Traders.ApplicationClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Traders
{
    public partial class inventoryReports : Form
    {
        public inventoryReports()
        {
            InitializeComponent();
        }

        private void inventoryReports_Load(object sender, EventArgs e)
        {
            ReportClass.dataGridView = reportGridView1;
            ReportClass.view1();
            inventoryReports inverntoryReportsInstance = this;
            ReportClass.DisplayModel(inverntoryReportsInstance);
            ReportClass.DisplayBrand(inverntoryReportsInstance);
            ReportClass.DisplayCarPartType(inverntoryReportsInstance);
            ReportClass.DisplayCarType(inverntoryReportsInstance);
            ReportClass.DisplayCarPartStock(inverntoryReportsInstance);
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            ReportClass.car_id = int.Parse(idTextBox.Text);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            ReportClass.view();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            adminDashboardLoad admin_dashboard = new adminDashboardLoad();
            this.Hide();
            admin_dashboard.Show();
        }
    }
}
