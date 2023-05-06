using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea6_DavidRangel
{
    internal class Alumprog2
    {
        private string rut;
        private string nombre;
        private int edad;
        private string seccion;
        private string asignatura;
        private int nota;

        public Alumprog2(string rut, string nombre, int edad, string seccion, string asignatura, int nota)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.edad = edad;
            this.seccion = seccion;
            this.asignatura = asignatura;
            this.nota = nota;
        }

        public Alumprog2()
        {
            this.rut = "";
            this.nombre = "";
            this.edad = 0;
            this.seccion = "";
            this.asignatura = "";
            this.nota = 0;
        }

        public string getRut()
        {
            return rut;
        }
        public string getNombre()
        {
            return nombre;
        }
        public int getEdad()
        {
            return edad;
        }
        public string getSeccion()
        {
            return seccion;
        }
        public string getAsignatura()
        {
            return asignatura;
        }
        public int getNota()
        {
            return nota;
        }

        public void setRut(string p) {  this.rut = p; }
        public void setNombre(string p) { this.nombre = p; }
        public void setEdad(int p) { this.edad = p; }
        public void setSeccion(string p) { this.seccion = p; }
        public void setAsignatura(string p) { this.asignatura = p; }
        public void setNota(int p) { this.nota = p; }

    }
}
