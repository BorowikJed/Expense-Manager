using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public static void MakingXML(List<Item> items)
        {
            
                TextWriter Filestream = new StreamWriter("output.xml");
                new XmlSerializer(typeof(List<Item>)).Serialize(Filestream, items);
                Filestream.Close();   
        }
        
       

        public static List<Item> FromXML(string xml)
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

                //Account.setSaldo(double.Parse(doc.Attribute("Saldo").Value));
                doc.Elements("Item").Select(x =>

                    saldoValue = double.Parse(x.Attribute("Saldo").Value)
                    );
                Account.setSaldo(saldoValue);    
                
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
