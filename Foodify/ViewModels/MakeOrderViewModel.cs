using RestaurantProject.Commands;
using RestaurantProject.Models;
using RestaurantProject.Services;
using RestaurantProject.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantProject.ViewModels
{
    public class MakeOrderViewModel : ViewModelBase 
    {
        public ICommand AddToOrderCommand { get; set; }
        public ICommand DeleteFromOrderCommand { get; set; }
        public ICommand MakeAnOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; }

        private readonly ObservableCollection<Dish> _menu;
        private readonly ObservableCollection<Dish> _order;

        private Dish _menuSelectedItem;
        private int _orderSelectedIndex = -1;

        private bool _orderHasDish = false;

        public bool OrderHasDish
        {
            get { return _orderHasDish; }
            set
            {
                _orderHasDish = value;
                OnPropertyChanged(nameof(OrderHasDish));
            }
        }

        public Dish MenuSelectedItem
        {
            get => _menuSelectedItem;
            set
            {
                if (_menuSelectedItem != value)
                {
                    _menuSelectedItem = value;
                    OnPropertyChanged(nameof(MenuSelectedItem));
                }
            }
        }

        public int OrderSelectedIndex
        {
            get => _orderSelectedIndex;
            set
            {
                if (_orderSelectedIndex != value)
                {
                    _orderSelectedIndex = value;
                    OnPropertyChanged(nameof(OrderSelectedIndex));
                }
            }
        }

        public IEnumerable<Dish> Menu => _menu;
        public ObservableCollection<Dish> Order => _order;

        public MakeOrderViewModel(Restaurant restaurant, NavigationService orderListingViewNavigationService, Client client, Connection connection)
        {
            _menu = new Menu(connection).MainMenu;
            _order = new ObservableCollection<Dish>();
            AddToOrderCommand = new AddToOrderCommand(this);
            DeleteFromOrderCommand = new DeleteFromOrderCommand(this);
            MakeAnOrderCommand = new MakeAnOrderCommand(this, restaurant, orderListingViewNavigationService, client, connection);
            CancelOrderCommand = new NavigateCommand(orderListingViewNavigationService);
        }
    }
}
