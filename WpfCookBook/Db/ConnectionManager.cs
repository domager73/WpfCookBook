using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.Models;

namespace WpfCookBook.Db
{
    internal class ConnetionManager
    {
        private static ConnetionManager _instance;

        public static ConnetionManager Instance
        {
            get { return _instance ?? (_instance = new ConnetionManager()); }
        }

        private IMongoDatabase _db;

        private ConnetionManager()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");

            _db = client.GetDatabase("cookBook");
        }

        public IMongoCollection<FoodRecept> GetHomeFoodCollection()
        {
            return _db.GetCollection<FoodRecept>("homefood");
        }
    }
}
