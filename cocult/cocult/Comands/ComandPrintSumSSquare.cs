﻿namespace cocult.Comands
{
    /// <summary>
    /// команда для вывода суммы площадей всех введенных квадратов квадратов
    /// </summary>
    class ComandPrintSumSSquare : IComand,IExample
    {
        /// <summary>
        /// поле для хранения фигур
        /// </summary>
        ListFigure<Figure> listEnteredShapes;
        /// <summary>
        /// имя команды
        /// </summary>
        public string NameComand { get; set; }

        public ComandPrintSumSSquare(ListFigure<Figure> listEnteredShapes)
        {
            NameComand = "вывод_суммы_площадей_всех_введенных_квадратов";
            this.listEnteredShapes = listEnteredShapes;
        }

        /// <summary>
        /// метод выполнения команды
        /// </summary>
        /// <param name="data">параметры задания</param>
        public void Execute(string data)
        {
            Console.Clear();
            Console.WriteLine($"Сумма всех S квадратов = {listEnteredShapes.SType<Square>()}");
        }

        public string Example()
        {
            return $"{NameComand}  - находит сумму площадей всех введенных квадратов";
        }
    }
}
