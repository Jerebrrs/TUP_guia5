using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expresion = textBox1.Text;
            int cantNumeros = 0;
            for (int i = 0; i < expresion.Length; i++)
            {
                if (char.IsNumber(expresion[i]) == true)
                {
                    cantNumeros++;
                }
            }
            if (cantNumeros== expresion.Length)
            {
                textBox2.Text = "Es valido";

            }
            else
            {
                textBox2.Text = "No es valido";
            }
        }
    }
}
