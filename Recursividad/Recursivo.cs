using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibo_factorial.Recursividad
{
    public class Recursivo
    {
        public int fibonacci(int number)
        {
            if (number < 2)
            {
                return 1;
            }
            else 
            {
                return fibonacci(number - 1) + fibonacci(number - 2);
            }
        }

        public int factorial(int number) 
        {
           if (number == 0)
                return 1;
            else 
                return number * factorial(number - 1);
        }
    }
}
