using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Data.SqlClient;

namespace BloodDonationCampainApp
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=CTRLSOFT-31062F;Initial Catalog=BloodDonationForum;Integrated Security=True");
        SqlDataAdapter adapt;
        public static string UserName;
        public static string Password;
        public Form1()
        {
            InitializeComponent();
        }

        private void signUpLink_Click(object sender, EventArgs e)
        {
            RegisterUser register = new RegisterUser();
            this.Hide();
            register.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            UserName = usernameTextBox.Text;
            Password = passwordTextBox.Text;

            if(usernameTextBox.Text==""&& passwordTextBox.Text=="")
            {
                MetroMessageBox.Show(this, "Please Provide Username and Password");
                return;

            }
            else if (usernameTextBox.Text == "" && passwordTextBox.Text != "")
            {
                MetroMessageBox.Show(this, "Please Provide UserName");
                return;

            }

            else if (usernameTextBox.Text != "" && passwordTextBox.Text == "")
            {
                MetroMessageBox.Show(this, "Please Provide Password");
                return;

            }

            else
            {
                con.Open();
                adapt = new SqlDataAdapter("SELECT * FROM [User] WHERE UserName='"+usernameTextBox.Text+"'and Password='"+passwordTextBox.Text+"' " ,con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                int count = dt.Rows.Count;
                con.Close();
                if(count>0)
                {
                    MetroMessageBox.Show(this, "Login Successful");
                    HomePage home = new HomePage();
                     
                    this.Hide();
                    home.Show();
                }
                else
                {
                    MetroMessageBox.Show(this, "Login Failed");
                    return;
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
