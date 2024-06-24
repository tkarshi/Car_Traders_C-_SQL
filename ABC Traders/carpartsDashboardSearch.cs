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
    public partial class carpartsDashboardSearch : Form
    {
        public carpartsDashboardSearch()
        {
            InitializeComponent();
        }

        private void carpartsDashboardSearch_Load(object sender, EventArgs e)
        {
            CarpartsDashboardClass.LoadforeignkeyCarType(cpsearchcarComboBox);
            CarpartsDashboardClass.LoadforeignkeyCarpartType(cpcarpartssearchComboBox);
            CarpartsDashboardClass.LoadforeignkeyCarType(carTypeComboBox);
            CarpartsDashboardClass.LoadforeignkeyBrand(brandComboBox);
            CarpartsDashboardClass.LoadforeignkeyModel(modelComboBox);
            CarpartsDashboardClass.LoadforeignkeyGyearType(gyearComboBox);
        }

        private void cpsearchCarBtn_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }

        private void cpsearchCarpartsBtn_Click(object sender, EventArgs e)
        {
            // Assuming you have an instance of CustomerDashboardForm named customerDashboardInstance
            carpartsDashboardSearch carpartsDashboardInstance = this;

            // Set the cartype_id property
            CarpartsDashboardClass.carparts_id = cpcarpartssearchComboBox.SelectedIndex;

            // Call the static search method by passing the instance of CustomerDashboardForm
           CarpartsDashboardClass.search(carpartsDashboardInstance, cpcarpartssearchComboBox.SelectedIndex);
        }

        private void orderNowBtn1_Click(object sender, EventArgs e)
        {
            carPartsOrder cporder_customer = new carPartsOrder();

            CarPartsOrderClass.ordercarpart1(cporder_customer, CarpartsDashboardClass.carpart_id1);
            this.Hide();
            cporder_customer.Show();
        }

        private void exitcpbtn_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }
    }
}
