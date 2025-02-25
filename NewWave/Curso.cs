using System.Collections.Generic;

namespace NewWave
{
    public class Curso
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Duracion { get; set; } // Duración en horas        
        public string Precio { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Horario { get; set; }
        public List<AlumnoC> Alumnos { get; set; }
        public List<ProfesorC> Profesores { get; set; }

        public Curso()
        {
            Alumnos = new List<AlumnoC>();
            Profesores = new List<ProfesorC>();
        }
    }
}
