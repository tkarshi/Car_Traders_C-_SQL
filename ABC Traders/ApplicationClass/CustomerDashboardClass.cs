using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.Xml.Linq;


namespace ABC_Traders.ApplicationClass
{
    internal class CustomerDashboardClass : DatabaseClass
    {
        public static int cartype_id { get; set; }

        public static String current_car_id { get; set; }

        public static int car_id1 { get; set; }

        public static DateTime date { get; set; }
        public static float totalAmount { get; set; }
        public static float discount { get; set; }
        public static int customer_id_fk { get; set; }
        public static int carOrderStatus_id_fk { get; set; }

        public static String email { get; set; }

        public static int price1 { get; set; }

        public static void LoadforeignkeyCarType(ComboBox comboBox)
        {
            String carType = "select * from Car_Type";
            LoadforeignkeyInComboBox(carType, comboBox, "typeName","cartype_id");
        }

        public static void LoadforeignkeyCarpartType(ComboBox comboBox)
        {
            String carpart = "select * from CarPart";
            CarPartsLoadInComboBox(carpart, comboBox, "partName", "part_id");
        }

        public static void LoadforeignkeyBrand(ComboBox comboBox)
        {
            String brand = "select * from Brand";
            BrandLoad(brand, comboBox, "brandName", "brand_id");
        }

        public static void LoadforeignkeyModel(ComboBox comboBox)
        {
            String model = "select * from Model";
            BrandLoad(model, comboBox, "modelName", "model_id");
        }

        public static void LoadforeignkeyGyearType(ComboBox comboBox)
        {
            String model = "select * from Gyear_Type";
            BrandLoad(model, comboBox, "gyearType", "gyear_id");
        }

        customerDashboard customerDashboard = new customerDashboard();


