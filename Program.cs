namespace Laba5_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (IsStringValid(input))
            {
                var array = ToArray(input);
                var changedArray = ChangeArray(array);

                foreach(var item in changedArray)
                    Console.WriteLine(item);
                Console.WriteLine("Начальный массив: ");

                foreach(var item in array)              
                    Console.WriteLine(item);             
                Console.WriteLine("Работа завершена.");
            }
            else
                Console.WriteLine("Некорректный ввод.");
        }

        private static bool IsStringValid(string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]) && input[i] != ' ' && input[i] != ',' && input[i] != '-')              
                    return false;                
            }

            return true;
        }

        private static double[] ToArray(string input)
        {
            string[] elements = input.Split(" ");
            double[] parsed = new double[elements.Length];
            for (int i = 0; i < elements.Length; i++)
                parsed[i] = double.Parse(elements[i]);   
            return parsed;
        }

        private static double[] ChangeArray(double[] array)
        {
            double[] newArray = new double[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                if (IsInteger(array[i]) && IsPositive(array[i]))
                    newArray[i] = Factorial(array[i]);
                else if (IsInteger(array[i]) && !IsPositive(array[i]))
                    newArray[i] = array[i];
                else 
                    newArray[i] = RoundedPart(array[i]);
            }
            return newArray;
        }

        private static double Factorial(double n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        private static double RoundedPart(double number)
        {
            number = Math.Round(number, 2);
            string[] parts = (number.ToString()).Split(',');
            return double.Parse(parts[1]);
        }

        private static bool IsInteger(double number)
        {
            return number == (int)number;
        }

        private static bool IsPositive(double number)
        {
            return number > 0;
        }
    }
}