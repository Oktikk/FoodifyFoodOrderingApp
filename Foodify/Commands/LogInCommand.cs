using RestaurantProject.Models;
using RestaurantProject.Services;
using RestaurantProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantProject.Commands
{
    public class LogInCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationService _orderListingViewNavigationService;
        private readonly Connection _connection;

        public LogInCommand(LoginViewModel loginViewModel, NavigationService orderListingViewNavigationService, Connection connection)
        {
            _loginViewModel = loginViewModel;
            _orderListingViewNavigationService = orderListingViewNavigationService;
            _connection = connection;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.Username) && !string.IsNullOrEmpty(_loginViewModel.Password);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_loginViewModel.Username) || e.PropertyName == nameof(_loginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _loginViewModel.Restaurant.Client = _connection.GetClient(_loginViewModel.Username, _loginViewModel.Password);
            if(_loginViewModel.Restaurant.Client != null)
            {
                _orderListingViewNavigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Podano błędne hasło lub taki użytkownik nie istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
