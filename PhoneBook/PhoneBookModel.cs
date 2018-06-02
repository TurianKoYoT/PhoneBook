using System.Collections.Generic;

namespace PhoneBook
{
    public class PhonebookModel
    {
        public PhonebookModel()
        {
            Entries = new List<PhonebookEntry>();
        }

        public List<PhonebookEntry> Entries { get; set; }
    }
}
