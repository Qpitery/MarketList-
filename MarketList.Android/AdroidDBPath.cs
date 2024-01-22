using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MarketList.Droid;
using MarketList.Tools;

[assembly: Dependency(typeof(AndroidDBPath))]
namespace MarketList.Droid
{
    public class AndroidDBPath : IDBPath
    {
        public string GetDBPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Personal), filename);
        }
    }
}
