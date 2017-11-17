using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_BD
{
    public sealed class Connection
    {
        public static readonly Connection connection = new Connection();
        public static SqlConnection sqlconnect;

        private Connection()
        {
            try
            {
                String chaine = "data source=.\\SQLEXPRESS; Initial Catalog = finaltest; Integrated Security=True; ";
                sqlconnect = new SqlConnection(chaine);
                sqlconnect.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
