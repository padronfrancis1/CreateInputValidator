using DomainModel;
using System;
using System.Windows;
using WinApp.Commands;
using WinApp.Events;

namespace WinApp.ViewModels.ValidationVM
{
    class ValidationViewModel
    {
        public ValidationViewModel()
        {
            BuilCommands();
        }

        private void BuilCommands()
        {
            OKCommand = new RelayCommand((arg) =>
            {
                Window.Close();
            });
        }

        public virtual ValidationEventArgs Item { get; set; }
        public RelayCommand OKCommand { get; set; }

        public Window Window { get; set; }
    }
}