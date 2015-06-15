using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Model
{
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
