using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea6_DavidRangel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Alumprog2> listAlumnos = new List<Alumprog2>();
        private void button1_Click(object sender, EventArgs e)
        {
            Alumprog2 alumno = new Alumprog2(txtRut.Text, txtNombre.Text, int.Parse(txtEdad.Text), txtSeccion.Text, txtAsignatura.Text, int.Parse(txtNota.Text));
            listAlumnos.Add(alumno);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtRut.Text = "000.000.000-0";
            txtRut.SelectionStart = txtRut.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }
        List<char> listRut = new List<char>();
        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            int seleccion = txtRut.SelectionStart;

            
            if (!Char.IsControl(e.KeyChar))
            {
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == 'k' || e.KeyChar == 'K')
                {
                    int longitud = listRut.Count;                  
                    e.Handled = true;

                    if (longitud >= 10)
                    {
                        MessageBox.Show("maximo");
                    }
                    else if (txtRut.TextLength > 0)
                    {
                        listRut.Clear();
                        for (int i = 0; i < txtRut.Text.Length; i++)
                        {
                            listRut.Add(txtRut.Text[i]);
                        }

                        //MessageBox.Show(seleccion.ToString());

                        listRut.Insert(seleccion, e.KeyChar);

                        while (listRut.IndexOf('-') >= 0)
                        {
                            listRut.Remove('-');
                        }
                        while (listRut.IndexOf('.') >= 0)
                        {
                            listRut.Remove('.');
                        }

                        bool firstsZeroEliminados = false;
                        int contador = 0;
                        for (int i = 0; i < listRut.Count && firstsZeroEliminados == false; i++)
                        {
                            if (listRut[i] == '0')
                            {
                                contador++;
                            }
                            else
                            {
                                firstsZeroEliminados = true;
                            }
                        }

                        while (contador > 0)
                        {
                            listRut.Remove('0');
                            contador--;
                        }

                        string rut = String.Join("", listRut.ToArray());

                        while (rut.Length < 10)
                        {
                            rut = "0" + rut;
                        }
                        rut = String.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}", rut[0], rut[1], rut[2], rut[3], rut[4], rut[5], rut[6], rut[7], rut[8], rut[9]);

                        txtRut.Text = rut;
                        txtRut.SelectionStart = seleccion;
                    }
                    else
                    {
                        listRut.Clear();
                        if (txtRut.TextLength == 0)
                        {
                            listRut.Add(e.KeyChar);
                        }
                        string rut = String.Join("", listRut.ToArray());

                        while (rut.Length < 10)
                        {
                            rut = "0" + rut;
                        }
                        rut = String.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}", rut[0], rut[1], rut[2], rut[3], rut[4], rut[5], rut[6], rut[7], rut[8], rut[9]);

                        txtRut.Text = rut;
                        txtRut.SelectionStart = txtRut.Text.Length;
                    }
                }              
                else
                {
                    e.Handled = true;
                }   
                
            }
            
        }

        private void txtRut_KeyUp(object sender, KeyEventArgs e)
        {
            int seleccion = txtRut.SelectionStart;
            
            if (e.KeyValue == 8 || e.KeyValue == 46)
            {
                listRut.Clear();
                if (txtRut.TextLength > 0)
                {
                    for (int i = 0; i < txtRut.Text.Length; i++)
                    {
                        if (Char.IsNumber(txtRut.Text[i]) || txtRut.Text[i] == 'k' || txtRut.Text[i] == 'K')
                        {
                            listRut.Add(txtRut.Text[i]);
                        }
                    }
                    bool firstsZeroEliminados = false;
                    int contador = 0;
                    for (int i = 0; i < listRut.Count && firstsZeroEliminados == false; i++)
                    {
                        if (listRut[i] == '0')
                        {
                            contador++;
                        }
                        else
                        {
                            firstsZeroEliminados = true;
                        }
                    }

                    while (contador > 0)
                    {
                        listRut.Remove('0');
                        contador--;
                    }

                    string rut = String.Join("", listRut.ToArray());

                    while (rut.Length < 10)
                    {
                        rut = "0" + rut;
                    }
                    rut = String.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}", rut[0], rut[1], rut[2], rut[3], rut[4], rut[5], rut[6], rut[7], rut[8], rut[9]);

                    txtRut.Text = rut;
                    txtRut.SelectionStart = seleccion + 1;

                }
                else
                {
                    txtRut.Text = "000.000.000-0";
                    txtRut.SelectionStart = txtRut.Text.Length;
                }
            }
            
            

        }


        bool validarRut(string rut)
        {
            int[] constantes = { 3, 2, 7, 6, 5, 4, 3, 2 };

            while (rut.Length < 10)
            {
                rut = "0" + rut;
            }



            double suma = 0;
            for (int i = 0; i < 8; i++)
            {
                int valorActual = int.Parse(rut[i].ToString());
                suma += constantes[i] * valorActual;
            }
            double division = suma / 11.0;
            double decimales = division - (int)division;
            double digitoNumerico = Math.Round(11 - (11 * decimales));
            char digito;
            if (digitoNumerico == 11)
            {
                digito = '0';
            }
            else if (digitoNumerico == 10)
            {
                digito = 'k';
            }
            else
            {
                digito = Convert.ToChar(digitoNumerico.ToString());
            }
            string condicion = "";

            if (digito == rut[9])
            {

                
            }
            else if (digito == 'k' && rut[9] == 'K')
            {

            }
            else
            {
                
            }
            return false;
        }



        
    }
}
