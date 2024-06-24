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
    public partial class PrintBill : Form
    {
        public PrintBill()
        {
            InitializeComponent();
        }

        private void searchPrint_Click(object sender, EventArgs e)
        {
            PrintBill printBillInstance = this;
            PrintClass.print(printBillInstance, int.Parse(orderIDTextBox.Text));
        }

        private void orderIDTextBox_TextChanged(object sender, EventArgs e)
        {
            PrintClass.order_id = int.Parse(orderIDTextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderCustomer orderPage = new orderCustomer();
            this.Hide();
            orderPage.Show();
        }
    }
}
