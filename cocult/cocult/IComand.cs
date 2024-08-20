using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocult
{

    /// <summary>
    /// интерфейс методов для класса Comands
    /// </summary>
    interface IComand
    {
        /// <summary>
        /// имя команды
        /// </summary>
        public string NameComand { get; set; }

        /// <summary>
        /// метод выполнения команды
        /// </summary>
        /// <param name="data">параметры команды</param>
        void Execute(string data);
    }
}
