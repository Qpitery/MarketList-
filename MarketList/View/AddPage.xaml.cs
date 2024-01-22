
using System;
using MarketList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarketList.Model;
using MarketList.Tools;
using System.Collections.ObjectModel;

namespace MarketList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {

        public AddPage()
        { 
           
            InitializeComponent();
            CategoryList.ItemsSource = new ObservableCollection<Category>(App.DB.GetCategories());
        }
     
        private void BtnAdd(object sender, EventArgs e)
        {
            Category category = new Category { Name = AddEntry.Text };
            App.DB.EditCategory(category);

            OnAppearing();
            messagelabel.Text = "Добавлено!";
        }

        private void BtnEdit(object sender, EventArgs e)
        {

            if (CategoryList.SelectedItem != null)
            {
                Category selectedCategory = CategoryList.SelectedItem as Category;
                if (AddEntry.Text != null)
                {
                    selectedCategory.Name = AddEntry.Text;
                   
                    CategoryList.ItemsSource = new ObservableCollection<Category>(App.DB.GetCategories());
                    messagelabel.Text = "Сохранено!!!";
                }
                else
                {
                    messagelabel.Text = "Введите Имя!!!";
                }
            }
            else
            {
                messagelabel.Text = "Выберите категорию!!!";
            }
        }
        protected override void OnAppearing()
        {
            CategoryList.ItemsSource = new ObservableCollection<Category>(App.DB.GetCategories().ToList());
        }


        private void BtnDel(object sender, EventArgs e)
        {
            if (CategoryList.SelectedItem != null)
            {
                Category selectedCategory = CategoryList.SelectedItem as Category;
                App.DB.DeleteCategory(selectedCategory);

                OnAppearing();
                messagelabel.Text = "Удалено!!!";
            }
            else
            {
                messagelabel.Text = "Выберите категорию для удаления";
            }
        }
        //protected override void OnAppearing()
        //{
        //    AllItem.ItemsSource = new ObservableCollection<Food>(App.DB.GetFoods().ToList());
        //}

        //private void BtnDel(object sender, EventArgs e)
        //{
        //    if (AllItem.SelectedItem != null)
        //    {
        //        Food selectedFoods = AllItem.SelectedItem as Food;
        //        App.DB.DeleteFood(selectedFoods);
        //        OnAppearing();
        //        messagelabel.Text = "Удалено!!!";
        //    }
        //    else
        //    {
        //        messagelabel.Text = "Выберите Продукт для удаления";
        //    }
        //}

        private void CategoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (CategoryList.SelectedItem != null)
            {
                AddEntry.Text = ((Category)CategoryList.SelectedItem).Name;
            }
        }
    }
}
