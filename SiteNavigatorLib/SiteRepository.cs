using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Android.App;
using Android.Media;
using Stream = System.IO.Stream;

namespace SiteNavigatorLib
{
    public  class SiteRepository
    {
        public  List<SiteData> SiteDetail = new List<SiteData>();
        
        public SiteRepository()
        {
            if (SiteDetail.Count == 0)
            {

                var assembly = typeof(SiteNavigatorLib.SiteRepository).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("SiteNavigatorLib.SiteDataFile.json");

                StreamReader reader = new StreamReader(stream);

                SiteDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SiteData>>(reader.ReadToEnd());
            }
        }

    }
}
