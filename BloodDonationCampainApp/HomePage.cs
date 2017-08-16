using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Data.SqlClient;


namespace BloodDonationCampainApp
{
    public partial class HomePage : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=CTRLSOFT-31062F;Initial Catalog=BloodDonationForum;Integrated Security=True");

        public string UserName;
        public string Password;

        public HomePage()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void bloodRequestTile_Click(object sender, EventArgs e)
        {

        }

        private void sendTile_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

            UserName = Form1.UserName;
            Password = Form1.Password;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName,Address,Phone,Age,Gender,BloodGroup FROM [User] WHERE UserName='"+UserName+"' and Password='"+Password+"' ",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader.HasRows)
                {
                    nameLabel.ForeColor = Color.GreenYellow;
                    addressLabel.ForeColor = Color.GreenYellow;
                    phoneLabel.ForeColor = Color.GreenYellow;
                    ageLabel.ForeColor = Color.GreenYellow;
                    genderLabel.ForeColor = Color.GreenYellow;
                    bloodGroupLabel.ForeColor = Color.GreenYellow;

                    nameLabel.Visible = true;
                    addressLabel.Visible = true;
                    phoneLabel.Visible = true;
                    ageLabel.Visible = true;
                    genderLabel.Visible = true;
                    bloodGroupLabel.Visible = true;

                    

                    nameLabel.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    addressLabel.Text = reader["Address"].ToString();
                    phoneLabel.Text ="0"+ reader["Phone"].ToString();
                    ageLabel.Text = reader["Age"].ToString();
                    genderLabel.Text = reader["Gender"].ToString();
                    bloodGroupLabel.Text = reader["BloodGroup"].ToString();
                }
            }
            
            con.Close();
        }
    }
}
