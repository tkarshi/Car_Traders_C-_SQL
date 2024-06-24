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
    public partial class editProfile : Form
    {
        public editProfile()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            customerDashboard customer_dashboard = new customerDashboard();
            this.Hide();
            customer_dashboard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginPage login = new loginPage();
            this.Hide();
            login.Show();
        }
    }
}
