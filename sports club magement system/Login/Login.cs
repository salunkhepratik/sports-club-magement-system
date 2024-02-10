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

namespace sports_club_magement_system
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\sports club magement system\sports club magement system\SCMS.mdf;Integrated Security=True");



        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String UserId, Password;
            UserId = tbUserName.Text;
            Password = tbPassword.Text;

            if (tbUserName.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Please Enter Valid Username And Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUserName.Focus();
                return;
            }
            try
            {
                String querry = "Select * FROM Login WHERE UserId ='" + tbUserName.Text + "' AND Password='"+ tbPassword.Text +"'  ";
                SqlDataAdapter da = new SqlDataAdapter(querry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                if (dt.Rows.Count>0)
                {
                    UserId = tbUserName.Text;
                    Password = tbPassword.Text;
                   

                    Main_form mainForm = new Main_form();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" invalid user id or Password , please check ");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUserName.Clear();
            tbPassword.Clear();
            tbUserName.Focus();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
