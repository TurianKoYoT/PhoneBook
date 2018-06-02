using System.IO;
using System.Xml.Serialization;

namespace PhoneBook
{
    public static class PhoneBookSerializer
    {
        private static readonly XmlSerializer _xs = new XmlSerializer(typeof(PhonebookModel));

        public static void WriteToFile(string fileName, PhonebookModel model)
        {
            using (var fileStream = File.Create(fileName))
            {
                _xs.Serialize(fileStream, model);
            }
        }

        public static PhonebookModel LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (PhonebookModel)_xs.Deserialize(fileStream);
            }
        }
    }
}
