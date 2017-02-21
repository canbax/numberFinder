using System;
using System.Collections.Generic;

namespace BirIslem
{
    class Program
    {
        static Random r = new Random();
        static int aim_int = -1;
        static int trial_count = 0;
        static List<int> nums = new List<int>();
        static string[] num_arr;

        static void printNums()
        {
            Console.WriteLine();
            Console.Write("[ ");
            for (int i = 0; i < nums.Count; i++)
            {
                if (i == nums.Count - 1)
                {
                    Console.WriteLine(nums[i] + " ]");
                }
                else
                {
                    Console.Write(nums[i] + ", ");
                }
            }
        }

        static bool doesEnd(int val)
        {
            return val == aim_int;
        }

        static bool runAlgo()
        {
             
            int ind1 = r.Next(nums.Count);
            int num1 = nums[ind1];

            nums.RemoveAt(ind1);

            int ind2 = r.Next(nums.Count);
            int num2 = nums[ind2];

            nums.RemoveAt(ind2);

            int new_num = makeOperation(num1, num2);
            nums.Add(new_num);
            
            if (doesEnd(new_num))
            {
                Console.WriteLine("\nfounded !");
                return true;
            }else if (nums.Count == 1)
            {
                Console.WriteLine("\ntrial no: " + trial_count);
                makeNumList();
            }
            trial_count++;
            return false;
        }

        static int makeOperation(int num1, int num2)
        {
            int res;
            int switch_on = r.Next(4);

            switch (switch_on)
            {
                case 0:
                    res = num1 + num2;
                    Console.Write(" " + num1 + " + " + num2 + " = " + res);
                    break;
                case 1:
                    if (num1 >= num2)
                    {
                        res = num1 - num2;
                        Console.Write(" " + num1 + " - " + num2 + " = " + res);
                    }
                    else
                    {
                        res = num1 + num2;
                        Console.Write(" " + num1 + " + " + num2 + " = " + res);
                    }
                    break;
                case 2:
                    res = num1 * num2;
                    Console.Write(" " +  num1 + " x " + num2 + " = " + res);
                    break;
                case 3:
                    if ( (num1 > num2) && (num2 > 0) && (num1 % num2 == 0))
                    {
                        res = num1 / num2;
                        Console.Write(" " + num1 + " : " + num2 + " = " + res);
                    }
                    else
                    {
                        res = num1 + num2;
                        Console.Write(" " + num1 + " + " + num2 + " = " + res);
                    }
                    break;
                default:
                    res = num1 + num2;
                    break;
            }
            
            return res;
        }

        static void makeNumList()
        {
            nums = new List<int>();

            for (int i = 0; i < num_arr.Length; i++)
            {
                nums.Add(int.Parse(num_arr[i]));
            }
        }

        static int getPossiblityCount()
        {
            int num = num_arr.Length;
            int num2 = num - 1;

            return fac(num) * fac(num2);
        }

        static int fac(int num)
        {
            int res = 1;
            for (int i = 1; i <= num; i++)
            {
                res = res * num;
            }
            return res;
        }

        static void Main(string[] args)
        {
            char restarter_ch = 'y';
            while(restarter_ch == 'y')
            {

                Console.WriteLine("enter the aim");
                aim_int = int.Parse(Console.ReadLine());

                Console.WriteLine("enter the numbers with spaces");
                num_arr = Console.ReadLine().Split(' ');

                makeNumList();

                printNums();

                //char searcher_ch = 'y';
                //while (searcher_ch == 'y')
                //{
                //    for (int i = 0; i < getPossiblityCount(); i++)
                //    {
                //        if (runAlgo())
                //        {
                //            break;
                //        }
                //    }
                //    Console.WriteLine("\n:( search again: y ?");
                //    searcher_ch = Console.ReadKey().KeyChar;
                //}
                while (!runAlgo()) ;

                Console.WriteLine("\n:( restart the program: y ?");
                restarter_ch = Console.ReadKey().KeyChar;
            }
        }


    }
}
