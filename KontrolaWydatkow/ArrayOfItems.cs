using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace ExpenseManager
{
  //  [XmlRoot(ElementName = "RootXML")]
    public class ArrayOfItems
    {
       // [XmlArray(ElementName = "Items")]
        public List<Item> Items = new List<Item>();
        [XmlAttribute(AttributeName = "mySaldo")]
        public double Saldo = 500.00;

        public double getSaldo()
        {
            return Saldo;
        }

        public void setSaldo(double s)
        {
            if (Saldo < 0)
                MessageBox.Show("Uważaj, jesteś na debecie!!!\nCzas coś zarobić ;)", "Heheszki, uwaga!");
            Saldo = s;

            MainWindow mw = new MainWindow();
            String.Format("{0:F2}", mw.saldoTextBox);
        }

        public void addItems(String n, String c, Item.Category category)
        {
            Items.Add(new Item(n, c, category));
        }

        ////Adding attribute with Saldo to XML
        //private string _mySaldo = String.Format("{0:F2}", 243.6);
        //[XmlAttribute]
        //public String mySaldo
        //{
        //    get { return _mySaldo; }

        //    set { _mySaldo = value; }
        //}
    }
}
