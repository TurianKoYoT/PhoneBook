using System.Linq;

namespace PhoneBook.Commands
{
    public class SearchCommand : CommandBase
    {
        public SearchCommand(CommandLoop loop) : base(loop, 1) { }

        protected override void ExecuteByParams(string[] parameters)
        {
            var text = parameters[0];
            var entries = Loop.Model.Entries.Where(e => e.Contact.Contains(text) || e.Phone.Contains(text));
            if (entries.Count() == 0)
            {
                WriteError("Записей не найдено");
                return;
            }
            WriteLine("Найдены записи: ");
            foreach (var entry in entries)
            {
                WriteLine(entry.ToString());
            }
        }
    }
}
