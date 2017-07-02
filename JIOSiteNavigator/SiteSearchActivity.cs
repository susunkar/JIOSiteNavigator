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
        private AutoCompleteTextView _autocompleteTextView = null;
        private string latitude = "0.0";
        private string logitude = "-0.0";
        private string _geoSiteName = string.Empty;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SiteSearch);
            
            var autoCompleteOptions = _siteRepo.SiteDetail.Select(c => c.SAPKey).ToArray();
            
            ArrayAdapter autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line
                , autoCompleteOptions);

            _autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteInput);
            _autocompleteTextView.Adapter = autoCompleteAdapter;

            _autocompleteTextView.ItemClick += AutocompleteTextView_ItemClick;

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

            Button geoMap = FindViewById<Button>(Resource.Id.btnGeoMap);
            geoMap.Click += delegate
            {
                string mapUri = string.Format("geo:0,0?q={0},{1}({2})", latitude, logitude, _geoSiteName);
                var geoUri = Android.Net.Uri.Parse(mapUri);
                var mapIntent = new Intent(Intent.ActionView, geoUri);
                StartActivity(mapIntent);
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
            var selectSiteData = _siteRepo.SiteDetail.Where(c => c.SAPKey.Equals(_autocompleteTextView.Text)).Take(1);
            var siteDatas = selectSiteData as SiteData[] ?? selectSiteData.ToArray();
            var firstOrDefault = siteDatas.FirstOrDefault();

            TextView sapid = FindViewById<TextView>(Resource.Id.txtSAPIdValue);
            TextView siteName = FindViewById<TextView>(Resource.Id.txtSiteNameValue);
            TextView ipName = FindViewById<TextView>(Resource.Id.txtIPNameValue);
            TextView ipcoloid = FindViewById<TextView>(Resource.Id.txtIPCOLOIDValue);
            TextView towerType = FindViewById<TextView>(Resource.Id.txtTowerTypeValue);
            TextView technicianName = FindViewById<TextView>(Resource.Id.txtTechnicianName);
            Button btntechnicianMobileNo = FindViewById<Button>(Resource.Id.btnTechnicianMobileNo);
            Button btncIMobileNo = FindViewById<Button>(Resource.Id.btnCIMobileNo);
            TextView ciName = FindViewById<TextView>(Resource.Id.txtCIName);
            TextView siteAddress = FindViewById<TextView>(Resource.Id.txtSiteAddressValue);
            TextView facilityType = FindViewById<TextView>(Resource.Id.txtFacilityTypeValue);
            TextView type = FindViewById<TextView>(Resource.Id.txtTypeValue);
            TextView gateWayIp = FindViewById<TextView>(Resource.Id.txtGateWayIPValue);
            TextView backhole = FindViewById<TextView>(Resource.Id.txtBackholeValue);
            TextView lb = FindViewById<TextView>(Resource.Id.txtLBValue);
            TextView sitesDependency = FindViewById<TextView>(Resource.Id.txtSitesDependencyValue);
            

            if (firstOrDefault != null)
            {
                sapid.Text = firstOrDefault.SAPID;
                siteName.Text = firstOrDefault.SiteName;
                ipName.Text = firstOrDefault.IPName;
                ipcoloid.Text = firstOrDefault.IPCOLOID;
                towerType.Text = firstOrDefault.TowerType;
                technicianName.Text = firstOrDefault.TechnicianName + " (Technician)";
                btntechnicianMobileNo.Text = firstOrDefault.TechnicianMobileNo.ToString();
                ciName.Text = firstOrDefault.CIName + " (CI)";
                btncIMobileNo.Text = firstOrDefault.PhoneNumber;
                siteAddress.Text = firstOrDefault.SiteAddress;
                facilityType.Text = firstOrDefault.FacilityType;
                type.Text = firstOrDefault.Type;
                gateWayIp.Text = firstOrDefault.GateWayIP;
                backhole.Text = firstOrDefault.Backhole;
                lb.Text = firstOrDefault.LB;
                sitesDependency.Text = firstOrDefault.SitesDependency.ToString();

                latitude = firstOrDefault.Lat.ToString();
                logitude = firstOrDefault.Long.ToString();
                _geoSiteName = firstOrDefault.SiteName;
            }
        }

    }
}