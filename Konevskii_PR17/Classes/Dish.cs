using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konevskii_PR17.Classes
{
    public class Dish
    {
        public int id;
        public string name;
        public List<Sizes> sizes = new List<Sizes>();
        public string img;
        public List<Ingredient> ingredients = new List<Ingredient>();
        public string description;

        public int activeSize = 0;

        public class Sizes
        {
            public int id, id_size, size, price, wes;

            public int countOrder;
            public bool orders;
        }

        public class Ingredient 
        {
            public int id, name, wes, price;

            public string img;
            public int count;
        }
    }
}
