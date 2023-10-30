using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SqlProject
{
    public class DataAccess
    {
        public int insertProduct(string connectionString)
        {
            string name, description, image;
            int categoryId;
            double price;
            Console.WriteLine("insert category id");
            categoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert name");
            name = Console.ReadLine();
            Console.WriteLine("insert price");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("insert description");
            description = Console.ReadLine();
            Console.WriteLine("insert image name");
            image = Console.ReadLine();

            string query = "INSERT INTO Products(CategoryId,Name,Price,Description,Image)" +
                "VALUES(@CategoryId,@Name,@Price,@Description,@Image)";
            using SqlConnection cn = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value=categoryId;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar,30).Value = name;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar,100).Value = description;
                cmd.Parameters.Add("@Image", SqlDbType.VarChar,20).Value = image;

                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }
        }

        public void readProducts(string connectionString)
        {
            string query = "SELECT * FROM Products";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
            
        }

        public int insertCategory(string connectionString)
        {
            string Name;
            Console.WriteLine("insert name");
            Name = Console.ReadLine();
            string query = "INSERT INTO Categories(CategoryName)" +
                "VALUES(@CategoryName)";
            using SqlConnection cn = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 30).Value=Name;
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }
        }

        public void readCategories(string connectionString)
        {
            string query = "SELECT * FROM Categories";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

        }
    }
}
