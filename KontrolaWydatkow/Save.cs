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
        //public static List<Item> FromXML(string xml)
        //{
        //    using (StringReader stringReader = new StringReader(xml))
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        //        return (List<Item>)serializer.Deserialize(stringReader);
        //    }
        //}

        //public string ToXML<Item>(Item obj)
        //{
        //    using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Item));
        //        xmlSerializer.Serialize(stringWriter, obj);
        //        return stringWriter.ToString();
        //    }
        //}

        //DZIAŁAŁO
        //public static void MakingXML(List<Item> items)
        //{

        //        TextWriter Filestream = new StreamWriter("output.xml");
        //        new XmlSerializer(typeof(List<Item>)).Serialize(Filestream, items);
        //        Filestream.Close();   
        //}

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

            

            StreamReader reader = new StreamReader("output.xml");
            String input = reader.ReadToEnd();
            reader.Close();

            string pattern = "<[/]*Items>\r\n";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string output = rgx.Replace(input, replacement);


          //  String output = input.Replace("<[/]*Items>", "");
         //   output = input.Replace("</Items>", "");
              


            
            System.IO.File.WriteAllText("output.xml", output);

            //TextWriter Filestream = new StreamWriter("output.xml");
            //new XmlSerializer(typeof(List<Item>)).Serialize(Filestream, items);
            //Filestream.Close();
        }



        public static List<Item> FromXML(string xml, ArrayOfItems items)
        {
            List<Item> lstItem = null;
            double saldoValue = 0.00;
            try
            {
                XElement doc = XElement.Load(xml);

                // lstItem = doc.Elements("Item").Select(x =>
                //new Item
                //     (
                //         x.Element("Name").Value,
                //         x.Element("Cost").Value,
                //         (Item.Category)Enum.Parse(typeof(Item.Category), x.Element("Cat").Value),
                //         x.Element("Time").Value
                //     )
                //).ToList();

                lstItem = doc.Elements("Item").Select(x =>
            new Item
            {
                Name = x.Element("Name").Value,
                Cost = x.Element("Cost").Value,
                Cat = (Item.Category)Enum.Parse(typeof(Item.Category), x.Element("Cat").Value),
                Time = x.Element("Time").Value
            }
            ).ToList();

                //XElement doc = XElement.Load(xml);
                //IEnumerable<XElement> Items = doc.Descendants("Items");
                //foreach (var order in Items)
                //    lstItem.Add(new Item
                //    (
                //        order.Element("Name").Value,
                //        order.Element("Cost").Value,
                //        (Item.Category)Enum.Parse(typeof(Item.Category), order.Element("Cat").Value),
                //        order.Element("Time").Value
                //    )
                // );


                //Account.setSaldo(double.Parse(doc.Attribute("Saldo").Value));
                // doc.Elements("Item").Select(x =>saldoValue = double.Parse(x.Attribute("Saldo").Value));
                //saldoValue = double.Parse(doc.Attribute("Saldo").Value);

                //Zczytywanie saldo

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
