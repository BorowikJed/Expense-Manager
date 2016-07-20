using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpenseManager
{
    //[XmlRoot(ElementName = "RootXML")]
    public class Item
    {
        //they are public because of problems
        //with access working with XML
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
            Jedzenie = -1,
            Domowe = -2,
            Samochód = -3,
            Opłaty = -4,
            Rozrywka = -5,
            Przychód = 1
        }

    }
}
