namespace PhoneBook.Commands
{
    public class PrintAllCommand : CommandBase
    {
        public PrintAllCommand(CommandLoop loop) : base(loop, 0) { }

        protected override void ExecuteByParams(string[] parameters)
        {
            if (Loop.Model.Entries.Count == 0)
            {
                WriteError("Записей не найдено");
                return;
            }
            WriteLine("Найдены записи: ");
            foreach (var entry in Loop.Model.Entries)
            {
                WriteLine(entry.ToString());
            }
        }
    }
}
