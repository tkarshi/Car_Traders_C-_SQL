using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace ABC_Traders.ApplicationClass
{
    internal class ManageCarDetailClass : DatabaseClass
    {
        public static int car_id { get; set; }
        public static String carNumber { get; set; }
        public static int wheel { get; set; }
        public static string colorFamily { get; set; }
        public static int seat { get; set; }
        public static int babyseat { get; set; }
        public static Boolean wifiAccess { get; set; }
        public static int year { get; set; }
        public static int brand_id_fk { get; set; }
        public static String brandName { get; set; }
        public static int model_id_fk { get; set; }
        public static String modelName { get; set; }
        public static int cartype_id_fk { get; set; }
        public static String typeName { get; set; }
        public static int gyear_id_fk { get; set; }
        public static String gyearType { get; set; }
        public static int condition_id_fk { get; set; }
        public static String condition { get; set; }
        public static int fuel_id_fk { get; set; }
        public static String fuelName { get; set; }
        public static String imageURL { get; set; }

        public static int stock {  get; set; }

        public static int part_id_fk {  get; set; }

        public static int carpart_id {  get; set; }

        public static String warranty {  get; set; }
        public static String installment {  get; set; }

        public static DataGridView dataGridView;

        public static DataGridView dataGridView2;

        public static void Save()
        {

            if (string.IsNullOrEmpty(carNumber) || string.IsNullOrEmpty(Convert.ToString(wheel)) || string.IsNullOrEmpty(colorFamily) || string.IsNullOrEmpty(Convert.ToString(babyseat)) || string.IsNullOrEmpty(Convert.ToString(year)) || string.IsNullOrEmpty(Convert.ToString(brand_id_fk)) || string.IsNullOrEmpty(Convert.ToString(gyear_id_fk)) || string.IsNullOrEmpty(Convert.ToString(condition_id_fk)) || string.IsNullOrEmpty(Convert.ToString(fuel_id_fk)))
            {
                MessageBox.Show("Invalid Data. Please provide required car details. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                String car_detail = "INSERT INTO Car_Detail VALUES('" + carNumber + "','" + wheel + "','" + colorFamily + "','" + seat + "','" + babyseat + "','" + wifiAccess + "','" + year + "','" + brand_id_fk + "','" + model_id_fk + "','" + cartype_id_fk + "','" + gyear_id_fk + "','" + condition_id_fk + "','" + fuel_id_fk + "','" + imageURL + "')";

                if (executeQuery(car_detail, functionType.insert))
                {

                    MessageBox.Show($"{modelName}Successfully Car Records Inserted", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    view(dataGridView);

                }
                else
                {
                    MessageBox.Show("Invalid Car Details", "Warning Message", MessageBoxButtons.OK);
                }
            }
        }

        public static void CarPartSave()
        {
            if (string.IsNullOrEmpty(Convert.ToString(part_id_fk)) || string.IsNullOrEmpty(Convert.ToString(stock)) || string.IsNullOrEmpty(colorFamily) || string.IsNullOrEmpty(warranty) || string.IsNullOrEmpty(Convert.ToString(year)) || string.IsNullOrEmpty(Convert.ToString(brand_id_fk)) || string.IsNullOrEmpty(Convert.ToString(condition_id_fk)))
            {
                MessageBox.Show("Invalid Data. Please provide required car part details. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String car_detail = "INSERT INTO Car_Part_Detail VALUES('" + part_id_fk + "','" + stock + "','" + warranty + "','" + year + "','" + colorFamily + "','" + installment + "','" + brand_id_fk + "','" + model_id_fk + "','" + condition_id_fk + "')";

                if (executeQuery(car_detail, functionType.insert))
                {

                    MessageBox.Show("Successfully Car Parts Records Inserted", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewCarPart(dataGridView);

                }
                else
                {
                    MessageBox.Show("Invalid Car Details", "Warning Message", MessageBoxButtons.OK);
                }
            }
        }

        public static void LoadforeignkeyBrand(ComboBox comboBox)
        {
            String brand = "select * from Brand";
            BrandLoad(brand, comboBox, "brandName", "brand_id");
        }

        public static void LoadforeignkeyModel(ComboBox comboBox)
        {
            String model = "select * from Model";
            ModelLoad(model, comboBox, "modelName", "model_id");
        }

        public static void LoadforeignkeyGyearType(ComboBox comboBox)
        {
            String gyearType = "select * from Gyear_Type";
            GyearTypeLoad(gyearType, comboBox, "gyearType", "gyear_id");
        }

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

        public static void LoadforeignkeyFuelType(ComboBox comboBox)
        {
            String fuel = "select * from Fuel";
            FuelTypeLoad(fuel, comboBox, "fuelName", "fuel_id");
        }

        public static void LoadforeignkeyCondition(ComboBox comboBox)
        {
            String condition = "select * from Condition";
            ConditionLoad(condition, comboBox, "condition", "condition_id");
        }
        public static void view(DataGridView dataGridView)
        {
            string sql = "Select*from Car_Detail CD Join Condition CO on CD.condition_id_fk = CO.condition_id Join Model M on CD.model_id_fk = M.model_id  Join Brand B on CD.brand_id_fk = B.brand_id  Join Gyear_Type GT on CD.gyear_id_fk = GT.gyear_id Join Fuel F on CD.fuel_id_fk = F.fuel_id ";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }

        public static void viewCarPart(DataGridView dataGridView)
        {
            string sql = "Select* from Car_Part_Detail CPD Join CarPart CP on CPD.part_id_fk = CP.part_id Join Model M on CPD.model_id_fk = M.model_id Join Brand B on CPD.brand_id_fk = B.brand_id Join Condition C on CPD.condition_id_fk = C.condition_id";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }

        public static void SearchCar(manageCarParts manage_carparts, int car_id)
        {
            string sql = "Select*from Car_Detail CD Join Condition CO on CD.condition_id_fk = CO.condition_id Join Model M on CD.model_id_fk = M.model_id  Join Brand B on CD.brand_id_fk = B.brand_id  Join Gyear_Type GT on CD.gyear_id_fk = GT.gyear_id Join Fuel F on CD.fuel_id_fk = F.fuel_id Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id where car_id = '" + car_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                manage_carparts.brandComboBox.Text = dt.Rows[0]["brandName"].ToString();
                manage_carparts.modelComboBox.Text = dt.Rows[0]["modelName"].ToString();
                manage_carparts.typeComboBox.Text = dt.Rows[0]["typeName"].ToString();
                manage_carparts.gyearComboBox.Text = dt.Rows[0]["gyearType"].ToString();
                manage_carparts.conditionCombo.Text = dt.Rows[0]["condition"].ToString();
                manage_carparts.babyseatTextBox.Text = dt.Rows[0]["babySeat"].ToString();
                manage_carparts.wifiTextBox.Text = dt.Rows[0]["wifiAccess"].ToString();
                manage_carparts.seatTextBox.Text = dt.Rows[0]["seat"].ToString();
                manage_carparts.wheelTextBox.Text = dt.Rows[0]["wheel"].ToString();
                manage_carparts.yearTextBox.Text = dt.Rows[0]["year"].ToString();
                manage_carparts.colorTextBox.Text = dt.Rows[0]["colorFamily"].ToString();
                manage_carparts.fuelComboBox.Text = dt.Rows[0]["fuelName"].ToString();
                manage_carparts.carNoTextBox.Text = dt.Rows[0]["carNumber"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void SearchCarPart(manageCarParts manage_carparts, int carpart_id)
        {
            string sql = "Select* from Car_Part_Detail CPD Join CarPart CP on CPD.part_id_fk = CP.part_id Join Model M on CPD.model_id_fk = M.model_id Join Brand B on CPD.brand_id_fk = B.brand_id Join Condition C on CPD.condition_id_fk = C.condition_id where carpart_id = '" + carpart_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                manage_carparts.cpbrandCombo.Text = dt.Rows[0]["brandName"].ToString();
                manage_carparts.cpmodelCombo.Text = dt.Rows[0]["modelName"].ToString();
                manage_carparts.cpquantityTextBox.Text = dt.Rows[0]["stock"].ToString();
                manage_carparts.conditionCombo.Text = dt.Rows[0]["condition"].ToString();
                manage_carparts.cpwarrantyTextBox.Text = dt.Rows[0]["warranty"].ToString();
                manage_carparts.cpinstallmentTextBox.Text = dt.Rows[0]["installment"].ToString();
                manage_carparts.cpyearTextBox.Text = dt.Rows[0]["year"].ToString();
                manage_carparts.cpcolorTextBox.Text = dt.Rows[0]["colorFamily"].ToString();

            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void CarUpdate(manageCarParts manage_carparts, int car_id)
        {
            int brand_id_fk = manage_carparts.brandComboBox.SelectedIndex;
            int model_id_fk = manage_carparts.modelComboBox.SelectedIndex;
            int cartype_id_fk = manage_carparts.typeComboBox.SelectedIndex;
            int gyear_id_fk = manage_carparts.gyearComboBox.SelectedIndex;
            int condition_id_fk = manage_carparts.conditionCombo.SelectedIndex;
            int babySeat = int.Parse(manage_carparts.babyseatTextBox.Text);
            Boolean wifiAccess = Convert.ToBoolean(manage_carparts.wifiTextBox.Text);
            int seats = int.Parse(manage_carparts.seatTextBox.Text);
            int wheel = int.Parse(manage_carparts.wheelTextBox.Text);
            int year = int.Parse(manage_carparts.yearTextBox.Text);
            String colorFamily = manage_carparts.colorTextBox.Text;
            int fuel_id_fk = manage_carparts.fuelComboBox.SelectedIndex;
            String carNumber = manage_carparts.carNoTextBox.Text;

            String cardetail_update = "UPDATE Car_Detail SET  brand_id_fk = '" + brand_id_fk + "', model_id_fk = '" + model_id_fk + "', cartype_id_fk = '" + cartype_id_fk + "', gyear_id_fk = '" + gyear_id_fk + "', condition_id_fk = '" + condition_id_fk + "', babySeat = '" + babyseat + "', wifiAccess = '" + wifiAccess + "', seat = '" + seats + "', wheel = '" + wheel + "', year = '" + year + "', colorFamily = '" + colorFamily + "', fuel_id_fk = '" + fuel_id_fk + "', carNumber = '" + carNumber + "' WHERE car_id = '" + car_id + "'";


            if (executeQuery(cardetail_update, functionType.update))
            {
                MessageBox.Show("Successfully Car Records Updated", "Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);

                view(dataGridView);
            }
            else
            {
                //the update failed message 
                MessageBox.Show("Invalid Customer Details", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void CarPartsUpdate(manageCarParts manage_carparts, int carpart_id)
        {
            int brand_id_fk = manage_carparts.cpbrandCombo.SelectedIndex;
            int model_id_fk = manage_carparts.cpmodelCombo.SelectedIndex;
            int condition_id_fk = manage_carparts.cpconditionCombo.SelectedIndex;
            int stock = int.Parse(manage_carparts.cpquantityTextBox.Text);
            int part_id_fk = manage_carparts.carpartsComboBox.SelectedIndex;
            String installment = manage_carparts.cpinstallmentTextBox.Text;
            int year = int.Parse(manage_carparts.cpyearTextBox.Text);
            String colorFamily = manage_carparts.colorTextBox.Text;
            String warranty = manage_carparts.cpwarrantyTextBox.Text;

            String cardetail_update = "UPDATE Car_Part_Detail SET  brand_id_fk = '" + brand_id_fk + "', model_id_fk = '" + model_id_fk + "', part_id_fk = '" + part_id_fk + "', stock = '" + stock + "', condition_id_fk = '" + condition_id_fk + "', warranty = '" + warranty + "', installment = '" + installment + "', colorFamily = '" + colorFamily + "', year = '" + year + "' WHERE carpart_id = '" + carpart_id + "'";


            if (executeQuery(cardetail_update, functionType.update))
            {
                MessageBox.Show("Successfully Car Parts Records Updated", "Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);

                viewCarPart(dataGridView);
            }
            else
            {
                //the update failed message 
                MessageBox.Show("Invalid Customer Details", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void DeleteCar(int car_id)
        {
            //The sql query of the Delete the record of the Customer Table 
            String car_Delete = "DELETE From Car_Detail WHERE car_id = '" + car_id + "'";

            if (executeQuery(car_Delete, functionType.delete)) //The executeQuery will execute and the delete enum function
                                                               //type will execute
            {

                MessageBox.Show("Successfully Deleted Car Records", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                view(dataGridView);

            }

            else
            {
                MessageBox.Show("Data Delete Selection is cancelled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        public static void DeleteCarPart(int carpart_id)
        {
            //The sql query of the Delete the record of the Customer Table 
            String carpart_Delete = "DELETE From Car_Part_Detail WHERE carpart_id = '" + carpart_id + "'";

            if (executeQuery(carpart_Delete, functionType.delete)) //The executeQuery will execute and the delete enum function
                                                               //type will execute
            {

                MessageBox.Show("Successfully Deleted Car Part Records", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewCarPart(dataGridView);

            }

            else
            {
                MessageBox.Show("Data Delete Selection is cancelled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


    }
    }
