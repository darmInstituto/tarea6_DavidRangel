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

        List<Alumprog2> listAlumnos;
        private void button1_Click(object sender, EventArgs e)
        {
            Alumprog2 alumno = new Alumprog2(txtRut.Text, txtNombre.Text, int.Parse(txtEdad.Text), txtSeccion.Text, txtAsignatura.Text, int.Parse(txtNota.Text));
            listAlumnos.Add(alumno);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listAlumnos = new List<Alumprog2>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.RowCount = listAlumnos.Count;

            dataGridView1.Columns[0].HeaderText = "Rut";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Edad";
            dataGridView1.Columns[3].HeaderText = "Seccion";
            dataGridView1.Columns[4].HeaderText = "Asignatura";
            dataGridView1.Columns[5].HeaderText = "Nota";

            int i = 0;
            foreach (Alumprog2 alumprog in listAlumnos)
            {
                dataGridView1.Rows[i].Cells[0].Value = alumprog.getRut();
                dataGridView1.Rows[i].Cells[1].Value = alumprog.getNombre();
                dataGridView1.Rows[i].Cells[2].Value = alumprog.getEdad();
                dataGridView1.Rows[i].Cells[3].Value = alumprog.getSeccion();
                dataGridView1.Rows[i].Cells[4].Value = alumprog.getAsignatura();
                dataGridView1.Rows[i].Cells[5].Value = alumprog.getNota();
                i++;
            }

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}
