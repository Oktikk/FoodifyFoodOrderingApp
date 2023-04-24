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
    public class OrderListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Order> _orders;
        private ObservableCollection<Dish> _selectedOrderDishes;

        public ICommand MakeOrderCommand { get; set; }

        private Order _selectedOrder;

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (_selectedOrder != value)
                {
                    _selectedOrder = value;
                    SelectedOrderDishes = new ObservableCollection<Dish>(value.OrderedDishes);
                    OnPropertyChanged(nameof(SelectedOrder));
                }
            }
        }

        public ObservableCollection<Order> Orders => _orders;

        public ObservableCollection<Dish> SelectedOrderDishes
        {
            get => _selectedOrderDishes;
            set
            {
                if (_selectedOrderDishes != value)
                {
                    _selectedOrderDishes = value;
                    OnPropertyChanged(nameof(SelectedOrderDishes));
                }
            }
        }

        public OrderListingViewModel(Restaurant restaurant, NavigationService makeOrderViewNavigationService, Client client, Connection connection)
        {
            MakeOrderCommand = new NavigateCommand(makeOrderViewNavigationService);

            _orders = new ObservableCollection<Order>(restaurant.GetClientOrders(client, connection));
            _selectedOrderDishes = new ObservableCollection<Dish>();
        }

    }
}
