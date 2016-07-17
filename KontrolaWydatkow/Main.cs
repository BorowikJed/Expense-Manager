using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager
{
    class Main
    {
        public List<Item> Items = new List<Item>();

        public void addItems(String n, String c, Item.Category category)
        {
            Items.Add(new Item(n, c, category));
        }
    }
}
