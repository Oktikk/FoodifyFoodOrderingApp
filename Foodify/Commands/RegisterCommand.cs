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

namespace RestaurantProject.Commands
{
    internal class RegisterCommand : CommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly NavigationService _loginViewNavigationService;
        private readonly Connection _connection;

        public RegisterCommand(RegisterViewModel registerViewModel, NavigationService loginViewNavigationService, Connection connection)
        {
            _registerViewModel = registerViewModel;
            _loginViewNavigationService = loginViewNavigationService;
            _connection = connection;
            _registerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_registerViewModel.Username) && !string.IsNullOrEmpty(_registerViewModel.Password);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_registerViewModel.Username) || e.PropertyName == nameof(_registerViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            if(_connection.RegisterClient(_registerViewModel.Username, _registerViewModel.Password) > 0)
            {
                MessageBox.Show("Pomyślnie zarejestrowano użytkownika!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                _loginViewNavigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Ten użytkownik już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
