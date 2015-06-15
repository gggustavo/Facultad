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
            this.cursoBindingSource.DataSource = ctrcurso.ListarCursos();
            ListarAlumnos();
            base.OnLoad(e);
        }

        private void ListarAlumnos()
        {
            this.alumnoBindingSource.DataSource = ctralumno.ListarAlumnos().Select(a => new
            {
                AlumnoId = a.AlumnoId,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Curso = a.Curso.Nombre
            });
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (alumno != null)
            {
                alumno.Nombre = this.nombre.Text;
                alumno.Apellido = this.apellido.Text;
                alumno.CursoId = ((Curso)this.cursoBindingSource.Current).CursoId;
                ctralumno.ModificarAlumno(alumno);
                ListarAlumnos();
                alumno = null;
            }
            else
            {
                if (this.cursoBindingSource.Current != null && !string.IsNullOrEmpty(this.nombre.Text) && !string.IsNullOrEmpty(this.apellido.Text))
                {
                    ctralumno.AgregarAlumno(new Alumno()
                    {
                        Nombre = this.nombre.Text,
                        Apellido = this.apellido.Text,
                        CursoId = ((Curso)this.cursoBindingSource.Current).CursoId
                    });
                    ListarAlumnos();
                }
            }
          
              
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (this.alumnoBindingSource.Current != null)
            {
                dynamic valuedelete = (this.alumnoBindingSource.Current);
                int alumnoId = valuedelete.AlumnoId;
                ctralumno.EliminarAlumno(alumnoId);
                ListarAlumnos();
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (this.alumnoBindingSource.Current != null)
            {

                dynamic valueModificar = (this.alumnoBindingSource.Current);

                alumno = ctralumno.ObtenerAlumno(valueModificar.AlumnoId);

                this.nombre.Text = valueModificar.Nombre;
                this.apellido.Text = valueModificar.Apellido;

                var item = this.cursoBindingSource.List.OfType<Curso>().ToList().Find(c => c.Nombre == valueModificar.Curso);
                this.cursoBindingSource.Position = this.cursoBindingSource.IndexOf(item);
            }
        }
    }
}
