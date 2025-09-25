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

            string expresion = textBox1.Text;

            Regex regex = new Regex(@"<multa>[\s\S]*?</multa>",RegexOptions.IgnoreCase);

            Match math =regex.Match(expresion);

            listBox1.Items.Clear();
            while (math.Success)
            {
                
                string cadena = math.Value;
                listBox1.Items.Add(cadena);
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

            listBox1.Items.Clear();
            foreach (Vehiculo v in vehiculos)
            {
                listBox1.Items.Add(v.ToString().Trim());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
