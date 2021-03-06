using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;

using DipaulTestTask.Interfaces;
using DipaulTestTask.Models;

namespace DipaulTestTask.Service
{
    public class DataStorageInXmlFile : ICompanyStorage
    {
        public class DataStructure
        {
            public List<Company> сompanies { get; set; } = new List<Company>();            
        }

        private string _FileName;
        public DataStorageInXmlFile() { }
        public DataStorageInXmlFile(string fileName) => _FileName = fileName;

        private DataStructure Data { get; set; } = new DataStructure();

        ICollection<Company> IStorage<Company>.Items => Data.сompanies;
        public void Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Файлы XML (*.xml)|*.xml",
                Title = "Открыть файл с данными"                
            };
            
            if(openFileDialog.ShowDialog() == true)
                _FileName = openFileDialog.FileName;
                

            if(!File.Exists(_FileName))
            {
                Data = new DataStructure();
                return;
            }

            using var file = File.OpenText(_FileName);
            if(file.BaseStream.Length==0)
            {
                Data = new DataStructure();
                return;
            }

            var serializer = new XmlSerializer(typeof(DataStructure));
            Data = (DataStructure)serializer.Deserialize(file);
        }

        public void SaveChanges()
        {
            using var file = File.CreateText(_FileName);
            var serializer = new XmlSerializer(typeof(DataStructure));
            serializer.Serialize(file, Data);
        }
    }
}
