using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3.Model
{
    internal class Multa : IImportable
    {
        public double Importe {  get; set; }
        public Multa() { }
        public Multa(double import)
        {
            Importe = import;
        }

        override public string ToString()
        {
            return $@"{Importe}";
        }

        public bool Importar(string xml)
        {
            throw new NotImplementedException();
        }
    }
}
