using Dapper;
using Microsoft.Data.SqlClient;
using projekt_blogic.Models.Products;
using System.Data;

namespace projekt_blogic.Data
{
    public class DataBase
    {
        private static readonly string connectionString = "Data Source = LAPTOP-RTBVRDRR; Initial Catalog = dutyfree; Integrated Security = True; TrustServerCertificate = True;";

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

        public static void ProductEdit(Product produkt)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Execute(
                    "ProcProductEdit",
                    new
                    {
                        ProductId = produkt.ProductID,
                        Name = produkt.Name,
                        ImageUrl = produkt.ImageUrl,
                        Quantity = produkt.Quantity,
                        Price = produkt.Price
                    },
                    commandType: CommandType.StoredProcedure
                );
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
    }
}
