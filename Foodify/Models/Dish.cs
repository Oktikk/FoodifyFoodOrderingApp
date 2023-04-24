using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Dish
    {
        public int ID { get; }
        public string Name { get; }
        public string Category { get; }
        public double Price { get; }

        public Dish(int iD, string name, string category, double price)
        {
            ID = iD;
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
