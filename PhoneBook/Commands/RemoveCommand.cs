using System.Linq;

namespace PhoneBook.Commands
{
    public class RemoveCommand : CommandBase
    {
        public RemoveCommand(CommandLoop loop) : base(loop, 1) { }

        protected override void ExecuteByParams(string[] parameters)
        {
            var text = parameters[0];
            var entry = Loop.Model.Entries.FirstOrDefault(e => e.Contact == text || e.Phone == text);
            if (entry == null)
            {
                WriteError("Запись не найдена");
                return;
            }
            Loop.Model.Entries.Remove(entry);
        }
    }
}
