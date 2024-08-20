namespace cocult.Comands
{
    /// <summary>
    /// команда для вывода суммы площадей всех введенных кругов
    /// </summary>
    class ComandPrintSumSCircle : IComand,IExample
    {
        /// <summary>
        /// поле для хранения фигур
        /// </summary>
        ListFigure<Figure> listEnteredShapes;
        /// <summary>
        /// имя команды
        /// </summary>
        public string NameComand { get; set; }

        public ComandPrintSumSCircle(ListFigure<Figure> listEnteredShapes)
        {
            NameComand = "вывод_суммы_площадей_всех_введенных_кругов";
            this.listEnteredShapes = listEnteredShapes;
        }

        /// <summary>
        /// метод выполнения команды
        /// </summary>
        /// <param name="data">параметры задания</param>
        public void Execute(string data)
        {
            Console.Clear();
            Console.WriteLine($"Сумма всех S кругов = {listEnteredShapes.SType<Circle>()}");
        }

        public string Example()
        {
            return $"{NameComand}  - находит сумму площадей всех введенных кругов";
        }
    }
}
