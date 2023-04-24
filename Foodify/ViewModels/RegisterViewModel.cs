using RestaurantProject.Commands;
using RestaurantProject.Models;
using RestaurantProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantProject.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly Restaurant _restaurant;
        private string _username;
        private string _password;

        public ICommand RegisterCommand { get; set; }
        public ICommand CancelRegisterCommand { get; set; }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public Restaurant Restaurant => _restaurant;

        public RegisterViewModel(Restaurant restaurant, NavigationService loginViewNavigationService, Connection connection)
        {
            _restaurant = restaurant;
            RegisterCommand = new RegisterCommand(this, loginViewNavigationService, connection);
            CancelRegisterCommand = new NavigateCommand(loginViewNavigationService);
        }
    }
}
