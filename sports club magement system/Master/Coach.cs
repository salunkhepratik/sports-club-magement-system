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
using System.Data.SqlClient;

namespace sports_club_magement_system
{
    public partial class Coach : Form
    {

        Connection con = new Connection();
        public void clear()
        {
            tbCoachId.Text = " ";
            tbCoachName.Text = " ";
            cbDesignation.Text = " ";
            tbContactNo.Text = " ";
        }


        public void Showgrid()
        {

            try
            {
                con.cn.Close();
                con.dt.Clear();
                con.cn.Open();
                con.cmd.CommandText = " Select * From Coach";
                con.cmd.Connection = con.cn;
                con.dt.Load(con.cmd.ExecuteReader());
                dgvCoach.DataSource = con.dt;
                con.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                con.cn.Close();
            }

        }


        public Coach()
        {
           InitializeComponent();
        }


        private void Coach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCMSDataSet.Sports' table. You can move, or remove it, as needed.
            this.sportsTableAdapter.Fill(this.sCMSDataSet.Sports);

            Showgrid();
        }

        private void dgvCoach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbCoachId.Text = dgvCoach.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbCoachName.Text = dgvCoach.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbSportId.Text = dgvCoach.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbDesignation.Text = dgvCoach.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbContactNo.Text = dgvCoach.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbCoachName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            clear();
            try
            {
                string str;
                con.cn.Open();
                con.cmd.CommandText = "Select Max(CoachId) From Coach";
                con.cmd.Connection = con.cn;
                con.dr = con.cmd.ExecuteReader();
                if (con.dr.Read())
                {
                    str = con.dr[0].ToString();
                    if (str == "")
                        tbCoachId.Text = "1";
                    else
                    {
                        int k = Convert.ToInt32(con.dr[0].ToString());
                        k = k + 1;
                        tbCoachId.Text = k.ToString();
                    }
                    btnSave.Enabled = true;
                    tbCoachId.Focus();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.cn.Close();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Insert into Coach Values(" + tbCoachId.Text + ",'" + tbCoachName.Text + "','" + cbSportId.SelectedValue + "','" + cbDesignation.Text + "','" + tbContactNo.Text + "')";
                con.cmd.Connection = con.cn;
                con.cmd.ExecuteNonQuery();
                Showgrid();
                con.cn.Close();

                MessageBox.Show("Data Saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.cn.Close();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Delete from Coach Where CoachId=" + tbCoachId.Text + "";
                con.cmd.Connection = con.cn;
                con.cmd.ExecuteNonQuery();
                con.cn.Close();
                MessageBox.Show("Data Deleted.");
                clear();
                Showgrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.cn.Close();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Update Coach Set CoachName = '" + tbCoachName.Text + "',SportId=" + cbSportId.Text + ",Designation ='" + cbDesignation.Text + "',ContactNo=" + tbContactNo.Text + " Where CoachId = " + tbCoachId.Text + "";
                con.cmd.Connection = con.cn;
                con.cmd.ExecuteNonQuery();
                con.cn.Close();
                MessageBox.Show("Data Updated.");
                clear();
                Showgrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.cn.Close();
            }
        }

        private void cbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
