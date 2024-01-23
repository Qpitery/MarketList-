
using MarketList;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MarketList.Model;
using MarketList.Tools;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MarketList
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        } 

        protected override void OnAppearing()
        {
            categoryListView.ItemsSource = App.DB.GetCategories();
        }

     

        private void CategoryButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Shell.Current.GoToAsync($"CategoryList?CategoryName={btn.Text}");
           //CategoryName={btn.Text} - это параметр, который передается в эту страницу.
           //В данном случае, текст кнопки (btn.Text) используется как значение параметра "CategoryName".
         
        }

        


    }
}
