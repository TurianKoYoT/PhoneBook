namespace PhoneBook
{
    public class PhonebookEntry
    {
        public string Phone { get; set; }

        public string Contact { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Phone, Contact);
        }
    }
}
