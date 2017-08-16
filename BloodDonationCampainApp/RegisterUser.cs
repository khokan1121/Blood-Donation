using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework;
namespace BloodDonationCampainApp
{
    public partial class RegisterUser : MetroFramework.Forms.MetroForm
    {

        SqlConnection con = new SqlConnection(@"Data Source=CTRLSOFT-31062F;Initial Catalog=BloodDonationForum;Integrated Security=True");
        SqlDataAdapter adapt;
        DataTable dt;
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            firstnameTextBox.Text = "";
            lastnameTextBox.Text = "";
            addressTextBox.Text = "";
            phoneTextBox.Text = "";
            ageTextBox.Text = "";
            genderComboBox.Text = "";
            bloodGroupComboBox.Text="";
            confirmPasswordTextBox.Text="";
            passwordTextBox.Text = "";
            confirmPasswordTextBox.Enabled = false;
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            qualityLabel.Visible = true;
            passwordQualityLabel.Visible = true;
            if(passwordTextBox.Text=="")
            {
                qualityLabel.Visible = false;
                passwordQualityLabel.Visible = false;
            }
            confirmPasswordTextBox.Enabled = true;
            
            if(passwordTextBox.Text.Length<=5)
            {
                passwordQualityLabel.Text = "Low";
                passwordQualityLabel.ForeColor = Color.Red;
            }
            else if (passwordTextBox.Text.Length > 5 && passwordTextBox.Text.Length <=8)
            {
                passwordQualityLabel.Text = "Medium";
                passwordQualityLabel.ForeColor = Color.Green;
            }

            else if(passwordTextBox.Text.Length>8)
            {
                passwordQualityLabel.Text = "Strong";
                passwordQualityLabel.ForeColor = Color.GreenYellow;
            }
        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            matchPasswordLabel.Visible = true;
            if(confirmPasswordTextBox.Text=="")
            {
                matchPasswordLabel.Visible = false;
            }

            if(passwordTextBox.Text==confirmPasswordTextBox.Text)
            {
               
                matchPasswordLabel.Text = "Match Found";
                matchPasswordLabel.ForeColor = Color.GreenYellow;
            }

            else
            {
                
                matchPasswordLabel.Text = " Not Matched";
                matchPasswordLabel.ForeColor = Color.Red;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(firstnameTextBox.Text=="" || lastnameTextBox.Text==""||addressTextBox.Text=="" || phoneTextBox.Text==""|| ageTextBox.Text==""||genderComboBox.Text==""||bloodGroupComboBox.Text==""||passwordTextBox.Text==""||confirmPasswordTextBox.Text==""|| usernameTextBox.Text=="")
            {
                MetroMessageBox.Show(this, "Please Provide All Details");
                return;
            }
            else
            {
                con.Open();
                string query = "INSERT INTO [User](FirstName,LastName,Address,Gender,Age,Phone,BloodGroup,Password,UserName)VALUES(@firstname,@lastname,@address,@gender,@age,@phone,@bloodgroup,@password,@username)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@firstname",firstnameTextBox.Text);
                cmd.Parameters.AddWithValue("@lastname", lastnameTextBox.Text);
                cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                cmd.Parameters.AddWithValue("@gender", genderComboBox.Text);
                cmd.Parameters.AddWithValue("@age", ageTextBox.Text);
                cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                cmd.Parameters.AddWithValue("@bloodgroup", bloodGroupComboBox.Text);
                cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                int count = cmd.ExecuteNonQuery();
                con.Close();
                if(count>0)
                {
                    
                    MetroMessageBox.Show(this, "You are registerd Successfully");
                    Form1 login = new Form1();
                    this.Hide();
                    login.Show();

                }
                else
                {
                    MetroMessageBox.Show(this, "Registration Failed");
                    return;
                }
                
            }
        }
    }
}
