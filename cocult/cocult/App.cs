using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using cocult.Comands;
using MessagePack;

namespace cocult
{
    enum Figurs : byte
    {
        Tringle,
        Circle,
        Square,
        Polygon,
        Rectengle
    }

    /// <summary>
    /// класс для работы с приложением
    /// </summary>
    class App
    {
        /// <summary>
        /// список для хранения данных о введенных фигурах 
        /// </summary>
        private ListFigure<Figure> _listEnteredShapes = new ListFigure<Figure>();

        /// <summary>
        /// список для хранения всех сохраненных файлов
        /// </summary>
        private List<string> _paths = new List<string>();

        /// <summary>
        /// лист для хранения команд
        /// </summary>
        private List<IComand> _comands = new List<IComand>();

        public App()
        {
            Reg();
        }

        /// <summary>
        /// метод который запускает программу
        /// </summary>
        public void Run()
        {
            while (true)
            {       
                Console.WriteLine("Введите действие:");
                string? comand = Console.ReadLine();
                string[] words;

                if (comand.Split(" ", 2).Length == 2 && comand != null)
                { 
                    words = comand.Split(" ", 2);
                    SearhComand(words[0], words[1]);
                } 
                else
                {
                    words = comand.Split(" ", 1);
                    SearhComand(words[0], "");
                }
            }
        }
        /// <summary>
        /// метод для поиска команды
        /// </summary>
        /// <param name="comand">команда</param>
        private void SearhComand(string comand, string parametrs)
        {
            var exComand = _comands.FirstOrDefault(t => t.NameComand == comand);

            if (exComand != null) exComand.Execute(parametrs);
            else
            {
                Console.Clear();
                Console.WriteLine("Ошибка в записи команды");
            }    
        }

        /// <summary>
        /// метод для регистрации команд
        /// </summary>
        private void Reg()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            _comands = assembly.GetTypes()
                .Where(t => typeof(IComand).IsAssignableFrom(t) && !t.IsInterface)
                .Where(t => typeof(IExample).IsAssignableFrom(t) && !t.IsInterface)
                .Select(t => Activator.CreateInstance(t, _listEnteredShapes) as IComand)
                .ToList();

            _comands.Add(new ComandHelp(_comands));
        }
    }
}
