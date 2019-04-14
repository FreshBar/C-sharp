using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transfer
{
    class Program
    {
        static char give_num_symb(int num)
        {
            return (num < 10) ? (char)(num + '0') : (char)('A' + num - 10);
        }


        static void Main(string[] args)
        {
            int num_base;
            int num;
            Console.Write("Введите число: ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите систему счисления от 2 до 36: ");
            num_base = Convert.ToInt32(Console.ReadLine());

            if (num_base < 2 || num_base > 36)
            {
                Console.WriteLine("Неправильная система счисления!");
                Console.Read();
                return;
            }
            int i;
            for (i = 1; i <= num; i *= num_base) ;
            i /= num_base;
            for (; i >= 1; i /= num_base)
            {
                int k;
                for (k = num_base - 1; k > 0; k--)
                {
                    if (k * i <= num)
                        break;
                }
                num -= i * k;
                Console.Write((char)(give_num_symb(k)));
            }
            Console.Read();
        }
    }
}
