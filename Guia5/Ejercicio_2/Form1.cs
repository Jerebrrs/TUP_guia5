using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<string> apellidos = new List<string> {" Hernandez", "Saavedra", "Acosta", "Jacob", "Heinze", "Fischer", "Campos"};
        private List<string> nombres = new List<string> { "Adriana", "Elizabet", "José", "María", "Ernesto", "Sebastian", "Julio", "Ester"
            ,"Ariel", "Betiana","Silvina" ,"Ana" ,"Leandro" ,"Ayelen" ,"Daniela" ,"Miguel"  };

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
               

                int idxN = rnd.Next(0,nombres.Count()-1);
                int idxAp = rnd.Next(0,apellidos.Count()-1);

                sb.AppendLine($"{apellidos[idxAp]}").Append($"{nombres[idxAp]}");

            
            }


            textBox1.Text = sb.ToString();

        }
    }
}
