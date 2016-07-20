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
        public Item(String n, String c, Category cat, String t)
        {
            this.Name = n;
            this.Cost = c;
            this.Cat = cat;
            //DateTime dt = new DateTime();
            //dt = DateTime.Now;
            this.Time = t;
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

        //Adding attribute with Saldo to XML
        //private string _Saldo = String.Format("{0:F2}", ArrayOfItems.getSaldo());
        //[XmlAttribute]
        //public String Saldo
        //{
        //    get { return _Saldo; }

        //    set { _Saldo = value; }
        //}



    }
}
