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
    public partial class Fees : Form
    {
        Connection con = new Connection();
        public void clear()
        {
            tbPlayerId.Text = " ";
            tbAmount.Text = " ";
            tbStatus.Text = " ";
            dtDate.Text = " ";

        }

        public void Showgrid()
        {

            try
            {
                con.cn.Close();
                con.dt.Clear();
                con.cn.Open();
                con.cmd.CommandText = " Select * From  Fees";
                con.cmd.Connection = con.cn;
                con.dt.Load(con.cmd.ExecuteReader());
                dgvFees.DataSource = con.dt;
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
        public Fees()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fees_Load(object sender, EventArgs e)
        {
            Showgrid();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            clear();
            try
            {
                string str;
                con.cn.Open();
                con.cmd.CommandText = "Select Max(PlayerId) From Fees";
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

        private void dgvFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbPlayerId.Text = dgvFees.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbAmount.Text = dgvFees.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbStatus.Text = dgvFees.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtDate.Text = dgvFees.Rows[e.RowIndex].Cells[3].Value.ToString();
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Insert into Fees Values('" + tbPlayerId.Text + "','" + tbAmount.Text + "','" + tbStatus.Text + "','" + dtDate.Text + "',)";
                con.cmd.Connection = con.cn;
                con.cmd.ExecuteNonQuery();
                clear();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Delete from Fees Where PlayerId=" + tbPlayerId.Text + "";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Update Fees Set Amount='" + tbAmount.Text + "', Status =" + tbStatus.Text + ", Date=" + dtDate.Text + " Where PlayerId = " + tbPlayerId.Text + "";
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
    }

    
    }

