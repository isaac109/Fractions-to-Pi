using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Time to aproximate Pi. Which method would you like to use?\n (1) Libnids \n (2) Oiler"+ 
                    "\n (3) Prime Numbers\n (4) Exit\n Please enter the number of the method you would like to use.");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 4)
                {
                    break;
                }
                Console.WriteLine("How many fractions would you like to use?");
                int fractionNum = Convert.ToInt32(Console.ReadLine());
                choice--;
                fractionNum++;
                switch (choice)
                {
                    case 0:
                        libnids(fractionNum);
                        break;
                    case 1:
                        oilers(fractionNum);
                        break;
                    case 2:
                        primeNum(fractionNum);
                        break;
                }
                
                Console.WriteLine("There is your approximation.");
                String temp = Console.ReadLine();
            }
        }

        // By adding all taking an infinite number of odd numbers, dividing 1 by that number, and sequentialy adding
        // and subtracting them, you get Pi/4
        // eg: (1/1)-(1/3)+(1/5)...(1/n) ~ Pi/4
        static void libnids(int fractionsNum)
        {
            List<double> oddFractions = new List<double>();
            for (int i = 0; i < fractionsNum; i++)
            {
                if (i % 2 != 0)
                {
                    oddFractions.Add((double)(1) / (double)(i));
                }
                else
                {
                    fractionsNum++;
                }
            }
            double total = 0;
            for (int i = 0; i < oddFractions.Count; i++)
            {
                if (i % 2 != 0)
                {
                    total -= oddFractions[i];
                }
                else
                {
                    total += oddFractions[i];
                }
            }
            total *= 4;
            Console.WriteLine(total);
        }

        //By taking an infinite set of numbers, squaring them, dividing 1 by each number, and adding them together
        // you get (Pi^2)/6
        // eg. (1/1) + (1/4) + (1/9) ... + (1/n^2) ~ (Pi^2)/6
        static void oilers(int fractionsNum)
        {
            List<double> fractions = new List<double>();
            for (int i = 1; i < fractionsNum+1; i++)
            {
                int temp = i * i;
                fractions.Add((double)(1) / (double)(temp));
            }
            double total = 0;
            foreach (double item in fractions)
            {
                total += item;
            }
            total *= 6;
            total = Math.Sqrt(total);
            Console.WriteLine(total);
        }

        //By taking an infinite number of prime numbers, excluding 2, divide 1 by each number
        //if the number is 1 more than a multipe of 4 (like 5 and 13) make them positive,
        //if it is not make it a negative fraction, place add 1 to every fraction, and multiply them all together
        // you recieve 2/Pi
        //eg: (1-1/3)x(1+1/5)x(1-1/7)x(1-1/11)...(1(+/-)1/n) ~ 2/Pi
        static void primeNum(int fractionsNum)
        {
            List<double> primes = new List<double>();
            for (int i = 3; i < fractionsNum+3; i++)
            {
                if (isPrime(i))
                {
                    primes.Add(i);
                }
                else
                {
                    fractionsNum++;
                }
            }
            double total = 1;
            for (int i = 0; i < primes.Count; i++)
			{
                if ((primes[i] - 1) % 4 != 0)
                {
                    primes[i] *= -1;
                }
                primes[i] = 1 / primes[i];
                primes[i] += 1;
                total *= primes[i];
			}

            total = 2 / total;

            Console.WriteLine(total);
        }

        static bool isPrime(int number)
        {
            int boundry = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= boundry; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
