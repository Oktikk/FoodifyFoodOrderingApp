using RestaurantProject.Commands;
using RestaurantProject.Models;
using RestaurantProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantProject.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly Restaurant _restaurant;
        private string _username;
        private string _password;

        public ICommand LogInCommand { get; set; }
        public ICommand RegisterNavigateCommand { get; set; }

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


        public LoginViewModel(Restaurant restaurant, NavigationService orderListingViewNavigationService, NavigationService registerViewNavigationService, Connection connection)
        {
            _restaurant = restaurant;
            LogInCommand = new LogInCommand(this, orderListingViewNavigationService, connection);
            RegisterNavigateCommand = new NavigateCommand(registerViewNavigationService);
        }
    }
}
