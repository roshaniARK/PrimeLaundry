using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimeLaundry.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public DelegateCommand OnLoginCommand { get; set; }
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            OnLoginCommand = new DelegateCommand(async () => await GoHome());
        }

        async Task GoHome()
        {
            if (string.IsNullOrEmpty(UserName))
                await _pageDialogService.DisplayAlertAsync("Error", "UserName is required", "Ok");
            else
            {
                // pass parameter to the next screen 
                var navigationParams = new NavigationParameters();
                navigationParams.Add("name", "mayur");
                await _navigationService.NavigateAsync("/NavigationPage/HomePage", navigationParams);
                // await NavigationService.NavigateAsync("/NavigationPage/MainPage");
            }
        }

        // Sign In button click event
        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new BottomBarPage();

            //  email = EmailEntry.Text;
            //   password = PasswordEntry.Text;
            bool isValid = false;
            string toast = "";
            string emailValidation = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";

            // Login API Call 
            Device.BeginInvokeOnMainThread(async () =>
            {
                // UserDialogs.Instance.ShowLoading(AppResources.pleaseWait);
            });

            if (App.current == NetworkAccess.Internet)
            {
                bool isEmailExist = false;

                try
                {
                    if (string.IsNullOrEmpty(UserName))
                    {
                        Utils.DismissDialog();
                        isValid = false;
                        toast = AppResources.enterEmail;
                    }
                    else if (string.IsNullOrEmpty(PasswordEntry.Text))
                    {
                        Utils.DismissDialog();
                        isValid = false;
                        toast = AppResources.enterPassword;
                    }
                    else if (EmailEntry.Text.Contains("@"))
                    {
                        if (!Regex.Match(EmailEntry.Text, emailValidation).Success)
                        {
                            Utils.DismissDialog();
                            isValid = false;
                            toast = AppConstant.EMAILVALID;
                        }
                    }
                    else if ((int)(PasswordEntry.Text.Length) < 8)
                    {
                        Utils.DismissDialog();
                        isValid = false;
                        toast = AppConstant.LENGTHOFPASSWORD;
                    }
                    else
                    {
                        try
                        {
                            LoginAPICall(isValid);
                        }
                        catch (Exception ex)
                        {
                            Utils.ShowToast(AppResources.somethingWentWrong, 3000);
                            Debug.WriteLine("Login Api exception=" + ex.Message);
                        }
                    }

                    if (!string.IsNullOrEmpty(toast))
                        Utils.ShowToast(toast, 3000);
                }
                catch (Exception ex)
                {
                    Utils.DismissDialog();
                    Debug.WriteLine("LoginException " + ex.Message);
                    App.logger.Debug("LoginException ", ex.Message.ToString());
                }

            }
            else
            {
                Utils.DismissDialog();
                Utils.ShowToast(AppConstant.NOINTERNET, 3000);
                App.logger.Debug("Internet_Error ", AppConstant.NOINTERNET);
            }

        }

    }
}