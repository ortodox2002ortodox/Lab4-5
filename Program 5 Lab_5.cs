using System;
using System.Numerics;
namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            testSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
            testSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));
            MyFrac[] fracs = new MyFrac[10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                fracs[i] = new MyFrac(rand.Next(-100, 100), rand.Next(-100,100));
            }
            Array.Sort(fracs);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(fracs[i]);
            }
        }
        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)=(a^2 - b^2) / (a + b) with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T calc = curr;
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            calc = calc.Subtract(curr); // a^2 - b^2
            Console.WriteLine("a^2 - b^2 = " + calc);
            curr = a.Add(b);
            Console.WriteLine("a + b = " + curr);
            calc = calc.Divide(curr);
            Console.WriteLine("(a^2 - b^2) / (a + b) = " + calc);

        }
    }
}