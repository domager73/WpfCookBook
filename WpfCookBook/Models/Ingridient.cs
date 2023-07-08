using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.Models
{
    internal class Ingridient
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public String Amount { get; set; }
    }
}