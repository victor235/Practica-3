using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Practica3.Data;
using System.IO;
using Practica3.Views;
namespace Practica3
{
    public partial class App : Application
    {
        static DataQuerys database;
        public static DataQuerys Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataQuerys(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBname.db"));
                }
                return database;

            }
        }




        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogIn());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
