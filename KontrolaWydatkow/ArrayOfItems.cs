using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace ExpenseManager
{
    public class ArrayOfItems
    {
        public List<Item> Items = new List<Item>();
        [XmlAttribute(AttributeName = "mySaldo")]
        public double Saldo = 500.00;

        public double getSaldo()
        {
            return Saldo;
        }

        public void setSaldo(double s)
        {
            if (s < 0)
                MessageBox.Show("Uważaj, jesteś na debecie!!!\nCzas coś zarobić ;)", "Heheszki, uwaga!");
            Saldo = s;

            MainWindow mw = new MainWindow();
            String.Format("{0:F2}", mw.saldoTextBox);
        }

        public void addItems(String n, String c, Item.Category category)
        {
            Items.Add(new Item(n, c, category));
        }

    }
}
