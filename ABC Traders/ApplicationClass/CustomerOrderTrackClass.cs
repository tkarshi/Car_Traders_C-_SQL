using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ABC_Traders.ApplicationClass
{
    internal class CustomerOrderTrackClass:DatabaseClass
    {
        public static int carorder_id { get; set; }

        public static DataGridView dataGridView;
        public static void view()
        {

            string sql = "Select orderStatus, name, address, email, modelName, typeName, brandName, quanitity, totalAmount, discount, carorder_id  from  Car_Order CO Join Customer C on CO.customer_id_fk = C.customer_id Join Car_Order_Detail COD on COD.carOrder_id_fk = CO.carorder_id Join Car_Order_Status CS on CO.carOrderStatus_id_fk = CS.carOrderStatus_id Join Car_Detail CD on COD.car_id_fk = CD.car_id Join Model M on CD.model_id_fk = M.model_id Join Brand B on CD.brand_id_fk = B.brand_id  Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id WHERE carorder_id = '" + carorder_id + "'";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
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
    }
}
