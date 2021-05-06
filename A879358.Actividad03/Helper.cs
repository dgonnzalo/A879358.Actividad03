using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A879358.Actividad03
{
    class Helper
    {
        

        public static int validacionNumero(int max , int min)
        {
            bool validacion = false;
            int a;
            do
            {
                
                if (!int.TryParse(Console.ReadLine(), out a))
                    Console.WriteLine("Ingrese un numero correcto");
                else if (a > max || a < min)
                    Console.WriteLine("Su número no es una opción");
                else
                    validacion = true;

            } while (!validacion);
            return a;
        }

        public static int validacionNumero()
        {
            bool validacion = false;
            int a;
            do
            {

                if (!int.TryParse(Console.ReadLine(), out a))
                    Console.WriteLine("Ingrese un numero correcto");
                else if ( a < 0)
                    Console.WriteLine("Su número no es una opción");
                else
                    validacion = true;

            } while (!validacion);
            return a;
        }

    }
}
