namespace Lab03_review
{
    public class Program
    {
        static void Main()
        {
            try
            {

                //Challenge 1 begin 
                Console.WriteLine("------------------------------------------------ Challenge 1 ------------------------------------------------");
                Console.Write("Please enter 3 numbers and make sure to insert a space between each of them: ");
                string? str = Console.ReadLine();
                int Product = ProbuctOf3Nums(str!);
                Console.WriteLine($"The product of these 3 numbers is: {Product}\n\n");
                //Challenge 1 ends 


                //Challenge 2 begin
                Console.WriteLine("------------------------------------------------ Challenge 2 ------------------------------------------------");
                int size;
                int[] num = PopulateAvgOfRandomSetOfNums(out size);
                double avg = AvgOfRandomSetOfNums(num);
                Console.WriteLine($"The average of these {size} numbers is: {avg}");
                //Challenge 2 ends

                //Challenge 3 begin
                Console.WriteLine("------------------------------------------------ Challenge 3 ------------------------------------------------\n");
                DisplayShape(9);
                //Challenge 3 ends

                //Challenge 4 begin
                Console.WriteLine("------------------------------------------------ Challenge 4 ------------------------------------------------\n");
                //int[] numbers = { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
                Console.Write("Please enter array elements you want to find most appears element: ");
                string? arr = Console.ReadLine()!;
                string[] arrElements = arr.Split(' ');

                int[] ints = new int[arrElements.Length];

                for (int i = 0; i < arrElements.Length; i++)
                {
                    int.TryParse(arrElements[i], out ints[i]);

                }
                int MostAppearsNumber = MostAppearsNumberInArray(ints);
                Console.WriteLine($"Most Appears Number In This Array is {MostAppearsNumber}");
                //Challenge 4 ends

                //Challenge 5 begin
                Console.WriteLine("------------------------------------------------ Challenge 5 ------------------------------------------------\n");
                //int[] numbers = { 5, 25, 99, 123, 78, 96, 555, 108, 4 };
                Console.Write("Please enter array elements you want to find max value element: ");
                string? arr2 = Console.ReadLine()!;
                if (arr2.Length < 1) throw new Exception("The array cannot be null!");
                string[] arrElements2 = arr2.Split(' ');

                int[] ints2 = new int[arrElements2.Length];

                for (int i = 0; i < arrElements2.Length; i++)
                {
                    int.TryParse(arrElements2[i], out ints2[i]);

                }
                int maxValue = MaxValueInArray(ints2);
                Console.WriteLine(maxValue);
                //Challenge 5 ends
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of challenges!");
            }
        }

        //Challenge 1
        public static int ProbuctOf3Nums(string str)
        {
            if (str.Length < 1) throw new Exception("The input cannot be null!");
            string[] Numbers = str.Split(' ');
            int result = 1;
            int[] ints = new int[Numbers.Length];

            for (int i = 0; i < Numbers.Length; i++)
            {
                if (!int.TryParse(Numbers[i], out ints[i]))
                {
                    ints[i] = 1;
                }
            }

            if (ints.Length < 3)
            {
                return 0;
            }
            if (ints.Length >= 3)
            {
                result = result * ints[0] * ints[1] * ints[2];

            }

            return result;

        }

        //Challenge 2
        public static double AvgOfRandomSetOfNums(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            return (double)sum / numbers.Length;
        }

        public static int[] PopulateAvgOfRandomSetOfNums(out int number)
        {

            Console.Write("Please enter a number between 2-10: ");
            do
            {
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out number) || number < 2 || number > 10)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (number < 2 || number > 10);

            int[] numbers = new int[number];
            for (int i = 0; i < number; i++)
            {
                bool option;
                int inputNumber;
                do
                {
                    Console.Write($"{i + 1} of {number} - Enter a number: ");
                    string? input = Console.ReadLine();
                    option = int.TryParse(input, out inputNumber);
                    if (!option || inputNumber < 0)
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                } while (!option || inputNumber < 0);
                numbers[i] = inputNumber;
            }
            return numbers;
        }

        //Challenge 3
        public static void DisplayShape(int n)
        {
            int spaces = n - 1;
            int stars = 1;


            for (int i = 0; i < n; i++)
            {
                DisplayShapeLines(spaces, stars);
                spaces--;
                stars += 2;
            }


            spaces = 1;
            stars = 2 * (n - 1) - 1;

            for (int i = 0; i < n - 1; i++)
            {
                DisplayShapeLines(spaces, stars);
                spaces++;
                stars -= 2;
            }
        }

        private static void DisplayShapeLines(int spaces, int stars)
        {
            Console.Write("    ");
            for (int i = 0; i < spaces; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < stars; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        //Challenge 4
        public static int MostAppearsNumberInArray(int[] numbers)
        {
            Dictionary<int, int> counts = new();

            foreach (int number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts[number] = 1;
                }
            }

            int maxCount = counts.Values.Max();
            int mostFrequentNumber = numbers[0];

            foreach (int number in numbers)
            {
                if (counts[number] == maxCount)
                {
                    mostFrequentNumber = number;
                    break;
                }
            }

            return mostFrequentNumber;
        }

        //Challenge 5
        public static int MaxValueInArray(int[] numbers)
        {
            if (numbers.Length <= 0)
                throw new Exception("The array cannot be empty.");


            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }
    }
}