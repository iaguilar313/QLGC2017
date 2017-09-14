using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Asking user for input - integers
            Console.WriteLine("Enter two integers with the same number of digits");

            Console.WriteLine("Enter first integer:");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second integer:");
            int y = int.Parse(Console.ReadLine());

            //used this to test code bellow 
            // int x = 123456789;
            // int y = 987654321;


            //converting int to string to find length user input

            string Numbx = Convert.ToString(x);

            string Numby = Convert.ToString(y);


            //checking that userinput integers match number of digits 
            while (Numbx.Length != Numby.Length)
            {
                Console.WriteLine("Error. Please enter two differnt integers with same number of digits.");

                Console.WriteLine("Enter first integer:");
                x = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second integer:");
                y = int.Parse(Console.ReadLine());

                //covert int to string again 
                Numbx = Convert.ToString(x);

                Numby = Convert.ToString(y);
            }
            //lenx and leny are variables 
            // created to determine lenght of 
            //used string lenght function 
            //converted strings

            int lenx = Numbx.Length;
            int leny = Numby.Length;

            Console.WriteLine("First number is:");
            Console.WriteLine(x);

            Console.WriteLine("Second number is:");
            Console.WriteLine(y);

            //C# missing exponent function , created one 

            int exp(int num1, int num2)
            {
                int counter = 1;
                int sol = num1;
                while (counter < num2)
                {
                    //loop to multiply "num1" by itself "num2" times
                    sol = sol * num1;
                    counter = counter + 1;
                }
                //returning exponent
                return sol;
            }
            //created function check indvidual digits to compare sums in respective
            //place (one, tens, hundreds, etc.) 
            bool Check(int a, int b)
            {
                //introduced variables from user input,isolated variables,

                int newx = 0, newy = 0, fx = 0, fy = 0, newz = 0;

                //isolates frist digit ( first digit on the left) 
                newx = x;
                fx = newx / exp(10, lenx - 1);
                lenx = lenx - 1;

                // isolates first digit from second input ( first digit on the left)
                newy = y;
                fy = newy / exp(10, leny - 1);
                leny = leny - 1;

                //sums of the first digits isolated above 
                int z = fx + fy;

                //Loops through the next digits and compares sums to the first sum from above
                // if it returns false then it prints outs false if true exits loops
                while (lenx > 1)
                {
                    newx = x % exp(10, lenx);
                    fx = newx / exp(10, (lenx - 1));
                    lenx = lenx - 1;

                    newy = y % exp(10, leny);
                    fy = newy / exp(10, (leny - 1));
                    leny = leny - 1;

                    newz = fx + fy;

                    //if sums of previous digits don't match with next set of digits return false and exit loop 
                    if (z != newz)
                    {
                        return false;
                    }

                }
                // checks final digit it both user inputs, previous loops can't check last number 
                // they work when int is greater than one 
                // checks input when lenght of int is equal to 1
                if (lenx == 1)
                {
                    newz = (x % 10) + (y % 10);
                    //if last number doesn't match first sum prints out false 
                    if (z != newz)
                    {
                        return false;
                    }
                }
                //succesfully went through all conditions in loops, returns true
                return true;
            }
            //calls above function bool function check,prints out true!!
            // celebrate !!
            Console.WriteLine(Check(x, y));

        }

    }
}
