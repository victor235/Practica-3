using GalaSoft.MvvmLight.Command;
using Practica3.Models;
using Practica3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Practica3.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string email;
        public string password;
        public string name;
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

        public string NameTxt
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
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

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterUser);
            }
        }

        public async void RegisterUser()
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
            if(string.IsNullOrEmpty(this.name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a name.",
                    "Accept");
                return;
            }

            await Task.Delay(100);

            var user = new UserModel
            {
                Email = email,
                Password = password,
                Name = name
                
            };

            await App.Database.SaveUser(user);

            //await Application.Current.MainPage.DisplayAlert("Exitoso", "Ha sido logeado con exito " + name.ToString() + "", "");

            this.IsVisibleTxt = false;
            this.IsRunningTxt = false;
            this.IsEnabledTxt = true;

            await Application.Current.MainPage.Navigation.PushAsync(new LogIn());
        }


        public RegisterViewModel()
        {
            this.IsEnabledTxt = true;
        }
    }
}
