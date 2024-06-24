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
    public partial class orderCustomer : Form
    {
        public orderCustomer()
        {
            InitializeComponent();
        }

        private void orderCustomer_Load(object sender, EventArgs e)
        {
            OrderCustomerClass.dataGridView = carOrderDetailDatagridview;
            // Load foreign key values for payment method into a ComboBox
            OrderCustomerClass.LoadForeignKeyPaymentMethod(orderPaymentMethodcomboBox);

            OrderCustomerClass.view();

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            OrderCustomerClass.email = emailTextBox.Text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            OrderCustomerClass.Save();

        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dateTextBox.Text, out DateTime result))
            {
                OrderCustomerClass.date = result;
            }
            else
            {
                // Handle the case where the entered date is not a valid DateTime
                // You might want to display a message to the user or take appropriate action.
            }
        }

        private void orderTotalAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            OrderCustomerClass.totalAmount = Convert.ToInt32(orderTotalAmountTextBox.Text);
        }

        private void orderDiscountTextBox_TextChanged(object sender, EventArgs e)
        {
            OrderCustomerClass.discount = Convert.ToInt32(orderDiscountTextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customerDashboard customerDashboard = new customerDashboard();
            this.Hide();
            customerDashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderCustomerClass.Save();
        }

        private void orderQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            OrderCustomerClass.quantity = Convert.ToInt32(orderQuantityTextBox.Text);
        }

        private void addtoCartBtn_Click(object sender, EventArgs e)
        {
            orderCustomer orderCustomerInstance = this;
            OrderCustomerClass.AddToCart(orderCustomerInstance, Convert.ToInt32(orderQuantityTextBox.Text), Convert.ToInt32(orderTotalAmountTextBox.Text));
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            PrintBill printBill = new PrintBill();
            this.Hide();
            printBill.Show();
        }
    }
}
