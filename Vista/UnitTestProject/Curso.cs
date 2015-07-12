using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }

        public IQueryable<Curso> ListCursos()
        {
            var c = new List<Curso>();
            c.Add(new Curso { CursoId = 1, Nombre = "G" });
            c.Add(new Curso { CursoId = 2, Nombre = "G" });
            c.Add(new Curso { CursoId = 3, Nombre = "G" });
            c.Add(new Curso { CursoId = 4, Nombre = "G" });
            c.Add(new Curso { CursoId = 5, Nombre = "G" });
            c.Add(new Curso { CursoId = 1, Nombre = "G" });
            c.Add(new Curso { CursoId = 2, Nombre = "G" });
            c.Add(new Curso { CursoId = 3, Nombre = "G" });
            c.Add(new Curso { CursoId = 4, Nombre = "G" });
            c.Add(new Curso { CursoId = 5, Nombre = "G" });
            c.Add(new Curso { CursoId = 1, Nombre = "G" });
            c.Add(new Curso { CursoId = 2, Nombre = "G" });
            c.Add(new Curso { CursoId = 3, Nombre = "G" });
            c.Add(new Curso { CursoId = 4, Nombre = "G" });
            c.Add(new Curso { CursoId = 5, Nombre = "G" });
            c.Add(new Curso { CursoId = 1, Nombre = "G" });
            c.Add(new Curso { CursoId = 2, Nombre = "G" });
            c.Add(new Curso { CursoId = 3, Nombre = "G" });
            c.Add(new Curso { CursoId = 4, Nombre = "G" });
            c.Add(new Curso { CursoId = 5, Nombre = "G" });
            c.Add(new Curso { CursoId = 1, Nombre = "G" });
            c.Add(new Curso { CursoId = 2, Nombre = "G" });
            c.Add(new Curso { CursoId = 3, Nombre = "G" });
            c.Add(new Curso { CursoId = 4, Nombre = "G" });
            c.Add(new Curso { CursoId = 5, Nombre = "G" });

            return c.AsQueryable();
        }
    }
}
