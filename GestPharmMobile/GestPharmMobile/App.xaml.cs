﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestPharmMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pages.HomePage();
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
