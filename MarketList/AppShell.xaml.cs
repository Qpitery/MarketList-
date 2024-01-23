using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketList;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace MarketList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();         
            Routing.RegisterRoute("CategoryList", typeof(MarketList.CategoryList));
        }
    }
}
