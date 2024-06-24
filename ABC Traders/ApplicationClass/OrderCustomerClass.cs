using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using ABC_Traders.CommonClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms.DataVisualization.Charting;

namespace ABC_Traders.ApplicationClass
{
    internal class OrderCustomerClass:DatabaseClass
    {
        public static DateTime date { get; set; }  
        public static float totalAmount { get; set; }   
        public static float discount {  get; set; }
        public static int customer_id_fk { get; set; }
        public static int carOrderStatus_id_fk { get; set; }
        public static int quantity {  get; set; }

        public static String email { get; set; }

        public static DataGridView dataGridView;

        public static void order1( orderCustomer order_customer, int car_id)
        {
            car_id = CustomerDashboardClass.car_id1;

            string sql = "Select*from Car_Detail CD Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id Join Model M on CD.model_id_fk = M.model_id Join Gyear_Type GT on CD.gyear_id_fk = GT.gyear_id Join Brand B on CD.brand_id_fk = B.brand_id Join Condition C on CD.condition_id_fk = C.condition_id Join Fuel F on CD.fuel_id_fk = F.fuel_id Where car_id = '" + car_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                order_customer.orderModelLabel.Text = dt.Rows[0]["modelName"].ToString();
                order_customer.orderBrandLabel.Text = dt.Rows[0]["brandName"].ToString();
                order_customer.orderTypeLabel.Text = dt.Rows[0]["typeName"].ToString();
                order_customer.orderGyearLabel.Text = dt.Rows[0]["gyearType"].ToString();
                order_customer.orderBabyseatLabel.Text = dt.Rows[0]["babySeat"].ToString();
                order_customer.orderWiFiLabel.Text = dt.Rows[0]["wifiAccess"].ToString();
                order_customer.orderSeatsLabel.Text = dt.Rows[0]["seat"].ToString();
                order_customer.orderWheelLabel.Text = dt.Rows[0]["wheel"].ToString();
                order_customer.orderYearLabel.Text = dt.Rows[0]["year"].ToString();
                order_customer.orderColorLabel.Text = dt.Rows[0]["colorFamily"].ToString();

                int price1 = CustomerDashboardClass.price1;

                order_customer.orderTotalAmountTextBox.Text = price1.ToString();

            }
        }

        public static void LoadForeignKeyPaymentMethod(ComboBox comboBox)
        {
            String paymethod = "select * from Payment_Type";
            PaymentMethodLoad(paymethod, comboBox, "method", "paytype_id");
        }

        public static void Save() //the customer order placed function
        {           
            String customer_reterived_id = "Select customer_id From Customer Where email ='" + email + "'";

            DataTable dt = getDataFromDatabase(customer_reterived_id);
            
            customer_reterived_id = dt.Rows[0]["customer_id"].ToString();

            int.Parse(customer_reterived_id);

            carOrderStatus_id_fk = 2;

            String order_registration = "INSERT INTO Car_Order VALUES('" + date + "','" + totalAmount + "','" + discount + "','" + customer_reterived_id + "','" + carOrderStatus_id_fk + "')";

            if (executeQuery(order_registration, functionType.insert)){
                MessageBox.Show("Successfully Order Confirmed", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                view();
                
            }
            else
            {
                    MessageBox.Show("Invalid Order Details", "Warning Message", MessageBoxButtons.OK);
            }
        }
        //calculate the total amount based on the quantity
        public static void AddToCart(orderCustomer order_customer, int quantity, int totalAmount) 
        {
           int quantity_order = quantity;

            int amount = totalAmount;

            if(quantity_order > 1) 
            {
                totalAmount = quantity_order * amount;

                order_customer.orderTotalAmountTextBox.Text = totalAmount.ToString();

            }          
        }

        public static void view()
        {
            string sql = "Select * from Car_Order CO Join Customer C on CO.customer_id_fk = C.customer_id Join Car_Order_Status CS on CO.carOrderStatus_id_fk = CS.carOrderStatus_id";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }
    }
}
