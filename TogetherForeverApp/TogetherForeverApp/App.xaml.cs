using System;
using Xamarin.Forms;
using TogetherForeverApp.Services;
using TogetherForeverApp.Models;
using TogetherForeverApp.Databases;
using System.IO;
using TogetherForeverApp.Data;
using SQLite;

namespace TogetherForeverApp
{
    public partial class App : Application
    {
        public static SQLiteAsyncConnection dbConnection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
        public App()
        {
            InitializeComponent();
            Locator.Initialize();
            //Todo:Initialize
            //IDatabase database = Locator.Resolved<IDatabase>();
            //database.Initialize();


            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MemberDataStore>();
            MainPage = new AppShell();
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
