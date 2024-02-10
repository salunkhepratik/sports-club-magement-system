using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sports_club_magement_system
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void main_form_Load(object sender, EventArgs e)
        {

        }

        internal void DisplayForm()
        {
            throw new NotImplementedException();
        }
         

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void utilitesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Sports_Click(object sender, EventArgs e)
        {
            try
            {
                Sports sp = new Sports();
                sp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Coches_Click(object sender, EventArgs e)
        {
            try
            {
                Coach co = new Coach();
                co.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Players_Click(object sender, EventArgs e)
        {
            try
            {
                Players pl = new Players();
                pl.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Equipments_Click(object sender, EventArgs e)
        {
            try
            {
                Equipments eq = new Equipments();
                eq.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Salary_Click(object sender, EventArgs e)
        {
            try
            {
                Salary sl = new Salary();
                sl.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Fees_Click(object sender, EventArgs e)
        {
            try
            {
                Fees fe = new Fees();
                fe.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            try
            {
                Schedule sc = new Schedule();
                sc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Events_Click(object sender, EventArgs e)
        {
            try
            {
                Events ev = new Events();
                ev.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Event_Allotment_Click(object sender, EventArgs e)
        {
            try
            {
                EventAllotment ea = new EventAllotment();
                ea.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Team_Allotment_Click(object sender, EventArgs e)
        {
            try
            {
                TeamAllotment ta = new TeamAllotment();
                ta.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Prize_Click(object sender, EventArgs e)
        {
            try
            {
                Prize pr = new Prize();
                pr.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
