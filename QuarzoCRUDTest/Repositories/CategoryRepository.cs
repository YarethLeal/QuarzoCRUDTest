using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QuarzoCRUDTest.Models;

namespace QuarzoCRUDTest.Repositories
{
    public class CategoryRepository
    {
        private readonly string connectionString;

        public CategoryRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["QuarzoCRUDTestDB"].ConnectionString;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_Sel_Co_Categoria";
                command.Connection = connection;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        CategoryId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Active = reader.GetBoolean(2)
                    });
                }
                connection.Close();
            }

            return categories;
        }

        public void AddCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_Ins_Co_Categoria";
                command.Parameters.Add("@idCateg", SqlDbType.Int).Value = category.CategoryId;
                command.Parameters.Add("@nombreCateg", SqlDbType.VarChar).Value = category.Name;
                command.Connection = connection;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_Upd_Co_Categoria";
                command.Parameters.Add("@activo", SqlDbType.Bit).Value = category.Active;
                command.Parameters.Add("@nombreCateg", SqlDbType.VarChar).Value = category.Name;
                command.Parameters.Add("@idCateg", SqlDbType.Int).Value = category.CategoryId;
                command.Connection = connection;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }
    }
}