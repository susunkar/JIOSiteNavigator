﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JIOSiteNavigator
{
    [Activity(Label = "About Activity")]
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TextView textview = new TextView(this);
            textview.Text = "This is the About JIO's Site Navigator Application.";
            SetContentView(textview);
        }
    }
}