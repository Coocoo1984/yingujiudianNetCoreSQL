using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"DateTime.Now:{dt}");
            Console.WriteLine($"DateTime.Now.ToString():{dt.ToString()}");
            Console.WriteLine($"DateTime.Now.ToString(\"yyyy-MM-dd HH:mm:ss\"):{dt.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"DateTime.Now.ToString(\"yyyy-MM-dd hh:mm:ss\"):{dt.ToString("yyyy-MM-dd hh:mm:ss")}");
        }
    }
}
