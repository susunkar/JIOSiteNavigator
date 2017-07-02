using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Android.Support.V7.View.Menu;
using Android.Support.V7.Widget;
using Android.Text;
using SiteNavigatorLib;

namespace JIOSiteNavigator
{
    [Activity(Label = "SiteSearchActivity")]
    public class SiteSearchActivity : Activity
    {
        readonly SiteRepository _siteRepo = new SiteRepository();
        private AutoCompleteTextView autocompleteTextView = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SiteSearch);
            
            var autoCompleteOptions = _siteRepo.SiteDetail.Select(c => c.SAPKey).ToArray();
            
            ArrayAdapter autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line
                , autoCompleteOptions);

            autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteInput);
            autocompleteTextView.Adapter = autoCompleteAdapter;

            autocompleteTextView.ItemClick += AutocompleteTextView_ItemClick;

            Button btntechnicianMobileNo = FindViewById<Button>(Resource.Id.btnTechnicianMobileNo);
            Button btncIMobileNo = FindViewById<Button>(Resource.Id.btnCIMobileNo);

            btntechnicianMobileNo.Click += delegate
            {
                CallNumber(btntechnicianMobileNo.Text);
            };
            btncIMobileNo.Click += delegate
            {
                CallNumber(btncIMobileNo.Text);
            };
        }

        private void CallNumber(string phonenumber)
        {
            var callDialog = new AlertDialog.Builder(this);
            callDialog.SetMessage("You want to Call# " + phonenumber);

            callDialog.SetNeutralButton("Cancel", delegate { });
            callDialog.SetPositiveButton("Call", delegate
            {
                var callIntent = new Intent(Intent.ActionCall);
                callIntent.SetData(Android.Net.Uri.Parse("tel:" + phonenumber));
                StartActivity(callIntent);
            });

            callDialog.Show();
        }
        
        //TODO: Exceptio need to handel
        private void AutocompleteTextView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var selectSiteData = _siteRepo.SiteDetail.Where(c => c.SAPKey.Equals(autocompleteTextView.Text));

        }

    }
}