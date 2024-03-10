using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Security.AccessControl;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductServices
    {
        private static string db_source = "dbserverak.database.windows.net";
        private static string db_user = "aksqladmin";
            private static string db_password = "Subsai479!14";
        private static string db_database = "AKDatabase";

        private SqlConnection getconnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.InitialCatalog = db_database;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProducts()
        {
            SqlConnection con = getconnection();
            List<Product> _products = new List<Product>();
            string stmt = "select * from Products";
            con.Open();
            SqlCommand cmd = new SqlCommand(stmt, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            {
                while(reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _products.Add(_product);
                }


            }
            con.Close();
            return _products;

        }
    }
}
