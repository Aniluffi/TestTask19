namespace cocult.Comands
{
    /// <summary>
    /// команда для нахождения периметра или площади прямоугольника
    /// </summary>
    class ComandTringle : IComand,IExample
    {
        /// <summary>
        /// поле для хранения фигур
        /// </summary>
        ListFigure<Figure> listEnteredShapes;
        /// <summary>
        /// имя команды
        /// </summary>
        public string NameComand { get; set; }

        public ComandTringle(ListFigure<Figure> listEnteredShapes)
        {
            NameComand = "треугольник";
            this.listEnteredShapes = listEnteredShapes;
        }

        /// <summary>
        /// метод выполнения команды
        /// </summary>
        /// <param name="data">параметры задания</param>
        public void Execute(string data)
        {
            Console.Clear();
            Triangle sq = new Triangle(ToParametrs(data));

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
            return $"{NameComand} - находит сумму или периметр треугольника" +
                $"\nОписание: вы должны ввести данные треугольника,после чего на экране появляется выбор нахождения площади или периметра " +
                $"\nПример: {NameComand} 12 13 12 или по точкам {NameComand} ( 4 ; 5 ) ( 7 ; 5 ) ( 6 ; 1 )";
        }
    }
}
