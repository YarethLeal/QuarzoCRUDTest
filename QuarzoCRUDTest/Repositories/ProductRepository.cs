using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using QuarzoCRUDTest.Models;

namespace QuarzoCRUDTest.Repositories
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["QuarzoCRUDTestDB"].ConnectionString;
        }

        public IEnumerable<Product> GetProducts(int ?parameters)
        {
            var products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_Sel_Co_Productos";
                command.Connection = connection;
                command.Parameters.Add("@idCategori", SqlDbType.Int).Value = (object)parameters ?? DBNull.Value;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Category = new Category
                        {
                           CategoryId = reader.GetInt32(3),
                           Name = reader.GetString(4)
                        }
                    });
                }
                connection.Close();
            }

            return products;
        }
    }
}