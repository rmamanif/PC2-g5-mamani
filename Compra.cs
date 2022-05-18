using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC2
{
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
