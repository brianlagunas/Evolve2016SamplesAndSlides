using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Navigation.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
		readonly INavigationService _navigationService;

		private string _title = "View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _value = "parameter";
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public DelegateCommand NavigateCommand { get; private set; }

        public ViewAViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            var p = new NavigationParameters();
            p.Add("id", Value);

            _navigationService.NavigateAsync("ViewB", p);
        }
    }
}
