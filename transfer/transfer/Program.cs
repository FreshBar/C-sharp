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

        static void from_ten_to_others(int num_base)
        {
            string check;
            do
            {
                Console.Write("Введите число: ");
                int num = Convert.ToInt32(Console.ReadLine());

                int power;
                for (power = 1; power <= num; power *= num_base);
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
                    Console.Write((char)(give_num_symb(k)));
                }
                Console.Write("\nХотите продолжить (y/n) ? ");
                check = Console.ReadLine();
            } while (check != "n");

        }
        static void from_any_to_ten(int num_base)
        {
            Console.Write("Введите число: ");
            string s_num = Console.ReadLine();
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
            Console.WriteLine(sum);
        }
        static void from_16_to_2()
        {
            Console.Write("Введите число: ");
            string s_num = Console.ReadLine();

            int size = s_num.Length;
            int bit;
            int num = give_symb_num(s_num[0]);

            for (bit = 3; ((num >> bit) & 1) == 0; bit--);//пропускаем 0
            for(; bit >= 0; bit--)
            {
                char num_to_print = (char)(((num >> bit) & 1) + '0');
                Console.Write(num_to_print);
            }
            for(int i = 1; i <size; i++)
            {
                num = give_symb_num(s_num[i]);
                for (bit = 3; bit >= 0; bit--)
                {
                    char num_to_print = (char) (((num >> bit) & 1) + '0');
                    Console.Write(num_to_print);
                }
            }
            Console.WriteLine();
        }
        static void from_8_to_2()
        {
            Console.Write("Введите число: ");
            string s_num = Console.ReadLine();

            int size = s_num.Length;
            int bit;
            int num = give_symb_num(s_num[0]);

            for (bit = 2; ((num >> bit) & 1) == 0; bit--) ;
            for (; bit >= 0; bit--)
            {
                char num_to_print = (char)(((num >> bit) & 1) + '0');
                Console.Write(num_to_print);
            }
            for (int i = 1; i < size; i++)
            {
                num = give_symb_num(s_num[i]);
                for (bit = 2; bit >= 0; bit--)
                {
                    char num_to_print = (char)(((num >> bit) & 1) + '0');
                    Console.Write(num_to_print);
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int punkt;
                Console.WriteLine("Перевод с одной системы счисления в другую");
                Console.WriteLine("");
                Console.WriteLine("Выберите: ");
                Console.WriteLine("1: с 10 в 2 ");
                Console.WriteLine("2: с 10 в 8 ");
                Console.WriteLine("3: с 10 в 16 ");
                Console.WriteLine("4: с 2 в 8 ");
                Console.WriteLine("5: с 2 в 10 ");
                Console.WriteLine("6: с 2 в 16 ");
                Console.WriteLine("7: с 8 в 2 ");
                Console.WriteLine("8: с 8 в 10 ");
                Console.WriteLine("9: с 8 в 16 ");
                Console.WriteLine("10: с 16 в 2  ");
                Console.WriteLine("11: с 16 в 8 ");
                Console.WriteLine("12: с 16 в 10 ");

                punkt = Convert.ToInt32(Console.ReadLine());
                if (punkt == 1)
                {
                    from_ten_to_others(2);
                }
                if (punkt == 2)
                {
                    from_ten_to_others(8);
                }
                if (punkt == 3)
                {
                    from_ten_to_others(16);
                }
                if (punkt == 5)
                {
                    from_any_to_ten(2);
                }
                if (punkt == 7)
                {
                    from_8_to_2();
                }
                if (punkt == 8)
                {
                    from_any_to_ten(8);
                }
                if (punkt == 10)
                {
                    from_16_to_2();
                }
                if (punkt == 12)
                {
                    from_any_to_ten(16);
                }
            }
        }
    }
}
