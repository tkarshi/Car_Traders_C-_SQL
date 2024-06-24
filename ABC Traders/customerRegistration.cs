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
    public partial class customerRegistration : Form
    {
        public customerRegistration()
        {
            InitializeComponent();
        }

        private void customerSaveBtn_Click(object sender, EventArgs e)
        {

            CustomerClass.Save();
        }

        private void customerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.name = customerNameTextBox.Text;
        }

        private void customerEmailTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.email = customerEmailTextBox.Text;
        }

        private void customerAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.address = customerAddressTextBox.Text;
        }


        private void customerUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.username = customerUsernameTextBox.Text;
        }

        private void customerPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.password = customerPasswordTextBox.Text;
        }

        private void customerNo1TextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.contactNo1 = int.Parse(customerNo1TextBox.Text);
        }

        private void customerNo2TextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.contactNo2 = int.Parse(customerNo2TextBox.Text);
        }

        private void customerEmegTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerClass.emergencyNo = int.Parse(customerEmegTextBox.Text);
        }

        private void customerDashboardBtn_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }

        private void customerExitBtn_Click(object sender, EventArgs e)
        {
            loginPage login = new loginPage();
            this.Hide();
            login.Show();
        }
    }
}
