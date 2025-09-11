using Ejercicio_3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

            Regex regex = new Regex(@"");

            Match math =regex.Match(expresion);


            while (math.Success)
            {
                string cadena = math.Value;
                Vehiculo neuvo = new Vehiculo();

                if (neuvo.Importar(cadena))
                {

                    vehiculos.Sort();
                    int idx = vehiculos.BinarySearch(neuvo);
                    if (idx >-1) { vehiculos[idx] } else { vehiculos.Add(neuvo); }

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
