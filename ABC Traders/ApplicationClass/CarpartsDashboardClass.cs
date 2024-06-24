using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ABC_Traders.ApplicationClass
{
    internal class CarpartsDashboardClass:DatabaseClass
    {
        public static int carparts_id { get; set; }

        public static String current_carpart_id { get; set; }

        public static int carpart_id1 { get; set; }

        public static int cpprice1 { get; set; }

        carpartsDashboardSearch carpartsDashboard = new carpartsDashboardSearch();
        public static void LoadforeignkeyCarType(ComboBox comboBox)
        {
            String carType = "select * from Car_Type";
            LoadforeignkeyInComboBox(carType, comboBox, "typeName", "cartype_id");
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

        public static void search(carpartsDashboardSearch carparts_search_dashboard, int part_id_fk)
        {
            string sql = "Select*from Car_Part_Detail CD Join Model M on CD.model_id_fk = M.model_id Join Brand B on CD.brand_id_fk = B.brand_id Join Condition C on CD.condition_id_fk = C.condition_id  Join Car_Part_Order_Detail COD on COD.carparts_id_fk = CD.carpart_id Join Carpart CP ON CD.part_id_fk = CP.part_id Where part_id_fk= '" + part_id_fk + "'";

            //int cartype_id = customerDashboard(searcCarComboBox.SelectedIndex);

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                carparts_search_dashboard.cpmodelLabel1.Text = dt.Rows[0]["modelName"].ToString();
                carparts_search_dashboard.cpbrandLabel1.Text = dt.Rows[0]["brandName"].ToString();
                carparts_search_dashboard.cpnameLabel1.Text = dt.Rows[0]["partName"].ToString();
                carparts_search_dashboard.cpstockLabel1.Text = dt.Rows[0]["stock"].ToString();
                carparts_search_dashboard.cpwarrantyLabel1.Text = dt.Rows[0]["warranty"].ToString();
                carparts_search_dashboard.cpcolorLabel1.Text = dt.Rows[0]["colorFamily"].ToString();
                carparts_search_dashboard.cpconditionLabel1.Text = dt.Rows[0]["condition"].ToString();
                carparts_search_dashboard.cpyearLabel1.Text = dt.Rows[0]["year"].ToString();
                carparts_search_dashboard.cpinstallmentLabel1.Text = dt.Rows[0]["installment"].ToString();
                carparts_search_dashboard.cpunitpriceLabel1.Text = dt.Rows[0]["unitprice"].ToString();

                current_carpart_id = dt.Rows[0]["carpart_id"].ToString();

                carpart_id1 = Convert.ToInt32(current_carpart_id);

                cpprice1 = int.Parse(carparts_search_dashboard.cpunitpriceLabel1.Text);

                if (dt.Rows.Count > 1)
                {
                    carparts_search_dashboard.cpmodelLabel2.Text = dt.Rows[1]["modelName"].ToString();
                    carparts_search_dashboard.cpbranLabel2.Text = dt.Rows[1]["brandName"].ToString();
                    carparts_search_dashboard.cpnameLabel2.Text = dt.Rows[1]["partName"].ToString();
                    carparts_search_dashboard.cpstockLabel2.Text = dt.Rows[1]["stock"].ToString();
                    carparts_search_dashboard.cpwarrantyLabel2.Text = dt.Rows[1]["warranty"].ToString();
                    carparts_search_dashboard.cpcolorLabel2.Text = dt.Rows[1]["colorFamily"].ToString();
                    carparts_search_dashboard.cpconditionLabel2.Text = dt.Rows[1]["condition"].ToString();
                    carparts_search_dashboard.cpyearLabel2.Text = dt.Rows[1]["year"].ToString();
                    carparts_search_dashboard.cpinstallmentLabel2.Text = dt.Rows[1]["installment"].ToString();
                    carparts_search_dashboard.cpunitpriceLabel2.Text = dt.Rows[1]["unitprice"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        carparts_search_dashboard.cpmodelLabel3.Text = dt.Rows[2]["modelName"].ToString();
                        carparts_search_dashboard.cpbrandLabel3.Text = dt.Rows[2]["brandName"].ToString();
                        carparts_search_dashboard.cpnameLabel3.Text = dt.Rows[2]["partName"].ToString();
                        carparts_search_dashboard.cpstockLabel3.Text = dt.Rows[2]["stock"].ToString();
                        carparts_search_dashboard.cpwarrantyLabel3.Text = dt.Rows[2]["warranty"].ToString();
                        carparts_search_dashboard.cpcolorLabel3.Text = dt.Rows[2]["colorFamily"].ToString();
                        carparts_search_dashboard.cpconditionLabel3.Text = dt.Rows[2]["condition"].ToString();
                        carparts_search_dashboard.cpyearLabel3.Text = dt.Rows[2]["year"].ToString();
                        carparts_search_dashboard.cpinstallmentLabel3.Text = dt.Rows[2]["installment"].ToString();
                        carparts_search_dashboard.cpunitpriceLabel3.Text = dt.Rows[2]["unitprice"].ToString();



                        if (dt.Rows.Count > 3)
                        {
                            carparts_search_dashboard.cpmodelLabel4.Text = dt.Rows[3]["modelName"].ToString();
                            carparts_search_dashboard.cpbrandLabel4.Text = dt.Rows[3]["brandName"].ToString();
                            carparts_search_dashboard.cpnameLabel4.Text = dt.Rows[3]["partName"].ToString();
                            carparts_search_dashboard.cpstockLabel4.Text = dt.Rows[3]["stock"].ToString();
                            carparts_search_dashboard.cpwarranrtyLabel4.Text = dt.Rows[3]["warranty"].ToString();
                            carparts_search_dashboard.cpcolorLabel4.Text = dt.Rows[3]["colorFamily"].ToString();
                            carparts_search_dashboard.cpconditionLabel4.Text = dt.Rows[3]["condition"].ToString();
                            carparts_search_dashboard.cpyearLabel4.Text = dt.Rows[3]["year"].ToString();
                            carparts_search_dashboard.cpinstallmentLabel4.Text = dt.Rows[3]["installment"].ToString();
                            carparts_search_dashboard.cpunitpriceLabel4.Text = dt.Rows[3]["unitprice"].ToString();

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
