using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio_3.Model
{
    internal class Vehiculo : IComparable<Vehiculo> ,IImportable
    {

        public string Patente;
        public int CantidadDeMultas
        {
            get
            {
                return multas.Count;
            }
        }
        public double MontoTotal {  get; set; }

        List<Multa> multas = new List<Multa>();

        public Vehiculo()
        {
           
        }
        public Vehiculo(string patente)
        {
            this.Patente = patente;
        }

        public Multa VerMulta(int idx)
        {
            if (idx >=0)
            {
                return multas[idx];
                
            }
            return null;
        }

        public void AgregarMulta(Multa nueva)
        {
            if (nueva !=null)
            {
                multas.Add(nueva);
                MontoTotal += nueva.Importe;
            }
        } 


        public int CompareTo(Vehiculo other)
        {
            if (other !=null)
            {
                return this.Patente.CompareTo(other.Patente);
            }
            return -1;
        }

        public bool Importar(string xml)
        {
            Regex regex = new Regex(@"<patente>{[\s\S]+?}</patente>",RegexOptions.IgnoreCase);
            Match match = regex.Match(xml);
            if (match.Groups.Count != 2) return false;
            
            Patente = match.Groups[1].Value;
            Multa m = new Multa();
            m.Importar(xml);
            AgregarMulta(m);
            return true;
        }


       override public string ToString()
        {
            return $@"Patente: {Patente} - Importe: {MontoTotal}";
        }
    }
}
