using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIU_E1_204
{
    internal class classStudent
    {
        // Table columns
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ClassID { get; set; }
        public string GuardianName { get; set; }
        public string GuardianContact { get; set; }

        // =========================
        // SELECT
        // =========================
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da =
                   new SqlDataAdapter("SELECT * FROM StudentRegister", classsDB.conn))
            {
                da.Fill(dt);
            }

            return dt;
        }

        public bool InsertData()
        {
            bool result = false;

            string sql = @"INSERT INTO [dbo].[StudentRegister]
            (
                FirstName,
                LastName,
                DateOfBirth,
                Gender,
                Address,
                PhoneNumber,
                Email,
                GuardianName,
                GuardianContact
            )
            VALUES
            (
                @FirstName,
                @LastName,
                @DateOfBirth,
                @Gender,
                @Address,
                @PhoneNumber,
                @Email,
                @GuardianName,
                @GuardianContact
            )";

            using (SqlCommand cmd = new SqlCommand(sql, classsDB.conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@GuardianName", GuardianName);
                cmd.Parameters.AddWithValue("@GuardianContact", GuardianContact);

                try
                {
                    if (classsDB.conn.State != ConnectionState.Open)
                        classsDB.conn.Open();

                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    // handle error
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    if (classsDB.conn.State == ConnectionState.Open)
                        classsDB.conn.Close();
                }

            }

            return result;
        }

        // Update

        public bool UpdateData()
        {
            bool result = false;

            string sql = @"UPDATE StudentRegister
                SET
                    FirstName       = @FirstName,
                    LastName        = @LastName,
                    DateOfBirth     = @DateOfBirth,
                    Gender          = @Gender,
                    Address         = @Address,
                    PhoneNumber     = @PhoneNumber,
                    Email           = @Email,
                    GuardianName    = @GuardianName,
                    GuardianContact = @GuardianContact
                WHERE StudentID = @StudentID";

            using (SqlCommand cmd = new SqlCommand(sql, classsDB.conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@GuardianName", GuardianName);
                cmd.Parameters.AddWithValue("@GuardianContact", GuardianContact);

                try
                {
                    if (classsDB.conn.State != ConnectionState.Open)
                        classsDB.conn.Open();

                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    // handle error
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    if (classsDB.conn.State == ConnectionState.Open)
                        classsDB.conn.Close();
                }

            }

            return result;
        }

        //Delete

        public bool Delete()
        {
            bool result = false;

            string sql = @"delete from StudentRegister 
                            where StudentID = @StudentID";

            using (SqlCommand cmd = new SqlCommand(sql, classsDB.conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
               

                try
                {
                    if (classsDB.conn.State != ConnectionState.Open)
                        classsDB.conn.Open();

                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    // handle error
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    if (classsDB.conn.State == ConnectionState.Open)
                        classsDB.conn.Close();
                }

            }

            return result;
        }

        // Search

        public DataTable GetData(string q)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(@"
                                                            SELECT *
                                                            FROM StudentRegister
                                                            WHERE 
                                                            ISNULL(FirstName,'') +
                                                            ISNULL(LastName,'') +
                                                            ISNULL(CAST(PhoneNumber AS NVARCHAR(50)),'') +
                                                            ISNULL(CAST(StudentID AS NVARCHAR(50)),'')
                                                            LIKE '%' + @q + '%'", classsDB.conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@q", q ?? "");

                da.Fill(dt);
            }

            return dt;
        }



    }
}
