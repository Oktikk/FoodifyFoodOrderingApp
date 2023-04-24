using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantProject.Models
{
    public class Connection
    {
        private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public List<Dish> GetMenuPositions()
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand($"exec GetMenuPositions", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Dish> menu = new List<Dish>();
            while(reader.Read())
            {
                menu.Add(new Dish(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3)));
            }
            _sqlConnection.Close();
            return menu;
        }

        public void AddOrderToDatabase(Order order)
        {
            _sqlConnection.Open();
            string dateString = order.OrderDate.ToString("yyyyMMdd HH:mm:ss");
            SqlCommand command = new SqlCommand($"exec InsertOrder @clientId={order.Client.ID}, @orderDate='{dateString}'", _sqlConnection);

            int lastId = Convert.ToInt32(command.ExecuteScalar());


            foreach (Dish dish in order.OrderedDishes)
            {
                command = new SqlCommand($"exec InsertOrderProducts @menuId={dish.ID}, @orderId={lastId}", _sqlConnection);
                command.ExecuteNonQuery();
            }
            _sqlConnection.Close();
        }

        public List<Order> GetClientOrders(Client client)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand($"exec GetClientOrders @clientId={client.ID}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                orders.Add(new Order(reader.GetInt32(0), client, reader.GetDateTime(1), GetClientOrderDetails(reader.GetInt32(0))));
            }
            _sqlConnection.Close();

            return orders;
        }

        public List<Dish> GetClientOrderDetails(int orderId)
        {
            SqlCommand command = new SqlCommand($"exec GetClientOrderDetails @orderId={orderId}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Dish> dishes = new List<Dish>();
            while (reader.Read())
            {
                dishes.Add(new Dish(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3)));
            }
            return dishes;
        }

        public Client GetClient(string username, string password)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand($"exec GetClient @username={username}, @password={password}", _sqlConnection);
            int id = Convert.ToInt32(command.ExecuteScalar());
            _sqlConnection.Close();
            if(id > 0)
            {
                return new Client(id, username);
            }
            else
            {
                return null;
            }
        }

        public int RegisterClient(string username, string password)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand($"exec RegisterClient @username={username}, @password={password}", _sqlConnection);
            int result = command.ExecuteNonQuery();
            _sqlConnection.Close();
            return result;
        }
    }
}
