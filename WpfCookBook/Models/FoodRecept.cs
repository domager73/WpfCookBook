using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.Models
{
    internal class FoodRecept
    {
        public ObjectId Id { get; set; }

        public String Name { get; set; }

        public String PicturePath { get; set; }

        public decimal FoodCost { get; set; }

        public decimal Rating { get; set; }

        public List<Ingridient> Ingridients { get; set; }
    }
}
