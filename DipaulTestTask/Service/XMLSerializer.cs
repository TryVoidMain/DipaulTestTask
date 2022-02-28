using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DipaulTestTask.Models;

namespace DipaulTestTask.Service
{
    public class XMLSerializer
    {
        static void SaveAsXML(List<Company> companies, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Company>));
            Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            serializer.Serialize(stream, companies);
            stream.Close();
        }

        static List<Company> OpenXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Company>));
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<Company> companies = (List<Company>)serializer.Deserialize(stream);
            return companies;
        }
    }
}
