using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpenseManager
{
    /// <summary>
    /// Do zrobienia:
    /// -rzutowanie ceny itemów na double ----------OK
    /// -Wprowadzanie stanu mojego konta -----------OK...
    /// -edycja stanu konta, odejmowanie i dodawanie po wrzuceniu itemków
    /// -gdzieś trzymać ten stan konta (chyba w Settings czy coś można)
    /// -polimorfizmy, dziedziczenia? Czy warto?
    /// -zmiana źródłowego xmla
    /// -github ---------OK
    /// -JAK KTOŚ USUNIE POWINNA WRÓCIĆ KASA!
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayOfItems mainArray = new ArrayOfItems();

        public MainWindow()
        {
            InitializeComponent();
            listView.ItemsSource = mainArray.Items;
   
        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Item.Category)))
            {
                category.Items.Add(item);
            }
            category.SelectedIndex = 1;
        }

        //Adding item to list
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cost.Text = String.Format("{0:F2}", double.Parse(cost.Text));
                mainArray.addItems(name.Text, cost.Text, (Item.Category)category.SelectedItem);
                listView.ItemsSource = null;
                listView.ItemsSource = mainArray.Items;
                if (category.SelectedItem.ToString() == "Przychód")
                    mainArray.setSaldo(mainArray.getSaldo() + double.Parse(cost.Text));
                else
                    mainArray.setSaldo(mainArray.getSaldo() - double.Parse(cost.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zły format ceny! Spróbuj jeszcze raz!\nPamiętaj, że grosze wydzielamy kropką np. 8.99 a nie 8,99!\n" + ex.Message);

            }
            saldoTextBox.Text = String.Format("{0:F2}", double.Parse(mainArray.getSaldo().ToString()));
        }

        //Init of main list
        private void listView_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = null;
            listView.ItemsSource = mainArray.Items; 
            saldoTextBox.Text = String.Format("{0:F2}", double.Parse(mainArray.getSaldo().ToString()));
        }

        //Export to XML
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Save.MakingXML(mainArray);
        }

        //Populating list from XML
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mainArray.Items = Save.FromXML("output.xml", mainArray);
            listView.ItemsSource = null;
            listView.ItemsSource = mainArray.Items;
            saldoTextBox.Text = String.Format("{0:F2}", double.Parse(mainArray.getSaldo().ToString()));
        }

        //Deleting selected items
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            foreach (Item item in listView.SelectedItems)
            { 
                //Money refund when deleted
                if (item.Cat.ToString() == "Przychód")
                    mainArray.setSaldo(mainArray.getSaldo() - double.Parse(item.Cost));
                else
                    mainArray.setSaldo(mainArray.getSaldo() + double.Parse(item.Cost));
                mainArray.Items.Remove(item);

                saldoTextBox.Text = String.Format("{0:F2}", double.Parse(mainArray.getSaldo().ToString()));
            }
            listView.ItemsSource = null;
            listView.ItemsSource = mainArray.Items;
        }

        public string setSaldoText
        {
            get { return saldoTextBox.Text; }
            set { saldoTextBox.Text = value; }
        }
    }
}
