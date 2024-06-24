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
    internal class ManageCustomerOrderClass:DatabaseClass
    {
        public static DateTime date { get; set; }
        public static float totalAmount { get; set; }
        public static float discount { get; set; }
        public static int order_id { get; set; }
        public static int carOrderStatus_id_fk { get; set; }

        public static String email { get; set; }

        public static DataGridView dataGridView;

        public static void search(manageCustomerOrder manage_order, int order_id)
        {
            string sql = "Select orderStatus, name, address, email, modelName, typeName, brandName, quanitity, totalAmount, carorder_id  from  Car_Order CO Join Customer C on CO.customer_id_fk = C.customer_id Join Car_Order_Detail COD on COD.carOrder_id_fk = CO.carorder_id Join Car_Order_Status CS on CO.carOrderStatus_id_fk = CS.carOrderStatus_id Join Car_Detail CD on COD.car_id_fk = CD.car_id\r\nJoin Model M on CD.model_id_fk = M.model_id Join Brand B on CD.brand_id_fk = B.brand_id Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id where carorder_id = '" + order_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                manage_order.orderStatusCombo.Text = dt.Rows[0]["orderStatus"].ToString();
                manage_order.carTypeTextBox.Text = dt.Rows[0]["typeName"].ToString();
                manage_order.brandTextBox.Text = dt.Rows[0]["brandName"].ToString();
                manage_order.modelTextBox.Text = dt.Rows[0]["modelName"].ToString();
                manage_order.totalAmountTextBox.Text = dt.Rows[0]["totalAmount"].ToString();
                //manage_order.payMethodTextBox.Text = dt.Rows[0]["payMethod"].ToString();
                manage_order.nameTextBox.Text = dt.Rows[0]["name"].ToString();
                manage_order.emailTextBox.Text = dt.Rows[0]["email"].ToString();
                manage_order.addressTextBox.Text = dt.Rows[0]["address"].ToString();
                //manage_order.contNo1TextBox.Text = dt.Rows[0]["contactNo1"].ToString();
                //manage_order.cont2TextBox.Text = dt.Rows[0]["contactNo2"].ToString();
                manage_order.emailTextBox.Text = dt.Rows[0]["email"].ToString();
                //manage_order.totalOrderTextBox.Text = dt.Rows[0]["totalOrder"].ToString();

               
            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void view()
        {

            string sql = "Select orderStatus, name, address, email, modelName, typeName, brandName, quanitity, totalAmount, discount, carorder_id  from  Car_Order CO Join Customer C on CO.customer_id_fk = C.customer_id Join Car_Order_Detail COD on COD.carOrder_id_fk = CO.carorder_id Join Car_Order_Status CS on CO.carOrderStatus_id_fk = CS.carOrderStatus_id Join Car_Detail CD on COD.car_id_fk = CD.car_id Join Model M on CD.model_id_fk = M.model_id Join Brand B on CD.brand_id_fk = B.brand_id  Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id ";

            LoadDataFromDatabaseInGridView(sql, dataGridView);

        }

        public static void CustomerOrderUpdate(manageCustomerOrder manage_order, int order_id)
        {

            carOrderStatus_id_fk = manage_order.orderStatusCombo.SelectedIndex;

            String carorder_update = "UPDATE Car_Order SET  carOrderStatus_id_fk = '"+carOrderStatus_id_fk +"' WHERE carorder_id = '"+order_id+"'";


            if (executeQuery(carorder_update, functionType.update))
            {
                MessageBox.Show("Successfully Order Status Updated", "Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);

                view();
            }
            else
            {
                //the update failed message 
                MessageBox.Show("Invalid Customer Details", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void LoadforeignkeyOrderStatus(ComboBox comboBox)
        {
            String carpart = "select * from Car_Order_Status";
            OrderStatusLoad(carpart, comboBox, "orderStatus", "carOrderStatus_id");
        }
    }
}
