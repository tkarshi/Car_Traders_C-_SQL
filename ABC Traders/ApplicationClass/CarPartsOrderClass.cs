using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Traders.ApplicationClass
{
    internal class CarPartsOrderClass:DatabaseClass
    {
        public static DataGridView dataGridView;
        public static DateTime date { get; set; }
        public static float totalAmount { get; set; }
        public static float discount { get; set; }
        public static int quantity { get; set; }
        public static String email { get; set; }
        public static int carpartsOrderStatus_id_fk { get; set; }
        public static void ordercarpart1(carPartsOrder cporder_customer, int carpart_id)
        {
            carpart_id = CarpartsDashboardClass.carpart_id1;

            string sql = "Select * from Car_Part_Detail CPD Join Model M on CPD.model_id_fk = M.model_id Join Brand B on CPD.brand_id_fk = B.brand_id Join Condition CO on CPD.condition_id_fk = CO.condition_id Join CarPart CP on CPD.carpart_id = CP.part_id Where part_id = '" + carpart_id + "'";

            //int cartype_id = customerDashboard(searcCarComboBox.SelectedIndex);

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                cporder_customer.carpartModelLabel.Text = dt.Rows[0]["modelName"].ToString();
                cporder_customer.carpartBrandLabel.Text = dt.Rows[0]["brandName"].ToString();
                cporder_customer.carpartNameLabel.Text = dt.Rows[0]["partName"].ToString();
                cporder_customer.carpartConditionLabel.Text = dt.Rows[0]["condition"].ToString();
                cporder_customer.carpartStockLabel.Text = dt.Rows[0]["stock"].ToString();
                cporder_customer.carpartWarrantyLabel.Text = dt.Rows[0]["warranty"].ToString();
                cporder_customer.carpartYearLabel.Text = dt.Rows[0]["year"].ToString();
                cporder_customer.carpartColorLabel.Text = dt.Rows[0]["colorFamily"].ToString();
                cporder_customer.carpartInstallLabel.Text = dt.Rows[0]["installment"].ToString();

                int cpprice1 = CarpartsDashboardClass.cpprice1;

                cporder_customer.totalTextBoxCp.Text = cpprice1.ToString();

            }
        }

        //calculate the total amount based on the quantity
        public static void AddToCart(carPartsOrder cporder_customer, int quantity, int totalAmount)
        {
            int quantity_order = quantity;

            int amount = totalAmount;

            if (quantity_order > 1)
            {
                totalAmount = quantity_order * amount;

                cporder_customer.totalTextBoxCp.Text = totalAmount.ToString();

            }
        }

        public static void LoadForeignKeyPaymentMethod(ComboBox comboBox)
        {
            String paymethod = "select * from Payment_Type";
            PaymentMethodLoad(paymethod, comboBox, "method", "paytype_id");
        }

        public static void view()
        {
            string sql = "Select * from Car_Parts_Order CPO Join Customer C on CPO.customer_id_fk = C.customer_id Join Car_Parts_Order_Status CPOS on CPO.carpartsOrderStatus_id_fk = CPOS.carpartsOrderStatus_id";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }

        public static void Save()
        {

            String customer_reterived_id = "Select customer_id From Customer Where email ='" + email + "'";

            DataTable dt = getDataFromDatabase(customer_reterived_id);

            customer_reterived_id = dt.Rows[0]["customer_id"].ToString();

            int.Parse(customer_reterived_id);

            carpartsOrderStatus_id_fk = 2;

            String order_registration = "INSERT INTO Car_Parts_Order VALUES('" + date + "','" + totalAmount + "','" + discount + "','" + customer_reterived_id + "','" + carpartsOrderStatus_id_fk + "')";

            if (executeQuery(order_registration, functionType.insert))
            {

                MessageBox.Show("Successfully Car Part Order Confirmed", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                view();

            }
            else
            {
                MessageBox.Show("Invalid Order Details", "Warning Message", MessageBoxButtons.OK);
            }
        }
    }

    
}
