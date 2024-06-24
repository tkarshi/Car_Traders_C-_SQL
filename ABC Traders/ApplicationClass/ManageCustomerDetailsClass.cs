using ABC_Traders.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ABC_Traders.ApplicationClass
{
    internal class ManageCustomerDetailsClass:DatabaseClass
    {

        public static DataGridView dataGridView;

        public static int customer_id { get; set; }
        public static String name { get; set; }
        public static String email { get; set; }
        public static String address { get; set; }
        public static String username { get; set; }
        public static String password { get; set; }
        public static int admin_id_fk { get; set; }
        public static string user_role { get; set; }

        public static int customer_reterived_id { get; set; }

        public static int customer_id_fk { get; set; }
        public static int contactNo1 { get; set; }
        public static int contactNo2 { get; set; }
        public static int emergencyNo { get; set; }

        public static void Save()
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Invalid Data. Please provide required details. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {


                string user_role = "customer";

                String customer_registration = "INSERT INTO Customer VALUES('" + name + "','" + address + "','" + email + "','" + username + "','" + password + "','" + user_role + "','" + admin_id_fk + "')";

                if (executeQuery(customer_registration, functionType.insert))
                {
                    //int customer_id_retrieved = GetGeneratedCustomerId(name,email,address,username,password,user_role,admin_id_fk);
                    String customer_reterived_id = "Select customer_id From Customer Where email ='" + email + "'";

                    DataTable dt = getDataFromDatabase(customer_reterived_id);

                    if (dt.Rows.Count > 0)
                    {
                        customer_reterived_id = dt.Rows[0]["customer_id"].ToString();

                        int.Parse(customer_reterived_id);

                        string contact_details = "INSERT INTO Contact_Detail VALUES('" + contactNo1 + "','" + contactNo2 + "','" + emergencyNo + "','" + customer_reterived_id + "')";

                        if (executeQuery(contact_details, functionType.insert))
                        {
                            MessageBox.Show($"{name}Successfully Registered", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error saving contact details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error getting customer id details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Customer Details", "Warning Message", MessageBoxButtons.OK);
                }

            }
        }



        public static void view()
        {
            string sql = "Select customer_id, name, address, email, username, password, contactNo1, contactNo2, emergencyNo, customer_id_fk,contact_id  from Contact_Detail CD Join Customer C on CD.customer_id_fk = C.customer_id ";
            
            LoadDataFromDatabaseInGridView(sql, dataGridView);
        }

        public static void Delete(int customer_id)
        {
            //The sql query of the Delete the record of the Customer Table 
            String customer_Delete = "DELETE From Customer WHERE customer_id = '" + customer_id+ "'";

            if (executeQuery(customer_Delete, functionType.delete)) //The executeQuery will execute and the delete enum function
                                                                    //type will execute
            {

                MessageBox.Show($"{name} Successfully Deleted Records", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                view();
               
            }

                else
                {
                    MessageBox.Show("Data Delete Selection is cancelled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        public static void Update(manageCustomerDetails customer_search, int customer_id)
        {
            //In the textbox entered values store in the variables
            String name = customer_search.nametextBox.Text;
            String email = customer_search.emailtextBox.Text;
            String username = customer_search.usernametextBox.Text;
            String password = customer_search.passwordtextBox.Text;
            int contactNo1 = int.Parse(customer_search.contNo1textBox.Text);
            int contactNo2 = int.Parse(customer_search.contNo2textBox.Text);
            int emergencyNo = int.Parse(customer_search.emergtextBox.Text);

            //customer table update query
            String customer_update = "UPDATE Customer SET  name = '" + name + "', address = '" + address + "', email = '" + email + "', username = '" + username + "', password = '" + password + "' WHERE customer_id = '" + customer_id + "'";

            //executing the database class executequery which is having sql connection
            //and the enum function
            if (executeQuery(customer_update, functionType.update))
            {
                    //contact details update query
                    string contact_details = "UPDATE Contact_Detail SET  contactNo1 = '" + contactNo1 + "', contactNo2 = '" + contactNo2 + "', emergencyNo = '" + emergencyNo + "' WHERE customer_id_fk = '" + customer_id + "'";

                //executing the database class executequery which is having sql connection
                //and the enum function
                if (executeQuery(contact_details, functionType.update))
                {
                        //updated message
                        MessageBox.Show($"{name}Successfully Updated", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                        //failed to update contact table message
                        MessageBox.Show("Error saving contact details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //the view table with last update values
                view();
            }
            else
            {
                //the update failed message 
                MessageBox.Show("Invalid Customer Details", "Warning Message", MessageBoxButtons.OK);
            }
        }



        public static void search(manageCustomerDetails customer_search, int customer_id)
        {
            string sql = "Select*from Contact_Detail CD Join Customer C on CD.customer_id_fk = C.customer_id where customer_id = '" + customer_id + "'";

            DataTable dt = getDataFromDatabase(sql);

            if (dt.Rows.Count > 0)
            {
                customer_search.nametextBox.Text = dt.Rows[0]["name"].ToString();
                customer_search.addresstextBox.Text = dt.Rows[0]["address"].ToString();
                customer_search.emailtextBox.Text = dt.Rows[0]["email"].ToString();
                customer_search.contNo1textBox.Text = dt.Rows[0]["contactNo1"].ToString();
                customer_search.contNo2textBox.Text = dt.Rows[0]["contactNo2"].ToString();
                customer_search.emergtextBox.Text = dt.Rows[0]["emergencyNo"].ToString();
                customer_search.usernametextBox.Text = dt.Rows[0]["username"].ToString();
                customer_search.passwordtextBox.Text = dt.Rows[0]["password"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Warning Message", MessageBoxButtons.OK);
            }

        }

        public static void clearTextBox(manageCustomerDetails customer_search)
        {
            if (MessageBox.Show("Do you want to clear the text in text boxes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                customer_search.nametextBox.Clear();
                customer_search.emailtextBox.Clear();
                customer_search.usernametextBox.Clear();
                customer_search.passwordtextBox.Clear();
                customer_search.addresstextBox.Clear();
                customer_search.contNo1textBox.Clear();
                customer_search.contNo2textBox.Clear();
                customer_search.emergtextBox.Clear();

            }
            else
            {

            }
        }



    }
}
