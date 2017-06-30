using Android.App;
using Android.Content;
using Android.OS;
using System;

namespace JIOSiteNavigator
{
    [Activity(Label = "JIO Site Navigator", MainLauncher = true, Icon = "@drawable/JIOLogo2")]
    public class MainActivity : TabActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            CreateTab(typeof(SiteSearchActivity), "Search", "Search",Resource.Drawable.ic_tab_searche);
            CreateTab(typeof(AboutActivity), "About", "About", Resource.Drawable.ic_tab_about);
        }

        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
            var drawableIcon = Resources.GetDrawable(drawableId);
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }
    }
}

