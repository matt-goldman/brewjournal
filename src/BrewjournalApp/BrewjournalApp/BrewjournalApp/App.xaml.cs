﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BrewjournalApp.Services;
using BrewjournalApp.Views;

namespace BrewjournalApp
{
    public partial class App : Application
    {
        public static Constants Constants { get; set; }

        public App()
        {
            InitializeComponent();
            Constants = new Constants();
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
