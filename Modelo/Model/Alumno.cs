namespace Modelo.Model
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
