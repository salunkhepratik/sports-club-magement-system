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
    public partial class Players : Form
    {
        public Players()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        public void clear()
        {
            tbPlayerId.Text = " ";
            tbAddress.Text = " ";
            tbAge.Text = " ";
            tbContactNo.Text = " ";
            tbHeight.Text = " ";
            tbParentGurdianName.Text = " ";
            tbPlayerName.Text = " ";
            tbWeight.Text = " ";
            cbBloodGroup.Text = " ";
            cbSportId.Text = " ";
            cbGender.Text = " ";
        }

        public void Showgrid()
        {

            try
            {
                con.cn.Close();
                con.dt.Clear();
                con.cn.Open();
                con.cmd.CommandText = " Select * From Player";
                con.cmd.Connection = con.cn;
                con.dt.Load(con.cmd.ExecuteReader());
                dgvPlayer.DataSource = con.dt;
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

  
       

      

        private void Players_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCMSDataSet2.Sports' table. You can move, or remove it, as needed.
            this.sportsTableAdapter.Fill(this.sCMSDataSet2.Sports);
            Showgrid();

        }

  

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
            try
            {
                string str;
                con.cn.Open();
                con.cmd.CommandText = "Select Max(PlayerId) From Player";
                con.cmd.Connection = con.cn;
                con.dr = con.cmd.ExecuteReader();
                if (con.dr.Read())
                {
                    str = con.dr[0].ToString();
                    if (str == "")
                        tbPlayerId.Text = "1";
                    else
                    {
                        int k = Convert.ToInt32(con.dr[0].ToString());
                        k = k + 1;
                        tbPlayerId.Text = k.ToString();
                    }
                    btnSave.Enabled = true;
                    tbPlayerId.Focus();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Update Player Set PlayerName = '" + tbPlayerName.Text + "',SportId=" + cbSportId.Text + ",BloodGroup ='" + cbBloodGroup.Text + "',ContactNo=" + tbContactNo.Text + ",Address ='" + tbAddress.Text + "',Age ='" + tbAge.Text + "', Height='" + tbHeight.Text + "', ParentGurdianName='" + tbParentGurdianName.Text + "',Weight='" + tbWeight.Text + "',DOB ='" + dtpDOB.Text + ",RegDate ='" + dtpRegDate.Text + " Where PlayerId = " + tbPlayerId.Text + "";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Delete from Player Where PlayerId=" + tbPlayerId.Text + "";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Insert into Player Values(" + tbPlayerId.Text + ",'" + tbPlayerName.Text + "','" + tbParentGurdianName.Text+ "'," + tbAge.Text + ",'" + dtpDOB.Text +  "','" + cbGender.Text + "','" + tbAddress.Text + "','" + tbHeight.Text+ "','" + tbWeight.Text +  "','" + cbBloodGroup.SelectedValue + "','" + dtpRegDate.Text+ "'," + cbSportId.SelectedValue+ ",'" + tbContactNo.Text + "')";
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

     

        private void dgvPlayer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbPlayerId.Text = dgvPlayer.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbAddress.Text = dgvPlayer.Rows[e.RowIndex].Cells[6].Value.ToString();
             tbAge.Text = dgvPlayer.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbContactNo.Text = dgvPlayer.Rows[e.RowIndex].Cells[12].Value.ToString();
            tbHeight.Text = dgvPlayer.Rows[e.RowIndex].Cells[7].Value.ToString();
            tbParentGurdianName.Text = dgvPlayer.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbPlayerName.Text = dgvPlayer.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbWeight.Text = dgvPlayer.Rows[e.RowIndex].Cells[8].Value.ToString();
            cbBloodGroup.Text = dgvPlayer.Rows[e.RowIndex].Cells[9].Value.ToString();
            cbGender.Text = dgvPlayer.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbSportId.Text = dgvPlayer.Rows[e.RowIndex].Cells[11].Value.ToString();
            dtpDOB.Text = dgvPlayer.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpRegDate.Text = dgvPlayer.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtDOB_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
