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
    public partial class manageCustomerDetails : Form
    {
        public manageCustomerDetails()
        {
            InitializeComponent();
        }

        private void manageCustomerDetails_Load(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.dataGridView = customer_detailsdataGridView;
            ManageCustomerDetailsClass.view();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            manageCustomerDetails manageCustomerDetailInstance = this;

            ManageCustomerDetailsClass.Update(manageCustomerDetailInstance, int.Parse(idsearchtextBox.Text));
        }


        private void nametextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.name = nametextBox.Text;
        }

        private void emailtextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.email = emailtextBox.Text;
        }

        private void addresstextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.address = addresstextBox.Text;
        }

        private void contNo1textBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.contactNo1 = int.Parse(contNo1textBox.Text);
        }

        private void contNo2textBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.contactNo2 = int.Parse(contNo2textBox.Text);
        }

        private void emergtextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.emergencyNo = int.Parse(emergtextBox.Text);
        }

        private void usernametextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.username = usernametextBox.Text;
        }

        private void passwordtextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.password = passwordtextBox.Text;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.Save();
            ManageCustomerDetailsClass.view();
        }

        private void emailsearchtextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCustomerDetailsClass.email = idsearchtextBox.Text;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Assuming you have an instance of CustomerDashboardForm named customerDashboardInstance
            manageCustomerDetails manageCustomerDetailInstance = this;

            // Call the static search method by passing the instance of CustomerDashboardForm
            ManageCustomerDetailsClass.search(manageCustomerDetailInstance, int.Parse(idsearchtextBox.Text));

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            manageCustomerDetails manageCustomerDetailInstance = this;

            // Call the static search method by passing the instance of CustomerDashboardForm
            ManageCustomerDetailsClass.Delete(int.Parse(idsearchtextBox.Text));
        }


        private void clearDataBtn_Click(object sender, EventArgs e)
        {
            manageCustomerDetails manageCustomerDetailInstance = this;
            ManageCustomerDetailsClass.clearTextBox(manageCustomerDetailInstance);
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            adminDashboardLoad admin_dashboard = new adminDashboardLoad();
            this.Hide();
            admin_dashboard.Show();
        }
    }
}
