using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.Db;
using WpfCookBook.Models;
using WpfCookBook.Repositories;

namespace WpfCookBook.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private HomeFood _homeFoodRepository;

        [ObservableProperty]
        public List<FoodRecept> _foodRecepte;

        [ObservableProperty]
        public FoodRecept _selectFoodRecepte;

        public MainWindowViewModel()
        {
            _homeFoodRepository = new HomeFood(ConnetionManager.Instance.GetHomeFoodCollection());
            _foodRecepte = _homeFoodRepository.GetAll();
        }

        [RelayCommand]
        public void AddNewRecept()
        {
            _homeFoodRepository.AddNew();
            FoodRecepte.Add(new FoodRecept()
            {
                FoodCost = (decimal)23.1,
                Rating = (decimal)4.5,
                Name = "Апельсиновый торт",
                PicturePath = "https://3d-linker.ru/components/com_jshopping/files/img_products/full_Fish_Food_Potato_Mushrooms_Lemons_Vegetables_538030_5472x3648.jpg",
                Ingridients = new List<Ingridient>()
{
new Ingridient()
{
    Id = new MongoDB.Bson.ObjectId(),
Name = "Мука",
Amount = "2 с.л."
},
new Ingridient()
{
    Id = new MongoDB.Bson.ObjectId(),
Name = "Яйца",
Amount = "3 шт."
},
new Ingridient()
{
    Id = new MongoDB.Bson.ObjectId(),
Name = "Сахар",
Amount = "4 ч.л."
},
}
            }
);

            SelectFoodRecepte = FoodRecepte.Last();
        }

        [RelayCommand]
        public void DeleteOne()
        {
            if (SelectFoodRecepte == null) return;

            _homeFoodRepository.DeleteOne(SelectFoodRecepte);
            FoodRecepte.Remove(SelectFoodRecepte);
            FoodRecepte = _homeFoodRepository.GetAll();
            SelectFoodRecepte = null;
        }
    }
}
