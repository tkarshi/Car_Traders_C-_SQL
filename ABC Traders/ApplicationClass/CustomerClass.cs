using ABC_Traders.CommonClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ABC_Traders.ApplicationClass
{
    internal class CustomerClass : DatabaseClass
    {
        public int customer_id { get; set; }
        public static String name { get; set; }
        public static String email { get; set; }
        public static String address { get; set; }
        public static String username { get; set; }
        public static String password { get; set; }
        public static int admin_id_fk { get; set; }
        public static string user_role { get; set; }

        public static int customer_id_fk { get; set; }
        public static int contactNo1 { get; set; }
        public static int contactNo2 { get; set; }
        public static int emergencyNo { get; set; }


        public static void Save()
        {
            //empty data validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
            { 
                MessageBox.Show("Invalid Data. Please provide required details. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string user_role = "customer";
                //Insert in the Customer Table
                String customer_registration = "INSERT INTO Customer VALUES('" + name + "','" + address + "','" + email + "','" + username + "','" + password + "','" + user_role + "','" + admin_id_fk + "')";

                if (executeQuery(customer_registration, functionType.insert))
                {

                    String customer_reterived_id = "Select customer_id From Customer Where email ='" + email + "'"; //reterived the new records entered customer id

                    DataTable dt = getDataFromDatabase(customer_reterived_id);

                    if (dt.Rows.Count > 0)
                    {
                        customer_reterived_id = dt.Rows[0]["customer_id"].ToString();

                        int.Parse(customer_reterived_id);
                        //Insert the provided contact details in the contact table with customer_id
                        string contact_details = "INSERT INTO Contact_Detail VALUES('" + contactNo1 + "','" + contactNo2 + "','" + emergencyNo + "','" + customer_reterived_id + "')";

                        if (executeQuery(contact_details, functionType.insert))
                        {
                            MessageBox.Show($"{name}Successfully Registered", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information); //Registered Successful Message
                        }
                        else
                        {
                            MessageBox.Show("Error saving contact details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  //Failed to store the contact numbers in the contact table
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error getting customer id details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Customer Details", "Warning Message", MessageBoxButtons.OK); //The failed to record customer details message will display 
                }
            }
        }


        private static int GetGeneratedCustomerId(string name, string address, string email, string username, string password, string user_role, int admin_id_fk)
        {
            string query = $"INSERT INTO Customer OUTPUT INSERTED.customer_id VALUES('{name}', '{address}', '{email}', '{username}', '{password}', '{user_role}', '{admin_id_fk}');";

            // ExecuteScalar returns the first column of the first row

            object result = executeQuery(query, functionType.selectScalar);

            if (result != null)
            {
                if (int.TryParse(result.ToString(), out int customer_id))
                {
                    return customer_id;
                }
                else
                {
                    // Handle the case where customer_id is not an integer
                    return -1; // or throw an exception
                }
            }
            else
            {
                // Handle the case where customer_id retrieval fails
                return -1; // or throw an exception
            }
        }


    }


}

     

