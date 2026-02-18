using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIU_E1_204
{
    public partial class main : Form
    {
        private object f;

        public main()
        {
            InitializeComponent();
        }
        private void studentRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent studentForm = new frmStudent();
            studentForm.Show();
        }
    }
}
