namespace figures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину стороны квадрата:");
            string input = Console.ReadLine();

            double sideLength;
            if (double.TryParse(input, out sideLength))
            {
                try
                {
                    Square square = new Square(sideLength);

                    Console.WriteLine("Информация о квадрате:");
                    Console.WriteLine("Длина стороны: " + sideLength);
                    Console.WriteLine("Площадь: " + square.CalculateArea());
                    Console.WriteLine("Периметр: " + square.CalculatePerimeter());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите числовое значение.");
            }
        }
    }
}