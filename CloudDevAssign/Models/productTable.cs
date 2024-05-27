using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace CloudDevAssign.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:aman-cldv-sql-server.database.windows.net,1433;Initial Catalog=aman-cldv-sql-databases;Persist Security Info=False;User ID=aman.adams;Password=Tholland<3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);


        public int productID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }

        public int insert_product(productTable p)
        {

            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }

        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    productTable product = new productTable();
                    product.productID = Convert.ToInt32(r["productID"]);
                    product.Name = r["productName"].ToString();
                    product.Price = r["productPrice"].ToString();
                    product.Category = r["productCategory"].ToString();
                    product.Availability = r["productAvailability"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }

    }
}
