using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace A879358.Actividad03
{
    class Program
    {
        
        static void Main(string[] args)
        {

            bool salida = false; // variable utilizada para salir del do
                        
            string nombreArchivo = @"C:\Users\pc\OneDrive - Facultad de Cs Económicas - UBA\Documentos\Actividad 03 - Plan de cuentas.txt";
            
            // C:\Users\pc\OneDrive - Facultad de Cs Económicas - UBA\Documentos  es la ruta donde se guardan los
            // tres documentos del módulo : Libro Diario / Mayor/ Plan de Cuentas

            string libroDiario = @"C:\Users\pc\OneDrive - Facultad de Cs Económicas - UBA\Documentos\Diario.txt";

            using (StreamReader reader = new StreamReader(nombreArchivo)) //creo un objeto que tiene el metodo de abrir el archivo y leer.
                                                                            // uso using para que se cierre el .txt cuando lo termino de usar
            {
                int contador = 1;
                while (!reader.EndOfStream) // !End of stream me permite recorrer todas las líneas del txt
                {
                                       
                    string linea = reader.ReadLine();

                    if (contador > 1) // el contador lo uso para que no me genere un objeto con el título
                    {
                        Cuentas cuenta = new Cuentas(linea);
                        Plan_de_Cuentas.planDeCuentasContable.Add(cuenta);
                    }
                    contador++;
                }

            }

            


            do
            {
                                                
                Console.Clear();

                Console.WriteLine("Sistema Contable ");
                Console.WriteLine(" 1. Ver Cuentas ");
                Console.WriteLine(" 2. Agregar Cuentas ");
                Console.WriteLine(" 3. Modificar Cuentas");
                Console.WriteLine(" 4. Eliminar Cuentas");
                Console.WriteLine(" 5. Salir");

                string opcion = Console.ReadLine();
                                
                switch (opcion)
                {
                    case "1":
                        {
                           Console.Clear();
                                                                                     
                           foreach(Cuentas item in Plan_de_Cuentas.planDeCuentasContable)
                           {
                            
                                Console.WriteLine(item.NumeroDeCuenta + "|" + item.NombreDeCuenta + "|" + item.TipoDeCuenta); // Refleja desde la lista ( OJO, NO DESDE EL TXT) , las cuentas
                                                                                                                              // que fueron creadas como un objeto y sus propiedades
                           
                           }
                                                                                                                   
                            Console.ReadKey();
                            break;

                        }
                    case "2":
                        {
                            Console.Clear();

                            bool repetido = false;
                            int nuevonumeroDeCuenta=0;
                            string nuevoNombreCuenta;
                            string nuevoTipoCuenta;

                            while (!repetido)
                            {
                                int encontrado = 0;
                                Console.WriteLine("Ingrese Numero de Cuenta");

                                nuevonumeroDeCuenta = Helper.validacionNumero();

                                foreach (Cuentas item in Plan_de_Cuentas.planDeCuentasContable)
                                {

                                    if (item.NumeroDeCuenta == nuevonumeroDeCuenta)
                                    {
                                        Console.WriteLine("Esta cuenta ya existe");
                                        encontrado = 1;
                                        break;
                                    }

                                }

                                if (encontrado == 0)
                                repetido = true;
                                                                
                            }

                            Console.WriteLine("Genial, ahora Ingrese Nombre de la Cuenta");
                            nuevoNombreCuenta = Console.ReadLine().ToUpper(); // ToDo: Agregar Validacion

                            repetido = false;

                            do
                            {

                                Console.WriteLine("Ingrese si es A ( Activo) , P ( Pasivo) o PN ( Si es Patrimonio Neto)");
                                nuevoTipoCuenta = Console.ReadLine().ToUpper();

                                if (!(nuevoTipoCuenta == "A" || nuevoTipoCuenta == "P" || nuevoTipoCuenta == "PN"))
                                {
                                    Console.WriteLine("Ingrese un tipo válido");
                                }

                                else
                                    repetido = true;
                               
                            } while (!repetido);
                     
                          
                            Plan_de_Cuentas.planDeCuentasContable.Add(new Cuentas(nuevonumeroDeCuenta, nuevoNombreCuenta, nuevoTipoCuenta));

                            Grabar();

                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            int ctaAModificar;
                            bool repetido = false;
                            
                            while (!repetido) // Primera Validacion para saber si existe o no esa cuenta para que sea modificada.
                            {
                                int encontrado = 0;
                                Console.WriteLine("Ingrese número de cuenta a Modificar");
                                ctaAModificar = Helper.validacionNumero();

                                foreach (Cuentas item in Plan_de_Cuentas.planDeCuentasContable)
                                {
                                    if (ctaAModificar == item.NumeroDeCuenta)
                                    {
                                        encontrado = 1;
                                        break;
                                    }

                                }
                                
                                if (encontrado == 1) // En caso de que la cuenta exista, se la trata de modificar. El =1 viene del foreach de la validación anterior.
                                                       // se trabajará sobre este IF.
                                {
                                    
                                    repetido = true; // Es la clave para salir del circuito infinito del WHILE

                                    foreach (Cuentas item in Plan_de_Cuentas.planDeCuentasContable) //nuevamente un foreach y utilizo mi variable cta a modificar
                                                                                                    // porque es el numero que me ingresó el usuario y está validad como existente
                                    {

                                        if (ctaAModificar == item.NumeroDeCuenta) // en caso de que el numero ingresado coincida con mi objeto :
                                        {

                                            Console.WriteLine("Usted Seleccionó: " + item.NumeroDeCuenta + "|" + item.NombreDeCuenta + "|" + item.TipoDeCuenta); //indico qué seleccionó

                                            Console.WriteLine("Desea Modificar Código? - S para modificar / cualquier tecla para seguir"); //opcion de modificado
                                            var tecla = Console.ReadKey(intercept: true);
                                                                                      

                                            if (tecla.Key == ConsoleKey.S)
                                            {
                                                Console.WriteLine("Ingrese nuevo número de cuenta");
                                                int modificador = Helper.validacionNumero();
                                                int validacion = 0;

                                                foreach (Cuentas item2 in Plan_de_Cuentas.planDeCuentasContable)
                                                {
                                                    if (modificador == item2.NumeroDeCuenta)
                                                    {
                                                        validacion = 1;

                                                    }

                                                }

                                                if (validacion == 1)
                                                    Console.WriteLine("La cuenta ya está siendo utilizada");
                                                else
                                                {
                                                    item.NumeroDeCuenta = modificador;
                                                    Console.WriteLine("Listo, cuenta modificada!");
                                                    break; // Este break lo necesito sí o sí. Si me llegan a cambiar el numero de la cuenta y dsps les permito cambiar el nombre,
                                                            // el código se rompería ya que no me funcionaría el foreach para validar que
                                                            // ctaAModificar == item2.NumeroDeCuenta ==> pierdo la forma de encontrar por numero de código que es lo
                                                            //que me interesa .
                                                }
                                            }

                                            Console.WriteLine("Desea Modificar Nombre de la Cuenta? - S para modificar / cualquier tecla para seguir"); //opcion de modificado
                                            var tecla2 = Console.ReadKey(intercept: true);

                                            if (tecla2.Key == ConsoleKey.S)
                                            {
                                                
                                                string modificadorDeNombre;
                                                
                                                Console.WriteLine("Ingrese nuevo nombre de cuenta");
                                                
                                                modificadorDeNombre = Console.ReadLine().ToUpper();

                                                   
                                                
                                                
                                                foreach (Cuentas item2 in Plan_de_Cuentas.planDeCuentasContable)
                                                {
                                                    if (ctaAModificar == item2.NumeroDeCuenta)
                                                    {
                                                        item.NombreDeCuenta = modificadorDeNombre;
                                                        Console.WriteLine("Listo, cuenta modificada!");
                                                       
                                                    }

                                                }
                                                break; // si bien este break no afecta la búsqueda como el break del código, lo coloco para mantener el formato

                                            }

                                            Console.WriteLine("Desea Modificar tipo de la Cuenta? - S para modificar / cualquier tecla para seguir"); //opcion de modificado
                                            var tecla3 = Console.ReadKey(intercept: true);
                                            bool validacionTipo = false;
                                            
                                            if (tecla3.Key == ConsoleKey.S)
                                            {
                                                string modificadorDeTipo;

                                                do
                                                {

                                                    Console.WriteLine("Ingrese nuevo tipo de la cuenta. UTILICE: A = ACTIVO - P = PASIVO - PN = PATRIMONIO NETO ");
                                                    modificadorDeTipo = Console.ReadLine().ToUpper();

                                                    if (!(modificadorDeTipo == "A" || modificadorDeTipo == "P" || modificadorDeTipo == "PN"))
                                                        Console.WriteLine("Ingrese una opción válida");
                                                    else
                                                    {
                                                        if (modificadorDeTipo == "A")
                                                            modificadorDeTipo = "ACTIVO";

                                                        if (modificadorDeTipo == "P")
                                                            modificadorDeTipo = "PASIVO";

                                                        if (modificadorDeTipo == "PN")
                                                            modificadorDeTipo = "PATRIMONIO NETO";
                                                                                                                 
                                                        
                                                        validacionTipo = true;
                                                    }
                                                } while (!validacionTipo);
                                                
                                                foreach (Cuentas item3 in Plan_de_Cuentas.planDeCuentasContable)
                                                {
                                                    if (ctaAModificar == item3.NumeroDeCuenta)
                                                    {
                                                        item.TipoDeCuenta = modificadorDeTipo;
                                                        Console.WriteLine("Listo, cuenta modificada!");
                                                        
                                                    }

                                                }

                                                break; // si bien este break no afecta la búsqueda como el break del código, lo coloco para mantener el formato
                                            }

                                        }
                                    }
                                }

                                else
                                    Console.WriteLine("Esta cuenta no existe para que sea modificada");

                                Grabar();
                                Console.ReadKey();
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            int ctaAEliminar;
                            bool repetido = false;
                            bool aeliminar = false;


                            while (!repetido) // Primera Validacion para saber si existe o no esa cuenta en el plan de ctas para que sea eliminada
                            {
                                int encontrado = 0;
                                Console.WriteLine("Ingrese número de cuenta a Eliminar");
                                ctaAEliminar = Helper.validacionNumero();

                                foreach (Cuentas item in Plan_de_Cuentas.planDeCuentasContable)
                                {
                                    if (ctaAEliminar == item.NumeroDeCuenta)
                                    {
                                        encontrado = 1;
                                        break;
                                    }
                                    
                                }
                                
                                if (encontrado == 0)
                                    Console.WriteLine("Cuenta inexistente");


                                if (encontrado == 1)
                                {
                                    repetido = true;


                                    using (StreamReader reader = new StreamReader(libroDiario)) // cada vez que decide eliminar una cuenta, necesito hacer
                                                                                                // validaciones sobre un .txt actualizado. Por eso
                                                                                                // siempre abro el archivo cada vez que el usuario
                                                                                                // quiera eliminar alguna cuenta en particular.
                                                                                                // No es necesario usar el mayor para validar, con el libro diario
                                                                                                // unicamente ya voy a poder impedir que me borren una cuenta
                                                                                                // que está siendo utilizada. Contablemente esto no debería
                                                                                                // ocurrir, porque quedarían asientos vacíos
                                                                                                // sin una cuenta asociada y generaría que los asientos
                                                                                                // queden desbalanceados debe <> haber cuando debería ser
                                                                                                // debe = haber.
                                    {

                                        while (!reader.EndOfStream)
                                        {
                                            string linea = reader.ReadLine();

                                            var arraydeLinea = linea.Split('|'); //FORMATO DEL LIBRO DIARIO NROASIENTO | FECHA      | CODIGOCUENTA|DEBE  | HABER
                                                                                 // EJEMPLO:                     105   | 06/05/2021 | 11          | 1000 |   0  
                                                                                 //                              105   | 06/05/2021 | 25          | 0    | 1000

                                            if (int.TryParse(arraydeLinea[2], out int validacion1))
                                            {
                                                if (validacion1 == ctaAEliminar)
                                                {
                                                    aeliminar = true ;
                                                }

                                            }


                                        }

                                        if (aeliminar)
                                            Console.WriteLine("No se puede eliminar esta cuenta ya que está siendo utilizada en asientos");
                                        
                                        if (!aeliminar)
                                        {
                                            for (int i = 0; i < Plan_de_Cuentas.planDeCuentasContable.Count(); i ++)  // Necesito un for para eliminar ese objeto
                                            {
                                                if (Plan_de_Cuentas.planDeCuentasContable[i].NumeroDeCuenta == ctaAEliminar)
                                                    Plan_de_Cuentas.planDeCuentasContable.Remove( Plan_de_Cuentas.planDeCuentasContable[i]);

                                            }
                                            Console.WriteLine("Cuenta Eliminada");
                                        }
                                   
                                    
                                    }
                                }

                                Grabar();
                            }

                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        {
                            salida = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ingrese una opción válida");
                            Console.ReadKey();
                            break;
                        }
                }

            } while (!salida);





            void Grabar() // guardo el documento del plan de cuentas 
            {
                using (var writer = new StreamWriter(nombreArchivo, append: false))
                {
                    foreach (Cuentas item in Plan_de_Cuentas.planDeCuentasContable)
                    {
                        var linea = $" {item.NumeroDeCuenta} | {item.NombreDeCuenta} | {item.TipoDeCuenta} ";
                                              
                        writer.WriteLine(linea.ToUpper());

                    }
                }
            }





        }
      
    }
}
