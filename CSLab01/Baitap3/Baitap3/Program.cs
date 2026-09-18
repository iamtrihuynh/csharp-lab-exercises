using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the numbers of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter the {i}th  element: ");
                a[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            int small = int.MaxValue, big = int.MinValue;
            for (int i = 0; i < n; ++i)
            {
                sum += a[i];
            }

            Console.WriteLine("The sum of array is: " + sum);
            Console.WriteLine("The smallest element in the array is: " + a.Min());
            Console.WriteLine("The biggest element in the array is: " + a.Max());

        }
    }
}
