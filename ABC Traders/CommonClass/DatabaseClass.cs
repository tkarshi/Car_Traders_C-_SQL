using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ABC_Traders.CommonClass
{
    //enum function contained different database operations
    enum functionType
    {
        insert,  //save the data in database table
        update,  //update the existing records in the database table
        delete,  //removed the records from the database table
        selectScalar //reterived signle value from database 
    }

    internal class DatabaseClass //The current class
    {
        //SQL Connection String
        private static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FOM4FAB\MSSQLSERVER01;Initial Catalog=ABC_DB;Integrated Security=True;");

        //checks whether a user with a given username and password is valid by looking into two different tables: the Admin table and the Customer table.
        //The method returns a tuple indicating whether the user is valid (isValidUser) and the role of the user (role). 
        public static (bool isValidUser, string role) CheckUserInTable(string username, string password)
        {

            bool isValidUser = false;
            string user_role = null;

            // Check in the Admin table
            if (CheckUserInAdminTable(username, password))
            {
                isValidUser = true;
                user_role = "admin";
            }
            // Check in the Customer table
            else if (CheckUserInCustomerTable(username, password))
            {
                isValidUser = true;
                user_role = "customer";
            }

            return (isValidUser, user_role);
        }
        private static bool CheckUserInAdminTable(string username, string password)
        {
                //The method defines a SQL query to count the number of rows in the "Admin_Detail" table where the given username and password match.
                string query = "SELECT COUNT(*) FROM Admin_Detail WHERE username = @Username AND password = @Password";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con)) //The method uses a SqlCommand object to execute the SQL query.
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar()); //The ExecuteScalar method is used to execute the query
                                                                      //and retrieve a single value (the count) from the result.
                    return (count > 0);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                // Ensure that the connection is closed, even if an exception occurs
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
        private static bool CheckUserInCustomerTable(string username, string password)
        {
            //The method defines a SQL query to count the number of rows in the "Customer" table where the given username and password match.
            string query = "SELECT COUNT(*) FROM Customer WHERE username = @Username AND password = @Password";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con)) ////The method uses a SqlCommand object to execute the SQL query.
                {
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);


                        con.Open();

                        int count = Convert.ToInt32(cmd.ExecuteScalar()); //The ExecuteScalar method is used to execute the query
                                                                          //and retrieve a single value (the count) from the result.
                        return (count > 0);


                    }
                }
            }
            catch (Exception ex) 
            { 
                return false; 
            }
            finally
            {
                // Ensure that the connection is closed, even if an exception occurs
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

 
        public static bool executeQuery(String sql, functionType _funType)
        {
            bool functionRunStatus = false;
            String viewMessage = "";
            bool functionStatus = false;

            try
            {
                if (_funType == functionType.insert)
                {
                    if (MessageBox.Show("Do you want to insert?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        functionRunStatus = true;
                        viewMessage = "Saved Successfully";
                    }
                }
                else if (_funType == functionType.update)
                {
                    if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        functionRunStatus = true;
                        viewMessage = "Updated Successfully";
                    }
                }
                else if (_funType == functionType.delete)
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        functionRunStatus = true;
                        viewMessage = "Deleted Successfully";
                    }
                }

                if (functionRunStatus)
                {

                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();

                        int rowsCount = cmd.ExecuteNonQuery();

                        if (rowsCount > 0)
                        {
                            functionStatus = true;
                        }
                        else
                        {
                            MessageBox.Show("Data not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
            finally
            {
                con.Close();
            }

            return functionStatus;
        }

        public static DataTable getDataFromDatabase(String sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void LoadforeignkeyInComboBox(string sql, ComboBox comboBox, String CarType_ColumnId, String CarType_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = CarType_ColumnId;
            comboBox.ValueMember = CarType_ColumnId;
        }

        public static void CarPartsLoadInComboBox(string sql, ComboBox comboBox, String CarParts_ColumnId, String CarParts_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = CarParts_ColumnId;
            comboBox.ValueMember = CarParts_ColumnId;
        }

        public static void LoadDataFromDatabaseInGridView(String sql, DataGridView _loadTableFun)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _loadTableFun.DataSource = dt;

        }
        public static void PaymentMethodLoad(string sql, ComboBox comboBox, String PayMethod_ColumnId, String PayMethod_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = PayMethod_ColumnId;
            comboBox.ValueMember = PayMethod_ColumnId;
        }
        public static void GyearTypeLoad(string sql, ComboBox comboBox, String GyearType_ColumnId, String GyearType_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = GyearType_ColumnId;
            comboBox.ValueMember = GyearType_ColumnId;
        }
        public static void FuelTypeLoad(string sql, ComboBox comboBox, String FuelType_ColumnId, String FuelType_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = FuelType_ColumnId;
            comboBox.ValueMember = FuelType_ColumnId;
        }

        public static void BrandLoad(string sql, ComboBox comboBox, String Brand_ColumnId, String Brand_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = Brand_ColumnId;
            comboBox.ValueMember = Brand_ColumnId;
        }

        public static void ModelLoad(string sql, ComboBox comboBox, String Model_ColumnId, String Model_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = Model_ColumnId;
            comboBox.ValueMember = Model_ColumnId;
        }

        public static void ConditionLoad(string sql, ComboBox comboBox, String Condition_ColumnId, String Condition_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = Condition_ColumnId;
            comboBox.ValueMember = Condition_ColumnId;
        }

        public static void OrderStatusLoad(string sql, ComboBox comboBox, String OrderStatus_ColumnId, String OrderStatus_ColumnName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.DisplayMember = OrderStatus_ColumnId;
            comboBox.ValueMember = OrderStatus_ColumnId;
        }




    }
}


