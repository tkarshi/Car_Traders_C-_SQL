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
    public partial class adminDashboardLoad : Form
    {
        public adminDashboardLoad()
        {
            InitializeComponent();
        }

        private void adminDashboardLoad_Load(object sender, EventArgs e)
        {
            adminDashboardLoad adminDashboardInstance = this;
            AdminClass.LoadCarTypeDataInChart(adminDashboardInstance);
            AdminClass.LoadBrandDataInChart(adminDashboardInstance);
            AdminClass.LoadModelDataInChart(adminDashboardInstance);

            AdminClass.dataGridView =customerDataGridView;
            AdminClass.view();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            inventoryReports inventory = new inventoryReports();
            this.Hide();
            inventory.Show();
        }

        private void customerDashboardBtn_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }

        private void carDetBtn_Click(object sender, EventArgs e)
        {
            manageCarParts manage_car = new manageCarParts();
            this.Hide();
            manage_car.Show();
        }

        private void carpartDetBtn_Click(object sender, EventArgs e)
        {
            manageCarParts manage_car = new manageCarParts();
            this.Hide();
            manage_car.Show();
        }

        private void manageOrderBtn_Click(object sender, EventArgs e)
        {
            manageCustomerOrder manage_order = new manageCustomerOrder();
            this.Hide();
            manage_order.Show();
        }

        private void manageCustomerBtn_Click(object sender, EventArgs e)
        {
            manageCustomerDetails manage_customer = new manageCustomerDetails();
            this.Hide();    
            manage_customer.Show();
        }

        private void adminLogoutBtn_Click(object sender, EventArgs e)
        {

            // Close or hide the current form (assuming it's the main form)
            this.Close(); // or this.Hide();

            // Optionally, show the login form or another form to handle login
            loginPage loginForm = new loginPage();

            loginForm.Show();
        }
    }
}
