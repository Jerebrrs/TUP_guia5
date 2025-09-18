using Ejercicio_3.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ejercicio_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            string expresion = listBox1.Text;

            Regex regex = new Regex(@"<multa>[\s\S]*?</multa>",RegexOptions.IgnoreCase);

            Match math =regex.Match(expresion);


            while (math.Success)
            {
                string cadena = math.Value;
                Vehiculo nuevo = new Vehiculo();

                if (nuevo.Importar(cadena))
                {

                    vehiculos.Sort();
                    int idx = vehiculos.BinarySearch(nuevo);
                    if (idx > -1) 
                    {
                        for (int i = 0; i < nuevo.CantidadDeMultas; i++)
                        {
                            vehiculos[idx].AgregarMulta(nuevo.VerMulta(i));
                        }

                    } else { vehiculos.Add(nuevo); }

                }

                math = math.NextMatch(); //aca pregunto si el nuevo match exxiste asi e rompe el bucle
            }
            foreach (Vehiculo v in vehiculos)
            {
                listBox1.Items.Add(v);
            }
        }
    }
}
