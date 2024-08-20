using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocult
{
    /// <summary>
    /// интерфейс для обьединения команд,для которых требуется помощь
    /// </summary>
    interface IExample
    {
        /// <summary>
        /// метод для получения инструкции к команде
        /// </summary>
        /// <returns>инструкцию</returns>
        string Example();
    }
}
