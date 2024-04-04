using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CloudDevAssign.Models
{
    public class userTable : Controller
    {

        public static string con_string = "Server=tcp:aman-cldv-sql-server.database.windows.net,1433;Initial Catalog=aman-cldv-sql-databases;Persist Security Info=False;User ID=aman.adams;Password=Tholland<3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

         public string Name
         {
             get; set;
          }

         public string Surname
        {
            get; set;
        }

         public string Email
         {
             get; set;
         }

         public int insert_User(userTable e)

        {

            try
            {
                string sql = "INSERT INTO userTable(userName, userSurname, userEmail) VALUES (@Name, @Surname, @ Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", e.Name);
                cmd.Parameters.AddWithValue("@Surname", e.Surname);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;

            }
            catch (Exception ex) 
            {
                throw ex;
                
            }
           
          }
        public IActionResult Index()
        {
            return View();
        }
    }
}
