using System;
using System.Collections.Generic;
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
    /// -rzutowanie ceny itemów na double
    /// -Wprowadzanie stanu mojego konta
    /// -edycja stanu konta, odejmowanie i dodawanie po wrzuceniu itemków
    /// -gdzieś trzymać ten stan konta (chyba w Settings czy coś można)
    /// -polimorfizmy, dziedziczenia? Czy warto?
    /// -zmiana źródłowego xmla
    /// -github
    /// </summary>
    public partial class MainWindow : Window
    {
        Main main = new Main();
        Save save = new Save();
        public MainWindow()
        {
            InitializeComponent();
            listView.ItemsSource = main.Items;
            
        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Item.Category)))
            {
                category.Items.Add(item);
            }
            category.SelectedIndex = -1;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            main.addItems(name.Text, cost.Text, (Item.Category)category.SelectedItem);

            listView.ItemsSource = null;
            listView.ItemsSource = main.Items;
        }

        private void listView_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = null;
            listView.ItemsSource = main.Items;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //save.ToXML<Item>(main.Items);
            save.MakingXML(main.Items);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            main.Items = Save.FromXML("output.xml");
            listView.ItemsSource = null;
            listView.ItemsSource = main.Items;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            foreach (Item item in listView.SelectedItems)
                main.Items.Remove(item);

            listView.ItemsSource = null;
            listView.ItemsSource = main.Items;
        }
    }
}
