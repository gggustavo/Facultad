namespace Modelo.Model
{
    using System.Collections.Generic;

    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }

        public Curso()
        {
            Alumno = new HashSet<Alumno>();
        }

    }
}
