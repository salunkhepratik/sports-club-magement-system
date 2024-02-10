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
    public partial class EventAllotment : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds = new DataSet();
        public EventAllotment()
        {
            InitializeComponent();
        }

        private void EventAllotment_Load(object sender, EventArgs e)
        {
            con.ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMdb;Integrated Security=True");
            SelectData();
        }

        private void SelectData()
        {
            cmd = new SqlCommand("SELECT * FROM EventAllotment", con);
            
            ds.Clear();
            da = new SqlDataAdapter(cmd);
            con.Close();
            
            dgvEventAllotment.DataSource = ds.Tables["EventAllotment"];
        }
        private void InsertData()
        {
            try
            {
                string query = @"INSERT INTO EventAllotment ( TeamId, EventId, SportId, PlayerId ) 
                VALUES (  @TeamId, @EventId, @SportId, @PlayerId )";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@TeamId", tbTeamId.Text);
                command.Parameters.AddWithValue("@EventId", tbEventId.Text);
                command.Parameters.AddWithValue("@SportId", tbSportId.Text);
                command.Parameters.AddWithValue("@PlayerId", tbPlayerId.Text);
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
                string query = @"DELETE FROM EventAllotment 
                WHERE TeamId=@TeamId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@TeamId", tbTeamId.Text);
                command.Parameters.AddWithValue("@EventId", tbEventId.Text);
                command.Parameters.AddWithValue("@SportId", tbSportId.Text);
                command.Parameters.AddWithValue("@PlayerId", tbPlayerId.Text);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Allotment Deleted Successfully ");
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
                string query = @"UPDATE EventAllotment SET EventId=@EventId, SportId=@SportId, PlayerId=@PlayerId, WHERE TeamId=@TeamId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@TeamId", tbTeamId.Text);
                command.Parameters.AddWithValue("@EventId", tbEventId.Text);
                command.Parameters.AddWithValue("@SportId", tbSportId.Text);
                command.Parameters.AddWithValue("@PlayerId", tbPlayerId.Text);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Allotment Updated Successfully ");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbTeamId.Text = "";
            tbEventId.Text = "";
            tbSportId.Text = "";
            tbPlayerId.Text = "";
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            SelectData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            SelectData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertData();
            SelectData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
