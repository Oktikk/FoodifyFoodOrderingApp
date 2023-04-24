using RestaurantProject.Models;
using RestaurantProject.Services;
using RestaurantProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Commands
{
    public class MakeAnOrderCommand : CommandBase
    {
        private readonly Restaurant _restaurant;
        private readonly NavigationService _orderListingViewNavigationService;
        private readonly MakeOrderViewModel _makeOrderViewModel;
        private readonly Client _client;
        private readonly Connection _connection;

        public override bool CanExecute(object parameter)
        {
            return _makeOrderViewModel.Order.Count > 0;
        }

        public MakeAnOrderCommand(MakeOrderViewModel makeOrderViewModel, Restaurant restaurant, NavigationService orderListingViewNavigationService, Client client, Connection connection)
        {
            _restaurant = restaurant;
            _orderListingViewNavigationService = orderListingViewNavigationService;
            _makeOrderViewModel = makeOrderViewModel;
            _client = client;
            _connection = connection;
            _makeOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
                OnCanExecutedChanged();
        }

        public override void Execute(object parameter)
        {
            Order order = new Order(
                _client,
                DateTime.Now,
                new List<Dish>(_makeOrderViewModel.Order)
                );

            _restaurant.MakeAnOrder(order, _connection);
            _orderListingViewNavigationService.Navigate();
        }
    }
}
