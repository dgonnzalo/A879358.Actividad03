using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace A879358.Actividad03
{
    class Cuentas

    {

        int nroDeCuenta;
        string nombreDeCuenta;
        string tipoDeCuenta;
        //public List<int> asientosLigados = new List<int>();    //se crea con la finalidad de "levantar" el .txt del Punto 1 y usarlo para validar.
                                                        // dentro de esta lista se incorporarán todos los números de los asientos que
                                                        // están ligados a cada cuenta .
                                                        // Cada objeto ( o mejor dicho cada cuenta) tendrá su propia lista de asientos a los que está
                                                        // enlazada.

        public Cuentas(int nuevoIngresoDeNumeroDeCta, string nuevoIngresodeNombreDeCta, string nuevoIngresoDeTipoDeCta)

        {
            
            nroDeCuenta = nuevoIngresoDeNumeroDeCta;
            nombreDeCuenta = nuevoIngresodeNombreDeCta;
            
            if (nuevoIngresoDeTipoDeCta == "A")
            tipoDeCuenta = "ACTIVO";

            if (nuevoIngresoDeTipoDeCta == "P" )
            tipoDeCuenta = "PASIVO";

            if (nuevoIngresoDeTipoDeCta == "PN")
            tipoDeCuenta = "PATRIMONIO NETO";

        }

        public Cuentas(string linea )
                        
        {
            var arraydeLinea = linea.Split('|'); // Separo la linea según separación "|" FORMATO DE TXT PLAN DE CUENTAS: CODIGO | NOMBRE | TIPO
                       

            if (int.TryParse(arraydeLinea[0], out int CodigoCuentaint)) // El título "Codigo|Nombre|Tipo" me obliga a hacer un try parse.
                                                                        // si solo hago un parse me tira error en el código
            {
                
                    nroDeCuenta = CodigoCuentaint;
                    nombreDeCuenta = arraydeLinea[1].ToUpper();
                    tipoDeCuenta = arraydeLinea[2].ToUpper();
                
            }
                       
        }

        

        public int NumeroDeCuenta
        {
            get { return this.nroDeCuenta; }
            set { this.nroDeCuenta = value; }
        }

        

       
        public string NombreDeCuenta
        {
            get { return this.nombreDeCuenta; }
            set { this.nombreDeCuenta = value; }
        }

        public string TipoDeCuenta
        {
            get { return this.tipoDeCuenta; }
            set { this.tipoDeCuenta = value; }
        }

        
    }
}
