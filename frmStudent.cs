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
    public partial class frmStudent : Form
    {
        private object clsssDB;

        public frmStudent()
        {
            classsDB.conn.ConnectionString = @"Data Source = localhost;
                                               Database = SchoolDBE1;
                                               User ID = sa;
                                               Password = 0000;";                                               
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               classsDB.conn.Open();
               classStudent student = new classStudent();
               dataGridView_Student.DataSource = student.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection fail");
            }          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView_Student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            classStudent student = new classStudent();
            student.StudentID = int.Parse(txtstudentID.Text);
            student.FirstName = txtFirstname.Text;
            student.LastName = txtLastname.Text;
            student.Email = txtEmail.Text;
            student.PhoneNumber = txtPhoneNumber.Text;
            student.Gender = cboGender.Text;
            student.DateOfBirth = dtpDob.Value;
            student.GuardianName = txtGuardianName.Text;
            student.GuardianContact = txtGuardianContact.Text;
            student.Address = txtPOB.Text;

            if (student.UpdateData())
            {
                dataGridView_Student.DataSource = student.GetData();
                MessageBox.Show("Update Success");
            }
            else
            {
                MessageBox.Show("Update fail");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            classStudent student = new classStudent();
            student.FirstName = txtFirstname.Text;
            student.LastName = txtLastname.Text;
            student.Email = txtEmail.Text;
            student.PhoneNumber = txtPhoneNumber.Text;
            student.Gender = cboGender.Text;
            student.DateOfBirth = dtpDob.Value;
            student.GuardianName = txtGuardianName.Text;
            student.GuardianContact = txtGuardianContact.Text;
            student.Address = txtPOB.Text;

            if (student.InsertData())
            {
                dataGridView_Student.DataSource = student.GetData();
                MessageBox.Show("Insert Success");
            }
            else 
            {
                MessageBox.Show("Insert fail");
            }

        }

        private void dataGridView_Student_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Student.CurrentRow == null)
                return;

            txtstudentID.Text = dataGridView_Student.CurrentRow.Cells["StudentID"].Value.ToString();
            txtFirstname.Text = dataGridView_Student.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastname.Text = dataGridView_Student.CurrentRow.Cells["LastName"].Value.ToString();
            txtGuardianName.Text = dataGridView_Student.CurrentRow.Cells["GuardianName"].Value.ToString();
            txtEmail.Text = dataGridView_Student.CurrentRow.Cells["Email"].Value.ToString();
            txtPhoneNumber.Text = dataGridView_Student.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            txtGuardianContact.Text = dataGridView_Student.CurrentRow.Cells["GuardianContact"].Value.ToString();
            txtPOB.Text = dataGridView_Student.CurrentRow.Cells["Address"].Value.ToString();

            // ComboBox
            cboGender.Text = dataGridView_Student.CurrentRow.Cells["Gender"].Value.ToString();

            // DateTimePicker
            dtpDob.Value = Convert.ToDateTime(
                dataGridView_Student.CurrentRow.Cells["DateOfBirth"].Value
            );

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            classStudent student = new classStudent();
            student.StudentID = int.Parse(txtstudentID.Text);
            if (student.Delete())
            {
                dataGridView_Student.DataSource = student.GetData();
                MessageBox.Show("Delete Success");
            }
            else
            {
                MessageBox.Show("Delete fail");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView_Student.DataSource = new classStudent().GetData(txtSearch.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
             classsDB.clearTextBox(this);
            txtFirstname.Focus();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridView_Student.DataSource = new classStudent().GetData();
        }
    }
}
