using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap1_LAB3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNum(50);
            
        }

        public static void RandomNum(int num)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Value: " + num);
            Random random = new Random((int) DateTime.Now.Ticks);
            for(int i = 0; i < num; i++)
            {
                int value = random.Next(100);
                numbers.Add(value);
                Console.WriteLine(value );
                
            }
            Console.WriteLine("Danh sach sau khi sap xep: ");
            numbers.Sort();
            foreach (int value in numbers)
            {
                Console.WriteLine(value + " ");
            }
            Console.ReadLine();
        }
    }
}
