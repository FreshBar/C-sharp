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
        static int give_symb_num(char symb)
        {
            if (symb >= '0' && symb <= '9')
            {
                return (int)(symb - '0');
            }
            else
            {
                return (int)(symb - 'A' + 10);
            }

        }

        static string from_10_to_any(string s_num, int num_base)
        {
            int num = Convert.ToInt32(s_num);
            string s_num_out = "";
            int power;
            for (power = 1; power <= num; power *= num_base) ;
            power /= num_base;
            for (; power >= 1; power /= num_base)
            {
                int k;
                for (k = num_base - 1; k > 0; k--)
                {
                    if (k * power <= num)
                        break;
                }
                num -= power * k;
                s_num_out += (char)(give_num_symb(k));
            }
            return s_num_out;
        }   
        
               
        static string from_any_to_10(string s_num, int num_base)
        {   
         
            int size = s_num.Length - 1;
            int i, power = 1;
            int sum = 0;
            for (i = 0; i < size; i++)
            {
                power *= num_base;
            }
            for (i = 0; i <= size; i++)
            {

                int k = give_symb_num(s_num[i]) * power;
                sum += k;
                power /= num_base;

            }
        string s_num_out = Convert.ToString(sum);
        return s_num_out;
        }

        static string from_any_to_any(string s_num, int num_base_from, int num_base_to)
        {
            if(num_base_from == 10)
            {
                return from_10_to_any(s_num, num_base_to);
            }
            else if(num_base_to == 10)
            {
                return from_any_to_10(s_num, num_base_from);
            }
            else
            {
                return from_10_to_any(from_any_to_10(s_num, num_base_from), num_base_to);
            }
        }
                
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Перевод с одной системы счисления в другую");
                Console.Write("Введите число: ");
                string s_num = Console.ReadLine();
                Console.Write("Введите основание исходной системы: ");
                int num_base_from = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите основание конечной системы: ");
                int num_base_to = Convert.ToInt32(Console.ReadLine());
                               
                Console.WriteLine(from_any_to_any(s_num, num_base_from, num_base_to));
               
                
            }
        }
    }
}
