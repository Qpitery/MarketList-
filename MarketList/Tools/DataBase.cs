using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MarketList.Model;
using Xamarin.Forms;

namespace MarketList.Tools
{
    public class DataBase
    {
        private const string FILE_NAME = "db.db";
        public DboContext dB;

        public DboContext DB
        {
            get
            {
                if (dB == null)
                {
                    string path = DependencyService.Get<IDBPath>().GetDBPath(FILE_NAME);
                    dB = new DboContext(path);
                    dB.Database.EnsureCreated();
                }
                return dB;
            }
        }

        public DataBase()
        {

            List<Category> categories = new List<Category>
            {
                new Category { ID = 1, Name = "Конфеты" },
                new Category { ID = 2, Name = "Мясо" },
                new Category { ID = 3, Name = "Сыр" }
            };

            List<Food> foods = new List<Food>
            {
                new Food { ID = 1, Name = "Маргаритки", IdCategory = 1 },
                new Food { ID = 2, Name = "Птичье Молоко", IdCategory = 1 },
                new Food { ID = 3, Name = "Вафли", IdCategory = 1 },
                new Food { ID = 4, Name = "Баранина", IdCategory = 2 },
                new Food { ID = 5, Name = "Курица", IdCategory = 2 },
                new Food { ID = 6, Name = "Свинина", IdCategory = 2 },
                new Food { ID = 7, Name = "Чедр", IdCategory = 3 },
                new Food { ID = 8, Name = "Сулугуни", IdCategory = 3 },
                new Food { ID = 9, Name = "Пармезан", IdCategory = 3 }
            };
        }

       
        public Category GetByCategoryID(int id)
        {
            return DB.Categories.FirstOrDefault(c => c.ID == id);
        }
        public Food GetByFoodsID(int id)
        {
            return DB.Foods.FirstOrDefault(c => c.ID == id);
        }
        public Category GetCategoryByName(string categoryName)
        {

            return DB.Categories.FirstOrDefault(c => c.Name == categoryName);
            
        }

        public void EditFood(Food food)
        {
            if (food.ID == 0)
            {
                DB.Foods.Add(food);
            }
            else
            {
                Food food1 = GetByFoodsID(food.ID);
                DB.Entry(food1).CurrentValues.SetValues(food);
            }
            DB.SaveChanges();

            //var existingFood = GetFoods().FirstOrDefault(c => c.ID == food.ID);
            //if (existingFood != null)
            //{
            //    existingFood.Name = food.Name;
            //}
        }

        public ObservableCollection<Category> GetCategories()
        {
            return new ObservableCollection<Category>(DB.Categories.ToList());

        }

        public ObservableCollection<Food> GetFoods()
        {
            return new ObservableCollection<Food>(DB.Foods.ToList());
        }
        public Category DeleteCategory(Category category)
        {

            if (category != null)
            {
                DB.Categories.Remove(category);
            }
            DB.SaveChanges();
            return category;
        }

        public void DeleteFood(Food food)
        {

            if (food != null)
            {
                DB.Foods.Remove(food);
            }
           DB.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            if(category.ID == 0)
            {   
                DB.Categories.Add(category);
            }
            else
            {
                Category category1 = GetByCategoryID(category.ID);
                DB.Entry(category1).CurrentValues.SetValues(category);
            }
            DB.SaveChanges();
           
        }

       
    }
}
