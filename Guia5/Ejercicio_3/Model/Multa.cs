using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio_3.Model
{
    public class Multa : IImportable
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
            Regex regex = new Regex(@"<multa>{[\w]+?}</multa>", RegexOptions.IgnoreCase);
            Match match = regex.Match(xml);
            if (match.Groups.Count != 2) return false;

            Importe =Convert.ToDouble( match.Groups[1].Value);
            return true;
        }
    }
}
