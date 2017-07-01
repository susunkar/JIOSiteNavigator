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

namespace SiteNavigatorLib
{
    public class SiteData
    {
        public string SAPKey { get; set; }
        public string SAPID { get; set; }
        public string SiteName { get; set; }
        public string IPName { get; set; }
        public string IPCOLOID { get; set; }
        public float? Lat { get; set; }
        public float? Long { get; set; }
        public string TowerType { get; set; }
        public string TechnicianName { get; set; }
        public Int64? TechnicianMobileNo { get; set; }
        public string CIName { get; set; }
        public string PhoneNumber { get; set; }
        public string SiteAddress { get; set; }
        public string FacilityType { get; set; }
        public string Type { get; set; }
        public string GateWayIP { get; set; }
        public string Backhole { get; set; }
        public string LB { get; set; }
        public int? SitesDependency { get; set; }
    }
}