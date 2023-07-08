using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using WpfCookBook.Models;

namespace WpfCookBook.Repositories
{
    internal class HomeFood
    {
        private IMongoCollection<FoodRecept> _foodRecept;

        public HomeFood(IMongoCollection<FoodRecept> foodRecept)
        {
            _foodRecept = foodRecept;
        }

        public void AddNew()
        {
            FoodRecept foodRecipe = new FoodRecept()
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
            };

            _foodRecept.InsertOne(foodRecipe);
        }

        public List<FoodRecept> GetAll()
        {
            return _foodRecept.Find(new BsonDocument()).ToList();
        }
        
        public void DeleteOne(FoodRecept foodRecept)
        {
            _foodRecept.DeleteOne(item => item.Id == foodRecept.Id);
        }
    }
}
