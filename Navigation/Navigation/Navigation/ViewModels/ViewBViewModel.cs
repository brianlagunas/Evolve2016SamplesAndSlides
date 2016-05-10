using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Events;
using Navigation.Events;

namespace Navigation.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        private string _title = "View B";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; private set; }

        IEventAggregator _ea;
        public ViewBViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _ea = ea;
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            _ea.GetEvent<MyEvent>().Publish("hello");
            _navigationService.GoBack();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("id"))
                Title = (string)parameters["id"];
        }
    }
}
