using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sports_club_magement_system
{
    public class Connection
    {
        public SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\sports club magement system\sports club magement system\SCMS.mdf;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public SqlDataReader dr;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da = new SqlDataAdapter();

    }
}
