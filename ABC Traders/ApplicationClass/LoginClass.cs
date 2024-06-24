using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABC_Traders.CommonClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ABC_Traders.ApplicationClass
{
    internal class LoginClass:DatabaseClass
    {
        public static String username;
        public static String password;
        public static int customerID;

        public static event Action<string> LoginSuccessful; //represents a method taking a single parameter of type string and
                                                            //returning void. In this context, it indicates that subscribers to the LoginSuccessful
                                                            //event should be methods that take a string parameter.
        public static void PerformLogin(string username, string password)
        {
            (bool isValidUser, string user_role) = CheckUserInTable(username, password);

            if (isValidUser)
            {
                MessageBox.Show($"{user_role} Welcome To ABC Tradors!","Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginSuccessful?.Invoke(user_role);


            }
            else
            {
                MessageBox.Show("Invalid username or password", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
        }

    }

}



