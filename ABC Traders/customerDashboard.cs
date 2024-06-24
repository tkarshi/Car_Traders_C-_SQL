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
    public partial class customerDashboard : Form
    {
        public customerDashboard()
        {
            InitializeComponent();
        }

        private void customerDashboard_Load(object sender, EventArgs e)
        {
            CustomerDashboardClass.LoadforeignkeyCarType(searcCarComboBox);  //Load the Car Types in the Combo box
            CustomerDashboardClass.LoadforeignkeyCarpartType(searchCarpartCombobox); //Load the Car Parts in the Combo box
            CustomerDashboardClass.LoadforeignkeyCarpartType(carTypeComboBox);
            CustomerDashboardClass.LoadforeignkeyModel(modelComboBox);  //Load the Models in the Combo box
            CustomerDashboardClass.LoadforeignkeyBrand(brandComboBox);  //Load the Brand in the Combo box
            CustomerDashboardClass.LoadforeignkeyGyearType(gyearComboBox); //Load the Gyear Types in the Combo box

        }

        private void searchCarBtn_Click(object sender, EventArgs e)
        {
            // Assuming you have an instance of CustomerDashboardForm named customerDashboardInstance
            customerDashboard customerDashboardInstance = this;

            // Set the cartype_id property
            CustomerDashboardClass.cartype_id = searcCarComboBox.SelectedIndex;

            // Call the static search method by passing the instance of CustomerDashboardForm
            CustomerDashboardClass.search(customerDashboardInstance, searcCarComboBox.SelectedIndex);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }





        private void searchCarpartsBtn_Click(object sender, EventArgs e)
        {
            carpartsDashboardSearch carpartsDashboard = new carpartsDashboardSearch();
            this.Hide();
            carpartsDashboard.Show();
        }

        private void orderNowBtn1_Click(object sender, EventArgs e)
        {
            orderCustomer order_customer = new orderCustomer();

            OrderCustomerClass.order1(order_customer, CustomerDashboardClass.car_id1);
            this.Hide();
            order_customer.Show();
            
        }

        private void orderIDTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomerOrderTrackClass.carorder_id = int.Parse(orderIDTextBox.Text);

        }

        private void trackOrderBtn_Click(object sender, EventArgs e)
        {
            orderStatusCustomerView orderstatus = new orderStatusCustomerView();

            this.Hide();

            orderstatus.Show();
        }

        private void createNewBtn_Click(object sender, EventArgs e)
        {
            customerRegistration new_account = new customerRegistration();
            this.Hide();
            new_account.Show();
        }

        private void editprofile_Click(object sender, EventArgs e)
        {
            editProfile edit_account = new editProfile();
            this.Hide();
            edit_account.Show();
        }

        private void orderNow2Btn_Click(object sender, EventArgs e)
        {
            orderCustomer order_customer = new orderCustomer();

            OrderCustomerClass.order1(order_customer, CustomerDashboardClass.car_id1);
            this.Hide();
            order_customer.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            orderCustomer order_customer = new orderCustomer();

            OrderCustomerClass.order1(order_customer, CustomerDashboardClass.car_id1);
            this.Hide();
            order_customer.Show();
        }

        private void orderNow4Btn_Click(object sender, EventArgs e)
        {
            orderCustomer order_customer = new orderCustomer();

            OrderCustomerClass.order1(order_customer, CustomerDashboardClass.car_id1);
            this.Hide();
            order_customer.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Optionally, show the login form or another form to handle login
            loginPage loginForm = new loginPage();

            loginForm.Show();
            // Close or hide the current form (assuming it's the main form)
            this.Close(); // or this.Hide();

        }
    }
}