        public static void search(customerDashboard customer_dashboard, int cartype_id)
        {
            string sql = "Select*from Car_Detail CD Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id Join Model M on CD.model_id_fk = M.model_id Join Gyear_Type GT on CD.gyear_id_fk = GT.gyear_id Join Brand B on CD.brand_id_fk = B.brand_id Join Condition C on CD.condition_id_fk = C.condition_id Join Fuel F on CD.fuel_id_fk = F.fuel_id Join Car_Order_Detail COD on COD.car_id_fk = CD.car_id Where cartype_id = '" + cartype_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                customer_dashboard.model1Label.Text = dt.Rows[0]["modelName"].ToString();
                customer_dashboard.brand1Label.Text = dt.Rows[0]["brandName"].ToString();
                customer_dashboard.type1Label.Text = dt.Rows[0]["typeName"].ToString();
                customer_dashboard.geyar1Label.Text = dt.Rows[0]["gyearType"].ToString();
                customer_dashboard.condition1Label.Text = dt.Rows[0]["condition"].ToString();
                customer_dashboard.babyseat1Label.Text = dt.Rows[0]["babySeat"].ToString();
                customer_dashboard.wifi1Label.Text = dt.Rows[0]["wifiAccess"].ToString();
                customer_dashboard.seats1Label.Text = dt.Rows[0]["seat"].ToString();
                customer_dashboard.wheels1Label.Text = dt.Rows[0]["wheel"].ToString();
                customer_dashboard.year1Label.Text = dt.Rows[0]["year"].ToString();
                customer_dashboard.color1Label.Text = dt.Rows[0]["colorFamily"].ToString();
                customer_dashboard.fuel1Label.Text = dt.Rows[0]["fuelName"].ToString();
                customer_dashboard.price1Label.Text = dt.Rows[0]["unitprice"].ToString();

                 price1 = int.Parse(customer_dashboard.price1Label.Text);

                 current_car_id = dt.Rows[0]["car_id"].ToString();

                 car_id1 = Convert.ToInt32(current_car_id);

                if (dt.Rows.Count > 1)
                {
                    customer_dashboard.model2Label.Text = dt.Rows[1]["modelName"].ToString();
                    customer_dashboard.brand2Label.Text = dt.Rows[1]["brandName"].ToString();
                    customer_dashboard.type2Label.Text = dt.Rows[1]["typeName"].ToString();
                    customer_dashboard.gyearLabel2.Text = dt.Rows[1]["gyearType"].ToString();
                    customer_dashboard.conditionLabel2.Text = dt.Rows[1]["condition"].ToString();
                    customer_dashboard.babyseatLabel2.Text = dt.Rows[1]["babySeat"].ToString();
                    customer_dashboard.wifiLabel2.Text = dt.Rows[1]["wifiAccess"].ToString();
                    customer_dashboard.seatsLabel2.Text = dt.Rows[1]["seat"].ToString();
                    customer_dashboard.wheelsLabel2.Text = dt.Rows[1]["wheel"].ToString();
                    customer_dashboard.yearLabel2.Text = dt.Rows[1]["year"].ToString();
                    customer_dashboard.colorLabel2.Text = dt.Rows[1]["colorFamily"].ToString();
                    customer_dashboard.fuelLabel2.Text = dt.Rows[1]["fuelName"].ToString();
                    customer_dashboard.price2Label.Text = dt.Rows[1]["unitprice"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        customer_dashboard.modelLabel3.Text = dt.Rows[2]["modelName"].ToString();
                        customer_dashboard.brandLabel3.Text = dt.Rows[2]["brandName"].ToString();
                        customer_dashboard.typeLabel3.Text = dt.Rows[2]["typeName"].ToString();
                        customer_dashboard.gyearLabel3.Text = dt.Rows[2]["gyearType"].ToString();
                        customer_dashboard.conditionLabel3.Text = dt.Rows[2]["condition"].ToString();
                        customer_dashboard.babyseatLabel3.Text = dt.Rows[2]["babySeat"].ToString();
                        customer_dashboard.wifiLabel3.Text = dt.Rows[2]["wifiAccess"].ToString();
                        customer_dashboard.seatsLabel3.Text = dt.Rows[2]["seat"].ToString();
                        customer_dashboard.wheelsLabel3.Text = dt.Rows[2]["wheel"].ToString();
                        customer_dashboard.yearLabel3.Text = dt.Rows[2]["year"].ToString();
                        customer_dashboard.colorLabel3.Text = dt.Rows[2]["colorFamily"].ToString();
                        customer_dashboard.fuelLabel3.Text = dt.Rows[2]["fuelName"].ToString();
                        customer_dashboard.price3Label.Text = dt.Rows[2]["unitprice"].ToString();

                        if (dt.Rows.Count > 3)
                        {
                            customer_dashboard.modelLabel4.Text = dt.Rows[3]["modelName"].ToString();
                            customer_dashboard.brandLabel4.Text = dt.Rows[3]["brandName"].ToString();
                            customer_dashboard.typeLabel4.Text = dt.Rows[3]["typeName"].ToString();
                            customer_dashboard.gyearLabel4.Text = dt.Rows[3]["gyearType"].ToString();
                            customer_dashboard.conditionLabel4.Text = dt.Rows[3]["condition"].ToString();
                            customer_dashboard.babyseatLabel4.Text = dt.Rows[3]["babySeat"].ToString();
                            customer_dashboard.wifiLabel4.Text = dt.Rows[3]["wifiAccess"].ToString();
                            customer_dashboard.seatsLabel4.Text = dt.Rows[3]["seat"].ToString();
                            customer_dashboard.wheelsLabel4.Text = dt.Rows[3]["wheel"].ToString();
                            customer_dashboard.yearLabel4.Text = dt.Rows[3]["year"].ToString();
                            customer_dashboard.colorLabel4.Text = dt.Rows[3]["colorFamily"].ToString();
                            customer_dashboard.fuelLabel4.Text = dt.Rows[3]["fuelName"].ToString();
                            customer_dashboard.price4Label.Text = dt.Rows[3]["unitprice"].ToString();

                        }


                    }
                }

               
            }

            else
            {
                MessageBox.Show("Sorry for dissapoint you! The Car Model is not existing yet", "Warning Message", MessageBoxButtons.OK);
            }
        }

    }
}
