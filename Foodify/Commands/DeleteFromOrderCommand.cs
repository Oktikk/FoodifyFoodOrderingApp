using RestaurantProject.Models;
using RestaurantProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Commands
{
    class DeleteFromOrderCommand : CommandBase
    {
        private readonly MakeOrderViewModel _makeOrderViewModel;

        public override bool CanExecute(object parameter)
        {
            return _makeOrderViewModel.OrderSelectedIndex >= 0;
        }
        public DeleteFromOrderCommand(MakeOrderViewModel makeOrderViewModel)
        {
            _makeOrderViewModel = makeOrderViewModel;
            _makeOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeOrderViewModel.OrderSelectedIndex))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _makeOrderViewModel.Order.RemoveAt((int)parameter);
        }
    }
}
