using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ABC_Traders.ApplicationClass
{
    internal class AdminClass:DatabaseClass
    {
        public static DataGridView dataGridView;

        public static void view()
        {

            string sql = "Select orderStatus, name, address, email, modelName, typeName, brandName, quanitity, totalAmount, discount, carorder_id  from  Car_Order CO Join Customer C on CO.customer_id_fk = C.customer_id Join Car_Order_Detail COD on COD.carOrder_id_fk = CO.carorder_id Join Car_Order_Status CS on CO.carOrderStatus_id_fk = CS.carOrderStatus_id Join Car_Detail CD on COD.car_id_fk = CD.car_id Join Model M on CD.model_id_fk = M.model_id Join Brand B on CD.brand_id_fk = B.brand_id Join Car_Type CT on CD.cartype_id_fk = CT.cartype_id";

            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }

        public static void LoadCarTypeDataInChart(adminDashboardLoad admin_dashboard )
        {
            //store the sql queries in the sql variable
            String sql = "Select typeName, SUM(available) as TotalCount from Car_Type group by Car_Type.typeName";
            
            //Reterived Data will adapt as a format in the DataTable
            DataTable dt = getDataFromDatabase(sql);

            //Chart Data Clear because the data is not fixed it will being update
            admin_dashboard.carTypeChart.Series.Clear();

            //create series
            Series series = new Series("Total Count");
            //add the chart type
            series.ChartType = SeriesChartType.Pie;

            //Data which are in the DataTable will bind
            series.Points.DataBind(dt.DefaultView, "typeName", "TotalCount", null);

            admin_dashboard.carTypeChart.Series.Add(series);

            admin_dashboard.carTypeChart.ChartAreas[0].AxisX.Title = "Car Type";
            admin_dashboard.carTypeChart.ChartAreas[0].AxisY.Title = "Total Available";
          
        }

        public static void LoadBrandDataInChart(adminDashboardLoad admin_dashboard)
        {
            //store the sql queries in the sql variable
            String sql = "Select brandName, SUM(available) as TotalCount from Brand group by Brand.brandName";

            //Reterived Data will adapt as a format in the DataTable
            DataTable dt = getDataFromDatabase(sql);

            //Chart Data Clear because the data is not fixed it will being update
            admin_dashboard.brandChart.Series.Clear();

            //create series
            Series series = new Series("Total Count");
            //add the chart type
            series.ChartType = SeriesChartType.Pie;

            //Data which are in the DataTable will bind
            series.Points.DataBind(dt.DefaultView, "brandName", "TotalCount", null);

            admin_dashboard.brandChart.Series.Add(series);

            admin_dashboard.brandChart.ChartAreas[0].AxisX.Title = "Brand";
            admin_dashboard.brandChart.ChartAreas[0].AxisY.Title = "Total Available";

        }

        public static void LoadModelDataInChart(adminDashboardLoad admin_dashboard)
        {
            //store the sql queries in the sql variable
            String sql = "Select model_name, SUM(available) as TotalCount from Model_Edit group by Model_Edit.model_name";

            //Reterived Data will adapt as a format in the DataTable
            DataTable dt = getDataFromDatabase(sql);

            //Chart Data Clear because the data is not fixed it will being update
            admin_dashboard.modelChart.Series.Clear();

            //create series
            Series series = new Series("Total Count");
            //add the chart type
            series.ChartType = SeriesChartType.Pie;

            //Data which are in the DataTable will bind
            series.Points.DataBind(dt.DefaultView, "model_name", "TotalCount", null);

            admin_dashboard.modelChart.Series.Add(series);

            admin_dashboard.modelChart.ChartAreas[0].AxisX.Title = "Model";
            admin_dashboard.modelChart.ChartAreas[0].AxisY.Title = "Total Available";

        }
    }
}
