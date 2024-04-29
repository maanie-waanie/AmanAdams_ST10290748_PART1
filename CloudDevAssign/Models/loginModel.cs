using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CloudDevAssign.Models
{
    public class loginModel
    {
        public static string con_string = "Server=tcp:aman-cldv-sql-server.database.windows.net,1433;Initial Catalog=aman-cldv-sql-databases;Persist Security Info=False;User ID=aman.adams;Password=Tholland<3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


        public int SelectUser(string email, string name, string password)
        {
            int userId = -1; 
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);

                con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                
                
            }
            return userId;
        }

    }
}