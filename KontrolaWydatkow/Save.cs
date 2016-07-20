using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ExpenseManager
{
    class Save
    {

        public static void MakingXML(ArrayOfItems items)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (var writer = XmlWriter.Create("output.xml", settings))
            {
                var serializer = new XmlSerializer(typeof(ArrayOfItems));
                serializer.Serialize(writer, items);
                writer.Close();
            }

            //I tried to fight with XML Serialization to delete not needed 
            //elements, but I gave up and implemented this dumb way
            //of dealing with XML formatting :P
            StreamReader reader = new StreamReader("output.xml");
            String input = reader.ReadToEnd();
            reader.Close();

            string pattern = "<[/]*Items>\r\n";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string output = rgx.Replace(input, replacement);

            System.IO.File.WriteAllText("output.xml", output);
        }



        public static List<Item> FromXML(string xml, ArrayOfItems items)
        {
            List<Item> lstItem = null;
            double saldoValue = 0.00;
            try
            {
                XElement doc = XElement.Load(xml);
                lstItem = doc.Elements("Item").Select(x =>
            new Item
            {
                Name = x.Element("Name").Value,
                Cost = x.Element("Cost").Value,
                Cat = (Item.Category)Enum.Parse(typeof(Item.Category), x.Element("Cat").Value),
                Time = x.Element("Time").Value
            }
            ).ToList();

                XDocument doc2 = XDocument.Load(xml);
                XElement root = doc2.Root;    

                saldoValue = double.Parse(root.Attribute("mySaldo").Value);

                items.setSaldo(saldoValue);

            }
            catch (IOException e)
            {
                MessageBox.Show("Wystąpił błąd! Najprawdopodobniej plik źródłowy nie istnieje. \nDokładny kod błędu: \n " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd! \nDokładny kod błędu: \n " + e.Message);
            }

            return lstItem;
        }
    }
}
