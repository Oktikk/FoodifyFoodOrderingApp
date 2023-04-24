using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Restaurant
    {
        private readonly Orders _orders;
        private Client _client;

        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public string Name { get; }

        public Restaurant(string name)
        {
            _orders = new Orders();
            Name = name;
        }

        public IEnumerable<Order> GetClientOrders(Client client, Connection connection)
        {
            return _orders.GetClientOrders(client, connection);
        }

        public void MakeAnOrder(Order order, Connection connection)
        {
            _orders.MakeAnOrder(order, connection);
        }
    }
}
