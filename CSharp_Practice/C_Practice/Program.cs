using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace C_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Data types
             * int - 32 bit signed
             * long - 64 bit signed
             * decimal - precision - 28 decimal values
             * double - 64 bit floating type - 14 is precision
             * float -32 bit floating value - 6 digits 
             * 
             * */

            int[] array = { 1, 2, 4, 9 };
            //Array.Sort(array);
            Array.Reverse(array);

            PrintArray(array,"Reverse");

            int[] srcArray = { 1, 2, 3 };

            int startIndex = 0;
            int length = 2;

            int[] destinationArray = new int[2];
            Array.Copy(srcArray, 1, destinationArray, startIndex, length);

            PrintArray(destinationArray,"Copy-1");

            Array anotherArray = Array.CreateInstance(typeof(int), 10);
            srcArray.CopyTo(anotherArray, startIndex);

            foreach (int i in anotherArray)
            {
                Console.WriteLine("{0} - {1}", "Copy-2",i);
            }

            //Find
            int[] arrayPredicate = { 1, 11, 21 };

            Console.WriteLine("Number greater than 10 - {0}", Array.Find(arrayPredicate, IsGreaterThan10));
            //FindAll
            //Index

            //String Builder
            StringBuilder sb = new StringBuilder("Hi Usha", 256);
            sb.AppendLine("\nMore important text in next line");

            CultureInfo usEn = CultureInfo.CreateSpecificCulture("en-US");
            String bestCustomer = "Usha Vinnakota";

            sb.AppendFormat(usEn, "Best Customer is {0}", bestCustomer);
            Console.WriteLine("String builder is {0}", sb.ToString());

            sb.Replace("Usha", "Ushaswini");
            Console.WriteLine("String builder is {0}", sb.ToString());

            sb.Clear();
            Console.WriteLine("String builder is {0}", sb.ToString());

            sb.Append("Hi Usha");
            sb.Insert(7, "swini");
            Console.WriteLine("String builder is {0}", sb.ToString());

            sb.Remove(7, 5);
            Console.WriteLine("String builder is {0}", sb.ToString());


            Console.WriteLine("Using out variable");
            int solution;
            DoubleIt(5, out solution);
            Console.WriteLine("Value after doubling {0}", solution);

            Console.WriteLine("Using params");
            Console.WriteLine("1+2+3 = {0}", UseParams(1, 2, 3));
            Console.WriteLine("1+2+3+4 = {0}", UseParams(1, 2, 3, 4));

            Console.WriteLine("Using optional parameters");
            GetSum();

            Console.WriteLine("Using enums");
            CarColor car1 = CarColor.Green;
            PrintCarColor(car1);

            Console.WriteLine("Using struct");
            Rectangle rect1;
            rect1.length = 100;
            rect1.width = 10;
            Console.WriteLine("Area is {0}", rect1.GetRectArea());

            Rectangle rect2 = new Rectangle(10, 20);
            rect2 = rect1;
            //Pass by value
            rect1.length = 200;
            Console.WriteLine("rect1 length is {0} and rect2 length is {1}", rect1.length, rect2.length);

            Console.WriteLine("Using nullable data types");
            int? o = null;

            if(o == null)
            {
                Console.WriteLine("o is null");
            }

            if (!o.HasValue)
            {
                Console.WriteLine("o is null");
            }



            Console.ReadLine();

        }

        struct Rectangle
        {
           public double length;
           public double width;

           public Rectangle(double  length = 1, double width = 1)
            {
                this.length = length;
                this.width = width;
            }

            public double GetRectArea()
            {
                return length * width;
            }
        }
        //default would be int if byte is not specified
        enum CarColor : byte
        {
            Red  = 1,
            Blue,
            Green,
            Yellow,
            Black
        }

        static void PrintCarColor(CarColor cc)
        {
            Console.WriteLine("Car is printed with color {0} and code {1}", cc, (int)cc);
        }

        static void PrintArray(int[] array,string identifier)
        {
            foreach (int i in array)
            {
                Console.WriteLine("{0} - {1}", identifier,i);
            }
        }

        private static bool IsGreaterThan10(int val)
        {
            return val > 10;
        }

        //use out
        static void DoubleIt(int input,  out int solution)
        {
            solution = input * 2;
        }

       //use params
       static double UseParams(params double[] input)
        {
            double sum = 0;
            foreach(double i in input)
            {
                sum += i;
            }

            return sum;
        }

        static void GetSum(int x = 1, int y = 1 )
        {
            Console.WriteLine("x = {0}, y={1}", x, y);
        }

    }
}
