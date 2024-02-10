using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sports_club_magement_system
{
    public partial class Events : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds = new DataSet();
        public Events()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Events_Load(object sender, EventArgs e)
        {
            con.ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS.db;Integrated Security=True");
            SelectData();
        }
         private void SelectData()
        {
            cmd = new SqlCommand("SELECT * FROM Events", con);
            
            ds.Clear();
            da = new SqlDataAdapter(cmd);
            con.Close();
            
            dgvEvents.DataSource = ds.Tables["Events"]; ;
        }
        private void InsertData()
        {
            try
            {
                string query = @"INSERT INTO Events ( EventId, EventName, SportId, Venue, StartDate, EndDate) 
                VALUES (@EventId, @EventName, @SportId, @Venue, @StartDate, @EndDate)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@EventId", tbEventId.Text);
                command.Parameters.AddWithValue("@EventName", tbEventName.Text);
                command.Parameters.AddWithValue("@SportId", tbSportId.Text);
                command.Parameters.AddWithValue("@Venue", tbVenue.Text);
                command.Parameters.AddWithValue("@StartDate", dtStartDate.Text);
                command.Parameters.AddWithValue("@EndDate", dtEndDate.Text);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Saved Successfully ");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void DeleteData()
        {
            try
            {
                string query = @"DELETE FROM Events 
                WHERE EventId=@EventId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@EventId", tbEventId.Text);
                command.Parameters.AddWithValue("@EventName", tbEventName.Text);
                command.Parameters.AddWithValue("@SportId", tbSportId.Text);
                command.Parameters.AddWithValue("@Venue", tbVenue.Text);
                command.Parameters.AddWithValue("@StartDate", dtStartDate.Text);
                command.Parameters.AddWithValue("@EndDate", dtEndDate.Text);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Event Deleted Successfully ");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void UpdateData()
        {
            try
            {
                string query = @"UPDATE Events SET EventName=@EventName, SportId=@SportId, Venue=@venue, StartDate=@startDate,
                EndDate=@EndDate WHERE EventId=@EventId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@EventId", tbEventId.Text);
                command.Parameters.AddWithValue("@EventName", tbEventName.Text);
                command.Parameters.AddWithValue("@SportId", tbSportId.Text);
                command.Parameters.AddWithValue("@Venue", tbVenue.Text);
                command.Parameters.AddWithValue("@StartDate", dtStartDate.Text);
                command.Parameters.AddWithValue("@EndDate", dtEndDate.Text);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Event Updated Successfully ");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            tbEventId.Text = "";
            tbEventName.Text = "";
            tbSportId.Text = "";
            tbVenue.Text = "";
            dtStartDate.Text = "";
            dtEndDate.Text = "";
            tbEventId.Focus();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            UpdateData();
            SelectData();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DeleteData();
            SelectData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            InsertData();
            SelectData();
        }
    }
}
