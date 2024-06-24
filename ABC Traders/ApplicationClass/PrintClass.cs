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
    internal class PrintClass:DatabaseClass
    {
        public static int order_id {  get; set; }

        public static void print(PrintBill print_bill, int order_id)
        {
            order_id = int.Parse(print_bill.orderIDTextBox.Text);

            string sql = "Select * from  Car_Order CO Join Customer C on CO.customer_id_fk = C.customer_id Join Car_Order_Detail COD on COD.carOrder_id_fk = CO.carorder_id Join Car_Order_Status CS on CO.carOrderStatus_id_fk = CS.carOrderStatus_id Join Car_Detail CD on COD.car_id_fk = CD.car_id\r\nJoin Model M on CD.model_id_fk = M.model_id Join Brand B on CD.brand_id_fk = B.brand_id Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id where carorder_id = '" + order_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                print_bill.statusprint.Text = dt.Rows[0]["orderStatus"].ToString();
                print_bill.typePrint.Text = dt.Rows[0]["typeName"].ToString();
                print_bill.brandPrint.Text = dt.Rows[0]["brandName"].ToString();
                print_bill.modelPrint.Text = dt.Rows[0]["modelName"].ToString();
                print_bill.totalPrint.Text = dt.Rows[0]["totalAmount"].ToString();
                print_bill.wifiPrint.Text = dt.Rows[0]["wifiAccess"].ToString();
                print_bill.babySeatPrint.Text = dt.Rows[0]["babySeat"].ToString();
                print_bill.seatPrint.Text = dt.Rows[0]["seat"].ToString();
                print_bill.yearPrint.Text = dt.Rows[0]["year"].ToString();
                print_bill.colorPrint.Text = dt.Rows[0]["colorFamily"].ToString();
                print_bill.wheelPrint.Text = dt.Rows[0]["wheel"].ToString();
                print_bill.discountPrint.Text = dt.Rows[0]["discount"].ToString();
                print_bill.datePrint.Text = dt.Rows[0]["date"].ToString();
                print_bill.orderIdPrint.Text = dt.Rows[0]["carorder_id"].ToString();
                print_bill.emailPrint.Text = dt.Rows[0]["email"].ToString();
                print_bill.namePrint.Text = dt.Rows[0]["name"].ToString();


            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Warning Message", MessageBoxButtons.OK);
            }
        }
    }
}
