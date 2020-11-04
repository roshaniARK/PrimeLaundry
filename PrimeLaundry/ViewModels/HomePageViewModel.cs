using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrimeLaundry.ViewModels
{
    public class HomePageViewModel : BindableBase, INavigatedAware
    {
        INavigationService navigationService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }


        public HomePageViewModel(INavigationService navigationService)
        {
            UserName = _userName;
            this.navigationService = navigationService;
        }


        void INavigatedAware.OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        void INavigatedAware.OnNavigatedTo(INavigationParameters parameters)
        {
            UserName = parameters["name"] as string;
        }
    }
}
