using System;
using System.IO;
using System.Reflection;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Телефонный справочник";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Инструкция по работе.\nТелефонный справочник содержит 5 команд:\n1.Добавить Номер телефона Имя контакта.\n2.Найти Имя контакта или Номер телефона.\n3.Удалить. Полностью указать номер телефона или имя контакта.\n4.Просмотр. Для просмотра всех контактов ТС необходимо указать только саму команду.\n5.Выход. При выходе из программы вся информация сохраняется в файле,при не корректном выходе информация будет утеряна.\nДля реализации команды,в строке введите команду которую необходимо выполнить и необходимые параметры. \n");


            PhonebookModel model;
            if (File.Exists(_phonebookFileName))
            {
                try
                {
                    model = PhoneBookSerializer.LoadFromFile(_phonebookFileName);
                }
                catch (Exception ex)
                {
                    WriteException("Ошибка чтения файла телефонного справочника", ex);
                    model = new PhonebookModel();
                }
            }
            else
            {
                model = new PhonebookModel();
            }
            _loop.Model = model;

            try
            {
                _loop.DoLoop();
            }
            catch (Exception ex)
            {
                WriteException("Что то пошло не так...ошибка работы цикла", ex);
            }

            try
            {
                PhoneBookSerializer.WriteToFile(_phonebookFileName, _loop.Model);
            }
            catch (Exception ex)
            {
                WriteException("Что то пошло не так..ошибка сохранения телефонного справочника", ex);
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void WriteException(string header, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(header);
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static readonly string _phonebookFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Phobebook.xml");

        private static readonly CommandLoop _loop = new CommandLoop();
    }
}
