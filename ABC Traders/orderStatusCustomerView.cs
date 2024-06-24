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
    public partial class orderStatusCustomerView : Form
    {
        public orderStatusCustomerView()
        {
            InitializeComponent();
        }

        private void orderStatusCustomerView_Load(object sender, EventArgs e)
        {
            CustomerOrderTrackClass.dataGridView = ordercustomerDataview;
           
            CustomerOrderTrackClass.view();

            CustomerOrderTrackClass.LoadforeignkeyGyearType(gyearTypeComboBox);
            CustomerOrderTrackClass.LoadforeignkeyBrand(brandComboBox);
            CustomerOrderTrackClass.LoadforeignkeyModel(modelComboBox);
            CustomerOrderTrackClass.LoadforeignkeyCarType(carTypeComboBox);
            CustomerOrderTrackClass.LoadforeignkeyCarType(searchcarComboBox);
            CustomerOrderTrackClass.LoadforeignkeyCarpartType(carpartssearchComboBox);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            customerDashboard customer = new customerDashboard();
            this.Hide();
            customer.Show();
        }

        private void cpsearchCarBtn_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }
    }
}
