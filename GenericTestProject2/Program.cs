using System;

namespace GenericTestProject2
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER to start");
            Console.ReadKey();

            var result = new Result<int, string> { Success = true, Data1 = 10, Data2 = "valor" };
            var result2 = new Result<int, int> { Success = true, Data1 = 10, Data2 = 1 };

            ResultPrinter.Print(result);
            ResultPrinter.Print(result2);

            Console.WriteLine("Press ENTER to finish");
            Console.ReadKey();

        }
    }

    public sealed class Result<T, U>
    {
        public bool Success { get; set; }
        public T Data1 { get; set; }
        public U Data2 { get; set; }
    }

    public static class ResultPrinter
    {
        public static void Print<T,U>(Result<T,U> result)
        {
            Console.WriteLine(result.Success);
            Console.WriteLine(result.Data1);
            Console.WriteLine(result.Data2);
        }
    }
}
