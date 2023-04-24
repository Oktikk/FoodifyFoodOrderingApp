using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Orders
    {
        private readonly ObservableCollection<Order> _orders;

        public Orders()
        {
            _orders = new ObservableCollection<Order>();
        }

        public IEnumerable<Order> GetClientOrders(Client client, Connection connection)
        {
            return connection.GetClientOrders(client);
        }

        public void MakeAnOrder(Order order, Connection connection)
        {
            connection.AddOrderToDatabase(order);
        }
    }
}
