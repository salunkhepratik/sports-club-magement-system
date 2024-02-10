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

    public partial class Equipments : Form
    {
        Connection con = new Connection();
        public void clear()
        {
            tbEquipmentId.Text = " ";
            tbAvailable.Text = " ";
            tbDamageQuantity.Text = " ";
            tbEquipmentName.Text = " ";
            tbPurchaseQuantity.Text = " ";
        }



        public void Showgrid()
        {

            try
            {
                con.cn.Close();
                con.dt.Clear();
                con.cn.Open();
                con.cmd.CommandText = " Select * From  Equipments";
                con.cmd.Connection = con.cn;
                con.dt.Load(con.cmd.ExecuteReader());
                dgvEquipment.DataSource = con.dt;
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


        public Equipments()
        {
            InitializeComponent();
        }

        private void Equipments_Load(object sender, EventArgs e)
        {
            Showgrid();

        }
    
      

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Insert into Equipments Values('" + tbEquipmentId.Text + "','" + tbEquipmentName.Text + "','" + tbPurchaseQuantity.Text + "','" + tbDamageQuantity.Text + "','" + tbAvailable.Text + "')";
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            clear();
            try
            {
                string str;
                con.cn.Open();
                con.cmd.CommandText = "Select Max(EquipmentId) From Equipments";
                con.cmd.Connection = con.cn;
                con.dr = con.cmd.ExecuteReader();
                if (con.dr.Read())
                {
                    str = con.dr[0].ToString();
                    if (str == "")
                        tbEquipmentId.Text = "1";
                    else
                    {
                        int k = Convert.ToInt32(con.dr[0].ToString());
                        k = k + 1;
                        tbEquipmentId.Text = k.ToString();
                    }
                    btnSave.Enabled = true;
                    tbEquipmentId.Focus();
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Update Equipments Set EquipmentName = '" + tbEquipmentName.Text + "',Available='" + tbAvailable.Text + "',DamageQuantity =" + tbDamageQuantity.Text + ",PurchaseQuantity=" + tbPurchaseQuantity.Text + " Where EquipmentId = " + tbEquipmentId.Text + "";
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                con.cmd.CommandText = "Delete from Equipments Where EquipmentId=" + tbEquipmentId.Text + "";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvEquipment_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            tbEquipmentId.Text = dgvEquipment.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbEquipmentName.Text = dgvEquipment.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbPurchaseQuantity.Text = dgvEquipment.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbDamageQuantity.Text = dgvEquipment.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbAvailable.Text = dgvEquipment.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
