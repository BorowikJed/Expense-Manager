using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager
{
    public class Item
    {
        public String Name { get; set; } 
        public String Cost { get; set; }
        public Category Cat { get; set; }
        public String Time { get; set; }

        public Item(String n, String c, Category cat)
        {
            this.Name = n;
            this.Cost = c;
            this.Cat = cat;
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            this.Time = String.Format("{0:u}", dt);
        }
        public Item()
        {

        }

        public  enum Category
        {
            Food = -1,
            Household = -2,
            Salary = 1
        }
     
        

    }
}
