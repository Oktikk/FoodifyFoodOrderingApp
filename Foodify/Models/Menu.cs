using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Menu
    {
        private readonly ObservableCollection<Dish> _mainMenu;

        public ObservableCollection<Dish> MainMenu => _mainMenu;

        public Menu(Connection connection)
        {
            _mainMenu = new ObservableCollection<Dish>(connection.GetMenuPositions());
        }
    }
}
