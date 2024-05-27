using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CloudDevelopment.Models
{
    public class ProductDisplayModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productCategory { get; set; }
        public bool productAvailability { get; set; }

        public ProductDisplayModel() { }

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public ProductDisplayModel(int id, string name, decimal price, string category, bool availability)
        {
            productID = id;
            productName = name;
            productPrice = price;
            productCategory = category;
            productAvailability = availability;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> product = new List<ProductDisplayModel>();

            string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, productCategory, productAvailability FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel products = new ProductDisplayModel();
                    products.productID = Convert.ToInt32(reader["productID"]);
                    products.productName = Convert.ToString(reader["productName"]);
                    products.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    products.productCategory = Convert.ToString(reader["productCategory"]);
                    products.productAvailability = Convert.ToBoolean(reader["productAvailability"]);
                    product.Add(products);
                }
                reader.Close();
            }
            return product;
        }
    }
}
