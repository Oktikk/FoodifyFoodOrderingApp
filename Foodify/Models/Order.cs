using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; }
        public DateTime OrderDate { get; }
        public List<Dish> OrderedDishes { get; set; }

        public string OrderName { get; set; }

        public Order(Client client, DateTime orderDate, List<Dish> orderedDishes)
        {
            Client = client;
            OrderDate = orderDate;
            OrderedDishes = orderedDishes;
        }

        public Order(int id, Client client, DateTime orderDate, List<Dish> orderedDishes)
        {
            Id = id;
            Client = client;
            OrderDate = orderDate;
            OrderedDishes = orderedDishes;
            OrderName = $"Zamówienie nr. {Id}";
        }

    }
}
