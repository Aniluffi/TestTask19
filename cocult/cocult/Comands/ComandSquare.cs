namespace cocult.Comands
{
    /// <summary>
    /// команда для нахождения периметра или площади квадрата
    /// </summary>
    class ComandSquare : IComand,IExample
    {
        /// <summary>
        /// поле для хранения фигур
        /// </summary>
        ListFigure<Figure> listEnteredShapes;
        /// <summary>
        /// имя команды
        /// </summary>
        public string NameComand { get; set; }

        public ComandSquare(ListFigure<Figure> listEnteredShapes)
        {
            NameComand = "квадрат";
            this.listEnteredShapes = listEnteredShapes;
        }

        /// <summary>
        /// метод выполнения команды
        /// </summary>
        /// <param name="data">параметры задания</param>
        public void Execute(string data)
        {
            Console.Clear();
            Square sq = new Square(ToParametrs(data));

            listEnteredShapes.Add(sq);

            Console.WriteLine("Вы желаете найти S(1) или P(2)");

            int comand = Convert.ToInt32(Console.ReadLine());

            if (comand == 1) Console.WriteLine($"S = {sq.S()}");
            else if (comand == 2) Console.WriteLine($"P = {sq.P()}");
        }

        /// <summary>
        /// метод для преобразования строки в параметры для фигур
        /// </summary>
        /// <param name="parametr"></param>
        /// <returns></returns>
        private List<int> ToParametrs(string parametr)
        {
            return parametr.Split().Where(t => int.TryParse(t, out int d)).Select(t => Convert.ToInt32(t)).ToList();
        }

        public string Example()
        {
            return $"{NameComand} - находит сумму или периметр квадрата" +
                $"\nОписание: вы должны ввести данные квадрата,после чего на экране появляется выбор нахождения площади или периметра " +
                $"\nПример:{NameComand} 12";
        }
    }
}
