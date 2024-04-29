using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace CloudDevAssign.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:aman-cldv-sql-server.database.windows.net,1433;Initial Catalog=aman-cldv-sql-databases;Persist Security Info=False;User ID=aman.adams;Password=Tholland<3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }

        public int insert_Product(productTable e)
        {
            string sql = "INSERT INTO productTable(productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@ID", e.productID);
            cmd.Parameters.AddWithValue("@Name", e.Name);
            cmd.Parameters.AddWithValue("@Price", e.Price);
            cmd.Parameters.AddWithValue("@Category", e.Category);
            cmd.Parameters.AddWithValue("@Availability", e.Availability);
            con.Open();
            int resultAffected = cmd.ExecuteNonQuery();
            con.Close();
            return resultAffected;
        }

    }
}

