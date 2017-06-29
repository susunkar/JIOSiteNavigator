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

namespace JIOSiteNavigator
{
    [Activity(Label = "SiteSearchActivity")]
    public class SiteSearchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //TextView textview = new TextView(this);
            //textview.Text = "This is the Site Search Tab.";
            //SetContentView(textview);
            SetContentView(Resource.Layout.SiteSearch);

            /*
            var autoCompleteOptions = new String[] { "Hello", "Hey", "Hej", "Hi", "Hola", "Bonjour", "Gday", "Goodbye", "Sayonara", "Farewell", "Adios" };
            ArrayAdapter autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line
                , autoCompleteOptions);

            var autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteInput);
            autocompleteTextView.Adapter = autoCompleteAdapter;
            */

            #region Additional Information - use a file to populate autocomplete array
            
            // instead of the small array of greetings, use a large dictionary of words loaded from a file
            Stream seedDataStream = Assets.Open(@"WordList.txt");
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(seedDataStream)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    lines.Add(line);
                }
            }
            string[] wordlist = lines.ToArray();
            ArrayAdapter dictionaryAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, wordlist);
            var autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteInput);
            autocompleteTextView.Adapter = dictionaryAdapter;
            
            #endregion
        }
    }
}