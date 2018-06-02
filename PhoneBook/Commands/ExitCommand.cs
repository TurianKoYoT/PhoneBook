namespace PhoneBook.Commands
{
    public class ExitCommand : CommandBase
    {
        public ExitCommand(CommandLoop loop) : base(loop, 0){}

        protected override void ExecuteByParams(string[] parameters)
        {
            Loop.Break = true;
        }
    }
}
