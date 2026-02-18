using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIU_E1_204
{
    internal class classsDB
    {
        public static SqlConnection conn = new SqlConnection();
        public static void clearTextBox(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = "";
                }
            }
        }


    }
}
 