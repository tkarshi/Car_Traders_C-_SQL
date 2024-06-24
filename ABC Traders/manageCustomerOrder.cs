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
    public partial class manageCustomerOrder : Form
    {
        public manageCustomerOrder()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            manageCustomerOrder manage_order = this;
            ManageCustomerOrderClass.search(manage_order,int.Parse(searchOrderIdTextBox.Text));
        }

        private void searchOrderIdTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerOrderClass.order_id = int.Parse(searchOrderIdTextBox.Text);
        }

        private void manageCustomerOrder_Load(object sender, EventArgs e)
        {
            ManageCustomerOrderClass.dataGridView = manageCustomerOrderDataGridview;
            ManageCustomerOrderClass.LoadforeignkeyOrderStatus(orderStatusCombo);
            ManageCustomerOrderClass.view();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboardLoad admin_dashboard = new adminDashboardLoad();
            this.Hide();
            admin_dashboard.Show();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            manageCustomerOrder manageOrderInstance = this;

            ManageCustomerOrderClass.CustomerOrderUpdate(manageOrderInstance, int.Parse(searchOrderIdTextBox.Text));
        }

        private void orderStatusCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCustomerOrderClass.carOrderStatus_id_fk = orderStatusCombo.SelectedIndex;
        }
    }
}
