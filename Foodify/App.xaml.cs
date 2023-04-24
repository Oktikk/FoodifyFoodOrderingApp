using RestaurantProject.Models;
using RestaurantProject.Services;
using RestaurantProject.Stores;
using RestaurantProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Restaurant _restaurant;
        private readonly NavigationStore _navigationStore;
        private readonly Connection _connection;
        private string _connectionString = @"Server=localhost\SQLEXPRESS;Database=Restaurant;Trusted_Connection=True;MultipleActiveResultSets=true";

        public App()
        {
            _restaurant = new Restaurant("Foodify");
            _navigationStore = new NavigationStore();
            _connection = new Connection(_connectionString);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateLoginViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeOrderViewModel CreateMakeOrderViewModel()
        {
            return new MakeOrderViewModel(_restaurant, new NavigationService(_navigationStore, CreateOrderListingViewModel), _restaurant.Client, _connection);
        }

        private OrderListingViewModel CreateOrderListingViewModel()
        {
            return new OrderListingViewModel(_restaurant, new NavigationService(_navigationStore, CreateMakeOrderViewModel), _restaurant.Client, _connection);
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(_restaurant, new NavigationService(_navigationStore, CreateOrderListingViewModel),
                new NavigationService(_navigationStore, CreateRegisterViewModel), _connection);
        }
        private RegisterViewModel CreateRegisterViewModel()
        {
            return new RegisterViewModel(_restaurant, new NavigationService(_navigationStore, CreateLoginViewModel), _connection);
        }
    }
}
