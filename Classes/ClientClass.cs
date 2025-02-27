using alexisRetry.Database_Connection;
using alexisRetry.Objects;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace alexisRetry.Classes
{
    public static class ClientClass
    {
        public static void ClientsList()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM D1.Clients", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> clientusernames = new List<string>();
                        while (reader.Read())
                        {
                            clientusernames.Add(reader.GetString(1));
                        }
                        ClientObjects.ClientUsername = clientusernames.ToArray();
                    }
                }
            }
        }

        public static void ClientIdList()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT ClientId FROM D1.Clients WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", ServiceObjects.Clientusername);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientObjects.ClientId = reader.GetInt32(0);
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        public static void AddClient()
        {
            using(SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM D1.Clients WHERE Username = @username OR Email = @email", connection))
                {
                    command.Parameters.AddWithValue("@username", ClientRegister.username);
                    command.Parameters.AddWithValue("@email", ClientRegister.email);

                    int isValid = (int)command.ExecuteScalar();

                    if (isValid > 0) { MessageBox.Show("Username or Email already exist", "Account Existing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO D1.Clients (Username, Email, PhoneNumber, Name) VALUES(@username, @email, @phonenumber, @name)", connection))
                {
                    command.Parameters.AddWithValue("@username", ClientRegister.username);
                    command.Parameters.AddWithValue("@email", ClientRegister.email);
                    command.Parameters.AddWithValue("@phonenumber", ClientRegister.PhoneNumber);
                    command.Parameters.AddWithValue("@name", ClientRegister.name);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Account Successfully Registered!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public static void ClientsDtGrid(DataGridView datagrid)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM D1.Clients", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            datagrid.AutoGenerateColumns = true;
                            datagrid.DataSource = table;
                        }
                        catch { }
                    }
                }
            }
        }

        public static void UpdateClientAccount()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("UPDATE D1.Clients SET Username = @username, Email = @email, PhoneNumber = @phonenum, Name = @name WHERE ClientId = @id", connection))
                {
                    command.Parameters.AddWithValue("@username", updateClientInfo.username);
                    command.Parameters.AddWithValue("@email", updateClientInfo.email);
                    command.Parameters.AddWithValue("@phonenum", updateClientInfo.phoneNum);
                    command.Parameters.AddWithValue("@name", updateClientInfo.name);
                    command.Parameters.AddWithValue("@id", updateClientInfo.id);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Changes applied", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
