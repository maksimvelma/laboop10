using System;
using System.Linq;

namespace Lab_10
{
    class Overload
    {
        char[] element;
        char a, b, c, d;

        public Overload(char a, char b, char c, char d, int count)
        {
            element = new char[count];
            element[0] = a;
            element[1] = b;
            element[2] = c;
            element[3] = d;
        }

        public Overload(char a, char b, char c, char d, char f, int count)
        {
            element = new char[count];
            element[0] = a;
            element[1] = b;
            element[2] = c;
            element[3] = d;
            element[4] = f;
        }

        public static Overload operator -(Overload x, char y)
        {
            try
            {
                x.element = x.element.Except(new char[] { y }).ToArray();
                foreach (char i in x.element)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return x;
        }

        public static Overload operator *(Overload x, Overload y)
        {
            try
            {
                var result = x.element.Intersect(y.element);
                foreach (char s in result)
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return x;
        }

        public static Overload operator >(Overload x, Overload y)
        {
            try
            {
                if (x.element.Length > y.element.Length)
                {
                    foreach (char i in y.element)
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    Console.WriteLine("Цю операцiю не можливо застосувати, тому що, або 2 множини рiвнi або перша множина не бiльша за другу!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return x;
        }

        public static Overload operator <(Overload x, Overload y)
        {
            try
            {
                if (x.element.Length < y.element.Length)
                {
                    foreach (char i in y.element)
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    Console.WriteLine("Цю операцiю не можливо застосувати, тому що, або 2 множини рiвнi або перша множина не бiльша за другу!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Overload ov, ov1, ov2;
            ov1 = new Overload('a', 'b', 'q', 'c', 4);
            Console.WriteLine("Видалення елемента з множини: ");
            ov = ov1 - 'q';

            ov1 = new Overload('a', 'b', 'c', 'd', 4);
            ov2 = new Overload('z', 'c', 'm', 'a', 4);
            Console.WriteLine("Перетин множин: ");
            ov = ov1 * ov2;

            ov1 = new Overload('a', 'b', 'c', 'd', 4);
            ov2 = new Overload('z', 'c', 'm', 'a', 'q', 5);
            Console.WriteLine("Порiвняння множин: ");
            ov = ov1 < ov2;
        }
    }