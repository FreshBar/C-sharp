using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.Write("Введите число: ");
            num = Convert.ToInt32(Console.ReadLine());
            
            int i;
            for (i=1; i <= num; i *= 2) ;
            i /= 2;
            for (; i >= 1; i /= 2)
            {
                if (num - i >= 0)
                {
                    Console.Write("1");
                    num = num - i;
                }
                else
                {
                    Console.Write("0");
                }
            }

            Console.Read();
           
        }
    }
}
