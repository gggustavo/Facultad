using Controladora;
using Modelo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Alumnos : Form
    {

        AlumnoControladora ctralumno;
        CursoControladora ctrcurso;
        Alumno alumno =null;
        
        public Alumnos()
        {
            InitializeComponent();
            ctralumno = new AlumnoControladora();
            ctrcurso = new CursoControladora();
        }


        protected override void OnLoad(EventArgs e)
        {
            cursoBindingSource.DataSource = ctrcurso.ListCurso().ToList();
            ListarAlumnos();
            base.OnLoad(e);
        }

        private void ListarAlumnos()
        {
            alumnoBindingSource.DataSource = ctralumno.ListarAlumnos().Select(a => new
            {
                AlumnoId = a.AlumnoId,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Curso = a.Curso.Nombre
            }).ToList();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (alumno != null)
            {
                alumno.Nombre = nombre.Text;
                alumno.Apellido = apellido.Text;
                alumno.CursoId = ((Curso)cursoBindingSource.Current).CursoId;
                ctralumno.ModificarAlumno(alumno);
                ListarAlumnos();
                alumno = null;
            }
            else
            {
                if (cursoBindingSource.Current != null && !string.IsNullOrEmpty(nombre.Text) && !string.IsNullOrEmpty(apellido.Text))
                {
                    ctralumno.AgregarAlumno(new Alumno()
                    {
                        Nombre = nombre.Text,
                        Apellido = apellido.Text,
                        CursoId = ((Curso)cursoBindingSource.Current).CursoId
                    });
                    ListarAlumnos();
                }
            }
          
              
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (alumnoBindingSource.Current != null)
            {
                var valuedelete = (alumnoBindingSource.Current) as dynamic;
                var id = valuedelete.AlumnoId;
                ctralumno.EliminarAlumno(id);
                ListarAlumnos();
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (alumnoBindingSource.Current != null)
            {
                var valueModificar = (alumnoBindingSource.Current) as dynamic;

                alumno = ctralumno.ObtenerAlumno(valueModificar.AlumnoId);

                nombre.Text = valueModificar.Nombre;
                apellido.Text = valueModificar.Apellido;

                var item = cursoBindingSource.List.OfType<Curso>().Where(_ => _.Nombre == valueModificar.Curso).First();
                cursoBindingSource.Position = cursoBindingSource.IndexOf(item);
            }
        }
    }
}
