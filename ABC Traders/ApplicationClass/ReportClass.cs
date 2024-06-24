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
    internal class ReportClass:DatabaseClass
    {
        public static int car_id {  get; set; }

        public static DataGridView dataGridView;

        public static void view()
        {

            string sql = "Select*from Car_Detail CD Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id Join Model M on CD.model_id_fk = M.model_id Join Gyear_Type GT on CD.gyear_id_fk = GT.gyear_id Join Brand B on CD.brand_id_fk = B.brand_id Join Condition C on CD.condition_id_fk = C.condition_id Join Fuel F on CD.fuel_id_fk = F.fuel_id Join Car_Order_Detail COD on COD.car_id_fk = CD.car_id Where car_id = '" + car_id + "'";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }

        public static void view1()
        {

            string sql = "Select*from Car_Detail CD Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id Join Model M on CD.model_id_fk = M.model_id Join Gyear_Type GT on CD.gyear_id_fk = GT.gyear_id Join Brand B on CD.brand_id_fk = B.brand_id Join Condition C on CD.condition_id_fk = C.condition_id Join Fuel F on CD.fuel_id_fk = F.fuel_id Join Car_Order_Detail COD on COD.car_id_fk = CD.car_id ";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }
        public static void DisplayModel(inventoryReports inventory_report)
        {
            string sql = "Select*from Model";


            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                inventory_report.carModelLabel1.Text = dt.Rows[0]["modelName"].ToString();
                inventory_report.modelCount1.Text = dt.Rows[0]["available"].ToString();

                if (dt.Rows.Count > 1)
                {
                    inventory_report.carModelLabel2.Text = dt.Rows[1]["modelName"].ToString();
                    inventory_report.modelCount2.Text = dt.Rows[1]["available"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        inventory_report.carModelLabel3.Text = dt.Rows[2]["modelName"].ToString();
                        inventory_report.modelCount3.Text = dt.Rows[2]["available"].ToString();

                        if (dt.Rows.Count > 3)
                        {
                            inventory_report.carModelLabel1.Text = dt.Rows[3]["modelName"].ToString();
                            inventory_report.modelCount4.Text = dt.Rows[3]["available"].ToString();

                        }
                    }
                }


            }

            else
            {
                MessageBox.Show("Sorry for dissapoint you! The Car Model is not existing yet", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void DisplayCarType(inventoryReports inventory_report)
        {
            string sql = "Select*from Car_Type";


            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                inventory_report.carType1.Text = dt.Rows[0]["typeName"].ToString();
                inventory_report.typeCount1.Text = dt.Rows[0]["available"].ToString();

                if (dt.Rows.Count > 1)
                {
                    inventory_report.carType2.Text = dt.Rows[1]["typeName"].ToString();
                    inventory_report.typeCount2.Text = dt.Rows[1]["available"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        inventory_report.carType3.Text = dt.Rows[2]["typeName"].ToString();
                        inventory_report.typeCount3.Text = dt.Rows[2]["available"].ToString();

                        if (dt.Rows.Count > 3)
                        {
                            inventory_report.carType4.Text = dt.Rows[3]["typeName"].ToString();
                            inventory_report.typeCount4.Text = dt.Rows[3]["available"].ToString();

                        }
                    }
                }


            }

            else
            {
                MessageBox.Show("Sorry for dissapoint you! The Car Model is not existing yet", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void DisplayBrand(inventoryReports inventory_report)
        {
            string sql = "Select*from Brand";


            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                inventory_report.brand1.Text = dt.Rows[0]["brandName"].ToString();
                inventory_report.brandCount1.Text = dt.Rows[0]["available"].ToString();

                if (dt.Rows.Count > 1)
                {
                    inventory_report.brand2.Text = dt.Rows[1]["brandName"].ToString();
                    inventory_report.brandCount2.Text = dt.Rows[1]["available"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        inventory_report.brand3.Text = dt.Rows[2]["brandName"].ToString();
                        inventory_report.brandCount3.Text = dt.Rows[2]["available"].ToString();

                        if (dt.Rows.Count > 3)
                        {
                            inventory_report.brand4.Text = dt.Rows[3]["brandName"].ToString();
                            inventory_report.brandCount4.Text = dt.Rows[3]["available"].ToString();

                        }
                    }
                }


            }

            else
            {
                MessageBox.Show("Sorry for dissapoint you! The Car Model is not existing yet", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void DisplayCarPartType(inventoryReports inventory_report)
        {
            string sql = "Select partName, stock from Car_Part_Detail CPD Join CarPart CP on CPD.part_id_fk = CP.part_id";


            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                inventory_report.partType1.Text = dt.Rows[0]["partName"].ToString();
                inventory_report.cpModelCount1.Text = dt.Rows[0]["stock"].ToString();

                if (dt.Rows.Count > 1)
                {
                    inventory_report.partType2.Text = dt.Rows[1]["partName"].ToString();
                    inventory_report.cpModelCount2.Text = dt.Rows[1]["stock"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        inventory_report.partType3.Text = dt.Rows[2]["partName"].ToString();
                        inventory_report.cpModelCount3.Text = dt.Rows[2]["stock"].ToString();

                        if (dt.Rows.Count > 3)
                        {
                            inventory_report.partType4.Text = dt.Rows[3]["partName"].ToString();
                            inventory_report.cpModelCount4.Text = dt.Rows[3]["stock"].ToString();

                        }
                    }
                }


            }

            else
            {
                MessageBox.Show("Sorry for dissapoint you! The Car Model is not existing yet", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void DisplayCarPartStock(inventoryReports inventory_report)
        {
            string sql = "Select partName, modelName, available from Car_Part_Detail CPD Join CarPart CP on CPD.part_id_fk = CP.part_id Join Model M on CPD.model_id_fk = M.model_id";


            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                inventory_report.partName1.Text = dt.Rows[0]["partName"].ToString();
                inventory_report.modelName1.Text = dt.Rows[0]["modelName"].ToString();
                inventory_report.count1.Text = dt.Rows[0]["available"].ToString();

                if (dt.Rows.Count > 1)
                {
                    inventory_report.partName2.Text = dt.Rows[1]["partName"].ToString();
                    inventory_report.modelName2.Text = dt.Rows[1]["modelName"].ToString();
                    inventory_report.count2.Text = dt.Rows[1]["available"].ToString();

                    if (dt.Rows.Count > 2)
                    {
                        inventory_report.partName3.Text = dt.Rows[2]["partName"].ToString();
                        inventory_report.modelName3.Text = dt.Rows[2]["modelName"].ToString();
                        inventory_report.count3.Text = dt.Rows[2]["available"].ToString();

                        if (dt.Rows.Count > 3)
                        {
                            inventory_report.partName4.Text = dt.Rows[3]["partName"].ToString();
                            inventory_report.modelName4.Text = dt.Rows[3]["modelName"].ToString();
                            inventory_report.count4.Text = dt.Rows[3]["available"].ToString();

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
