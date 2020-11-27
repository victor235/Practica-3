using System;
using System.Collections.Generic;
using System.Text;
using Practica3.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using System.Threading.Tasks;
using Practica3.Models;
using Practica3.Data;
using System.Windows.Input;

namespace Practica3.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        public string email;
        public string password;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;


        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }



        public async void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = true;

            await Task.Delay(10);

            List<UserModel> user = App.Database.GetUsersAndValidate(email, password).Result;

            if(user.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email or password incorrect", "Aceptar");

                this.IsVisibleTxt = false;
                this.IsRunningTxt = false;
                this.IsEnabledTxt = true;
            }
            else if(user.Count >  0)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());

                this.IsVisibleTxt = false;
                this.IsRunningTxt = false;
                this.IsEnabledTxt = true;
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
        }

        public LogInViewModel()
        {
            this.IsEnabledTxt = true;
        }
    }
}
