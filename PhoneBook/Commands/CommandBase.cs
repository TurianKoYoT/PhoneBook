using System;
using System.Linq;

namespace PhoneBook.Commands
{
    public abstract class CommandBase : ICommand
    {
        private static readonly char[] _separator = new char[] { ' ' };

        protected CommandBase(CommandLoop loop, int paramsCount)
        {
            _paramsCount = paramsCount;
            _loop = loop;
        }

        private readonly int _paramsCount;
        private readonly CommandLoop _loop;

        protected CommandLoop Loop
        {
            get { return _loop; }
        }

        public void Execute(string text)
        {
            var strs = text.Split(_separator, _paramsCount + 1, StringSplitOptions.RemoveEmptyEntries);
            if (strs.Length != _paramsCount + 1)
            {
                WriteError(string.Format("Для выполнения команды требуется {0} параметров", _paramsCount));
                return;
            }
            var commandName = strs[0];
            if (strs.Length > 1)
            {
                ExecuteByParams(strs.Skip(1).ToArray());
            }
            else
            {
                ExecuteByParams(null);
            }
        }

        protected void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        protected abstract void ExecuteByParams(string[] parameters);
    }
}
