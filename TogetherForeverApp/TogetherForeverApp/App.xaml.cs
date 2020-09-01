﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TogetherForeverApp.Services;
using TogetherForeverApp.Views;

namespace TogetherForeverApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

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
