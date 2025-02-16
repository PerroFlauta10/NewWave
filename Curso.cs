using System.Collections.Generic;

namespace NewWave
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public bool Subvencionado { get; set; }
        public int Duracion { get; set; } // Duraci�n en horas
        public List<AlumnoC> Alumnos { get; set; }
        public List<ProfesorC> Profesores { get; set; }

        public Curso()
        {
            Alumnos = new List<AlumnoC>();
            Profesores = new List<ProfesorC>();
        }
    }
}
