using System;

namespace PhoneBook
{
    public class CommandLoop
    {
        public void DoLoop()
        {
            Break = false;
            while (!Break)
            {
                Console.WriteLine("Введите команду");
                var text = Console.ReadLine();
                var command = _factory.Create(this, text);
                if (command == null)
                {
                    Console.WriteLine("Команда не найдена");
                }
                else
                {
                    command.Execute(text);
                    Console.WriteLine();
                }
            }
        }

        private readonly CommandFactory _factory = new CommandFactory();

        public PhonebookModel Model { get; set; }

        public bool Break { get; set; }
    }
}
