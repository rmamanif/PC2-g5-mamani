using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Chain of Responsibility
            Aprobador jose = new Director();
            Aprobador sara = new VicePresidente();
            Aprobador marjorie = new Presidente();
            jose.SetSuccessor(sara);
            sara.SetSuccessor(marjorie);
            // Genera y procesa solicitudes de compras
            // Aprobado  por el director
            Compra p = new Compra(2034, 5000.00, "Recursos");
            jose.ProcesarSolicitud(p);
            // Aprobado por el vicepresidente
            p = new Compra(2037, 20000.00, "Proyecto Z");
            jose.ProcesarSolicitud(p);
            // Aprobado por el presidente
            p = new Compra(2035, 32590.10, "Proyecto X");
            jose.ProcesarSolicitud(p);
            p = new Compra(2036, 122100.00, "Proyecto Y");
            jose.ProcesarSolicitud(p);
            // Espera el input del usuario
            Console.ReadKey();
        }

        //Cadena de sucesor/Responsabilidad
        public abstract class Aprobador
        {
            protected Aprobador sucesor;
            public void SetSuccessor(Aprobador sucesor)
            {
                this.sucesor = sucesor;
            }
            public abstract void ProcesarSolicitud(Compra compra);
        }

        //Aprobación del director
        public class Director : Aprobador
        {
            public override void ProcesarSolicitud(Compra compra)
            {
                if (compra.Monto < 10000.0)
                {
                    Console.WriteLine("{0} aprobo la compra # {1} para {2} por S/.{3}",
                        this.GetType().Name, compra.Numero, compra.Razon, compra.Monto);
                }
                else if (sucesor != null)
                {
                    sucesor.ProcesarSolicitud(compra);
                }
            }
        }

        //Aprobación del vicepresidente
        public class VicePresidente : Aprobador
        {
            public override void ProcesarSolicitud(Compra compra)
            {
                if (compra.Monto < 25000.0)
                {
                    Console.WriteLine("{0} aprobo la compra # {1} para {2} por S/.{3}",
                        this.GetType().Name, compra.Numero, compra.Razon, compra.Monto);
                }
                else if (sucesor != null)
                {
                    sucesor.ProcesarSolicitud(compra);
                }
            }
        }

        //Aprobación del presidente
        public class Presidente : Aprobador
        {
            public override void ProcesarSolicitud(Compra compra)
            {
                if (compra.Monto < 100000.0)
                {
                    Console.WriteLine("{0} aprobo la compra # {1} para {2} por S/.{3}",
                        this.GetType().Name, compra.Numero, compra.Razon, compra.Monto);
                }
                else
                {
                    Console.WriteLine(
                        "Solicitud # {0} requiere de una reunión ejecutiva!",
                        compra.Numero);
                }
            }
        }

        public class Compra
        {
            int numero;
            double monto;
            string razon;

            //get-set de compra

            public Compra(int numero, double monto, string razon)
            {
                this.numero = numero;
                this.monto = monto;
                this.razon = razon;
            }
 
            public int Numero
            {
                get { return numero; }
                set { numero = value; }
            }

            public double Monto
            {
                get { return monto; }
                set { monto = value; }
            }
            public string Razon
            {
                get { return razon; }
                set { razon = value; }
            }
        }
    }

}

