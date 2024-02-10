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
    public partial class Sports : Form
    {
        public Sports()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        public void clear()
        {
            tbSportId.Text = " ";
            tbSportName.Text = " ";
            tbRegFees.Text = "";
            cbCatagory.Text = "";
        }

        public void Showgrid()
        {

            try
            {
                con.cn.Close();
                con.dt.Clear();
                con.cn.Open();
                con.cmd.CommandText = " Select * From Sports";
                con.cmd.Connection = con.cn;
                con.dt.Load(con.cmd.ExecuteReader());
                dgvSports.DataSource = con.dt;
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
     

        private void label2_Click(object sender, EventArgs e)
        {

        }
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                con.cn.Open();
                con.cmd.CommandText = "Select Max(SportId) From Sports";
                con.cmd.Connection = con.cn;
                con.dr = con.cmd.ExecuteReader();
                if (con.dr.Read())
                {
                    str = con.dr[0].ToString();
                    if (str =="")
                    {
                        tbSportId.Text = "1";
                    }
                    else
                    {
                        int k = Convert.ToInt32(con.dr[0].ToString());
                        k = k + 1;
                        tbSportId.Text = k.ToString();
                    }
                    btnSave.Enabled = true;
                    tbSportName.Focus();
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

        private void dgvSport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbSportId.Text = dgvSports.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbSportName.Text = dgvSports.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbCatagory.Text = dgvSports.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbRegFees.Text = dgvSports.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Close();
                con.cn.Open();
                con.cmd.CommandText = "Insert into Sports Values(" + tbSportId.Text + ",'" + tbSportName.Text + "','" + cbCatagory.Text + "','" + tbRegFees.Text + "')";
                con.cmd.Connection = con.cn;
                con.cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved.");
                Showgrid();
                clear();
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
                con.cmd.CommandText = "Update Sports Set SportName = '" + tbSportName.Text + "',Catageory='" + cbCatagory.Text + "',Regfees =" + tbRegFees.Text +" Where SportId = " + tbSportId.Text + "";
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

        private void Sports_Load(object sender, EventArgs e)
        {
            Showgrid();
        }

  

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Delete from Sports Where SportId=" + tbSportId.Text + "";
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

        private void cbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }
