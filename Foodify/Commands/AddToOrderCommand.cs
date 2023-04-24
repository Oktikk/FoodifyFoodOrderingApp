using RestaurantProject.Models;
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
    class AddToOrderCommand : CommandBase
    {
        private readonly MakeOrderViewModel _makeOrderViewModel;

        public AddToOrderCommand(MakeOrderViewModel makeOrderViewModel)
        {
            _makeOrderViewModel = makeOrderViewModel;
            _makeOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeOrderViewModel.MenuSelectedItem))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _makeOrderViewModel.MenuSelectedItem is not null;
        }

        public override void Execute(object parameter)
        {
            _makeOrderViewModel.Order.Add(_makeOrderViewModel.MenuSelectedItem);
            _makeOrderViewModel.OrderHasDish = true;
        }
    }
}
