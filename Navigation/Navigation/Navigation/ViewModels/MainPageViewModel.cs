using Navigation.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Navigation.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        private string _title = "MainPage";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set {

                SetProperty(ref _isActive, value);
            }
        }

        public DelegateCommand NavigateCommand { get; private set; } 

        public MainPageViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(Navigate).ObservesCanExecute((p) => IsActive);

            ea.GetEvent<MyEvent>().Subscribe(Handled);
        }

        private void Handled(string obj)
        {
            Title = obj;
        }

        private void Navigate()
        {
            _navigationService.Navigate("ViewA");
        }
    }
}
