using Dapper;
using Microsoft.Data.SqlClient;
using projekt_blogic.Models.Products;
using System.Data;

using projekt_blogic.Models.Users;


namespace projekt_blogic.Data
{
    public static class DataBase
    {
        private static readonly string connectionString = "Data Source = localhost; Initial Catalog = dutyfree; Integrated Security = True; TrustServerCertificate = True;";

        public static List<Product> GetAllProducts()
        {
            using (SqlConnection connection = new(connectionString))
            {
                return connection.Query<Product>(
                    "ProcProducts",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        public static Product ProductEdit(int productId, string name, string imgUrl, int quantity, int price)
        {
            using (SqlConnection connection = new(connectionString))
            {
                var produkt = connection.QueryFirstOrDefault<Product>(
                    "ProcProductEdit",
                    new
                    {
                        ProductId = productId,
                        Name = name,
                        ImageUrl = imgUrl,
                        Quantity = quantity,
                        Price = price
                    },
                    commandType: CommandType.StoredProcedure
                );

                return produkt;
            }
        }

        public static Product ProductInsert(string name, int price, int quantity, string imageUrl)
        {
            using (SqlConnection connection = new(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name);
                parameters.Add("@Price", price);
                parameters.Add("@Quantity", quantity);
                parameters.Add("@ImageUrl", imageUrl);

                return connection.QuerySingle<Product>(
            "ProcProductInsert",
            parameters,
            commandType: CommandType.StoredProcedure);

            }
        }
        
public static User GetUserById(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<User>(
                    "SELECT * FROM Users WHERE UserId = @UserId",
                    new { UserId = userId }
                );
            }
        }
    }
}
