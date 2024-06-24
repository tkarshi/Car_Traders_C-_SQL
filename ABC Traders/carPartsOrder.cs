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
    public partial class carPartsOrder : Form
    {
        public carPartsOrder()
        {
            InitializeComponent();
        }

        private void carPartsOrder_Load(object sender, EventArgs e)
        {
            CarPartsOrderClass.LoadForeignKeyPaymentMethod(paymethodCombo);
            CarPartsOrderClass.dataGridView = carpartdataview;
            CarPartsOrderClass.view();
        }

        private void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            CarPartsOrderClass.discount = Convert.ToInt32(discountTextBox.Text);
        }

        private void totalTextBox_TextChanged(object sender, EventArgs e)
        {
            CarPartsOrderClass.totalAmount = Convert.ToInt32(totalTextBoxCp.Text);
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            CarPartsOrderClass.email = emailTextBox.Text;
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dateTextBox.Text, out DateTime result))
            {
                CarPartsOrderClass.date = result;
            }
            else
            {
                // Handle the case where the entered date is not a valid DateTime
                // You might want to display a message to the user or take appropriate action.
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }

        private void addtoCartBtnCP_Click(object sender, EventArgs e)
        {
            carPartsOrder carPartOrderInstance = this;
            CarPartsOrderClass.AddToCart(carPartOrderInstance, int.Parse(cpquantityTextBox.Text), Convert.ToInt32(totalTextBoxCp.Text));
        }

        private void cpquantityTextBox_TextChanged(object sender, EventArgs e)
        {
            CarPartsOrderClass.quantity = int.Parse(cpquantityTextBox.Text);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            CarPartsOrderClass.Save();
        }
    }
}
