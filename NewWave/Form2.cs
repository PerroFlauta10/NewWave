using System;
using System.Data;
using System.Windows.Forms;

namespace NewWave
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region Eventos de Teclado
        private void textNomAlum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de "ding" al presionar Enter
                BuscarAlumno();
            }
        }

        private void textNomProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarProfesor();
            }
        }
        #endregion

        #region Métodos de Alumnos
        private void BuscarAlumno()
        {
            if (string.IsNullOrWhiteSpace(textNomAlum.Text))
            {
                MessageBox.Show("El nombre del alumno no puede estar vacío.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                string nombreAlumno = textNomAlum.Text;
                DataTable alumnosTable = context.BuscarAlumnoPorNombre(nombreAlumno);
                dataAlum.DataSource = alumnosTable;
            }
        }

        private void LimpiarCamposAlumno()
        {
            textDirAlum.Text = "";
            textDniAlum.Text = "";
            textNombAlum.Text = "";
            textApeAlum.Text = "";
            textTelAlum.Text = "";
            textEmailAlum.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
        }

        private void LoadAlumnosData()
        {
            using (NewWaveContext context = new NewWaveContext())
            {
                DataTable alumnosTable = context.GetAlumnos();
                dataAlum.DataSource = alumnosTable;
            }
        }
        #endregion

        #region Métodos de Profesores
        private void BuscarProfesor()
        {
            if (string.IsNullOrWhiteSpace(textNomProf.Text))
            {
                MessageBox.Show("El nombre del profesor no puede estar vacío.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                string nombreProfesor = textNomProf.Text;
                DataTable profesoresTable = context.BuscarProfesorPorNombre(nombreProfesor);
                dataAlum.DataSource = profesoresTable;
            }
        }

        private void LimpiarCamposProfesor()
        {
            textDirProf.Text = "";
            textDniProf.Text = "";
            textNombProf.Text = "";
            textApeProf.Text = "";
            textTelProf.Text = "";
            textEmailProf.Text = "";
            textBoxProf1.Text = "";
            textBoxProf2.Text = "";
            textBoxProf3.Text = "";
            textBoxProf4.Text = "";
            richTextBoxProf1.Text = "";
        }

        private void LoadProfesoresData()
        {
            using (NewWaveContext context = new NewWaveContext())
            {
                DataTable profesoresTable = context.GetProfesores();
                dataAlum.DataSource = profesoresTable;
            }
        }
        #endregion

        #region Eventos de Botones de Alumnos
        private void butAlum_Click(object sender, EventArgs e)
        {
            groupBoxAlum.Visible = true;
            groupBoxA.Visible = true;
        }

        private void butBuscAlum_Click(object sender, EventArgs e)
        {
            dataAlum.Visible = true;
            textNomAlum.Visible = true;
            butElimAlum.Visible = true;
            bVaciarBase.Visible = true;
            bCAncBuscAlum.Visible = true;
        }

        private void butElimAlum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNomAlum.Text))
            {
                MessageBox.Show("El nombre del alumno no puede estar vacío.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                string nombreAlumno = textNomAlum.Text;
                DataTable alumnosTable = context.BuscarAlumnoPorNombre(nombreAlumno);

                if (alumnosTable.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún alumno con ese nombre.");
                    return;
                }

                foreach (DataRow row in alumnosTable.Rows)
                {
                    string dni = row["Dni"].ToString();
                    context.EliminarAlumnoPorDni(dni);
                }
            }
            LoadAlumnosData();
        }

        private void bCAncBuscAlum_Click(object sender, EventArgs e)
        {
            textNomAlum.Visible = false;
            butElimAlum.Visible = false;
            bVaciarBase.Visible = false;
            bCAncBuscAlum.Visible = false;
        }

        private void butCreaAlum_Click(object sender, EventArgs e)
        {
            groupFichaAlum.Visible = true;
        }

        private void bSalFicha_Click(object sender, EventArgs e)
        {
            groupFichaAlum.Visible = false;
        }

        private void bGuardAlum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textDniAlum.Text))
            {
                MessageBox.Show("El Dni no puede estar vacio.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                AlumnoC nuevoAlumno = new AlumnoC
                {
                    Dni = textDniAlum.Text,
                    Nombre = textNombAlum.Text,
                    Apellido = textApeAlum.Text,
                    Direccion = textDirAlum.Text,
                    Telefono = textTelAlum.Text,
                    Email = textEmailAlum.Text,
                    Sexo = textBox1.Text,
                    FechaNacimiento = textBox2.Text,
                    FechaIngreso = textBox3.Text,
                    FechaSalida = textBox4.Text,
                    Observaciones = richTextBox1.Text
                };

                context.AddAlumno(nuevoAlumno);
            }

            LimpiarCamposAlumno();
            groupFichaAlum.Visible = false;
            dataAlum.Visible = true;
            LoadAlumnosData();
        }

        private void bListarAlum_Click(object sender, EventArgs e)
        {
            dataAlum.Visible = true;
            LoadAlumnosData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataAlum.Visible = false;
        }

        private void bVaciarBase_Click(object sender, EventArgs e)
        {
            using (NewWaveContext context = new NewWaveContext())
            {
                context.VaciarAlumnos();
            }
            MessageBox.Show("Base de datos vaciada correctamente.");
            LoadAlumnosData();
        }

        private void bCerrarDataAlum_Click(object sender, EventArgs e)
        {
            dataAlum.Visible = false;
        }

        private void bCerrarAlum_Click(object sender, EventArgs e)
        {
            if (groupBoxProf.Visible == true)
            {
                dataAlum.Visible = false;
                groupBoxA.Visible = false;
                groupFichaAlum.Visible = false;
            }
            else
                groupBoxAlum.Visible = false;
                groupFichaAlum.Visible = false;
        }
        #endregion

        #region Eventos de Botones de Profesores
        private void butProfesor_Click(object sender, EventArgs e)
        {
            groupBoxAlum.Visible = true;
            groupBoxProf.Visible = true;
            groupBoxA.Visible = false;
        }

        private void bCerrarProf_Click(object sender, EventArgs e)
        {
            if (groupBoxAlum.Visible == true)
            {
                dataAlum.Visible = false;
                groupBoxProf.Visible = false;
                groupFichaProf.Visible = false;
            }
            else
                groupBoxProf.Visible = false;
                groupBoxAlum.Visible = false;
        }

        private void bCanBusProf_Click(object sender, EventArgs e)
        {
            textNomProf.Visible = false;
            butElimProf.Visible = false;
            bVaciarBaseP.Visible = false;
            bCanBusProf.Visible = false;
        }

        private void bCerrarDataProf_Click(object sender, EventArgs e)
        {
            dataAlum.Visible = false;
        }

        private void butBusProf_Click(object sender, EventArgs e)
        {
            textNomProf.Visible = true;
            butElimProf.Visible = true;
            bVaciarBaseP.Visible = true;
            bCanBusProf.Visible = true;
        }

        private void butCreaProf_Click(object sender, EventArgs e)
        {
            groupFichaProf.Visible = true;
        }

        private void bSalFichaProf_Click(object sender, EventArgs e)
        {
            groupFichaProf.Visible = false;
        }

        private void bGuardProf_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textDniProf.Text))
            {
                MessageBox.Show("El D.N.I. no puede estar vacio.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                ProfesorC nuevoProfesor = new ProfesorC
                {
                    Dni = textDniProf.Text,
                    Nombre = textNombProf.Text,
                    Apellido = textApeProf.Text,
                    Direccion = textDirProf.Text,
                    Telefono = textTelProf.Text,
                    Email = textEmailProf.Text,
                    Sexo = textBoxProf1.Text,
                    FechaNacimiento = textBoxProf2.Text,
                    FechaIngreso = textBoxProf3.Text,
                    FechaSalida = textBoxProf4.Text,
                    Observaciones = richTextBoxProf1.Text
                };

                context.AddProfesor(nuevoProfesor);
            }
            LimpiarCamposProfesor();
            groupFichaProf.Visible = false;
            dataAlum.Visible = true;
            LoadProfesoresData();
        }

        private void butElimProf_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNomProf.Text))
            {
                MessageBox.Show("El nombre del profesor no puede estar vacío.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                string nombreProfesor = textNomProf.Text;
                DataTable profesoresTable = context.BuscarProfesorPorNombre(nombreProfesor);

                if (profesoresTable.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún profesor con ese nombre.");
                    return;
                }

                foreach (DataRow row in profesoresTable.Rows)
                {
                    string dni = row["Dni"].ToString();
                    context.EliminarProfesorPorDni(dni);
                }
            }
        }

        private void bVaciarBaseP_Click_1(object sender, EventArgs e)
        {
            using (NewWaveContext context = new NewWaveContext())
            {
                context.VaciarProfesores();
            }
            MessageBox.Show("Base de datos de profesores vaciada correctamente.");
            LoadProfesoresData();
        }

        private void bListarProf_Click(object sender, EventArgs e) // Listar profesores
        {
            dataAlum.Visible = true;
            LoadProfesoresData();
        }

        private void bSalFichaProf_Click_1(object sender, EventArgs e)
        {
            groupFichaProf.Visible = false;
        }
        #endregion

        #region Eventos de Cierre de Sesión
        private void bCerrarSesion_Click(object sender, EventArgs e)
        {
            Acceso ActiveForm = new Acceso();
            ActiveForm.Show();
            this.Close();
        }
        #endregion

        #region Eventos de Cursos
        private void butCurso_Click(object sender, EventArgs e)
        {
            groupBoxCurso.Visible = true;
            groupBoxA.Visible = false;
        }

        private void bSalirCursos_Click(object sender, EventArgs e)
        {
            groupBoxCurso.Visible = false;
        }

        private void bSalirIngCurso_Click(object sender, EventArgs e)
        {
            groupBoxIngCurso.Visible = false;
        }

        private void bAñaCurso_Click(object sender, EventArgs e)
        {
            groupBoxIngCurso.Visible = true;
        }

        private void bGuardarCurso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIdCurso.Text))
            {
                MessageBox.Show("El id de curso no puede estar vacio.");
                return;
            }

            using (NewWaveContext context = new NewWaveContext())
            {
                Curso curso = new Curso
                {
                    Id = textBoxIdCurso.Text,
                    Nombre = textBoxNomCurso.Text,
                    Duracion = textBoxDur.Text,
                    FechaInicio = textBox9.Text,
                    FechaFin = textBox10.Text,
                    Horario = textBox11.Text,
                    Precio = textBox12.Text,
                };

                context.AddCurso(curso);
            }
            LimpiarCamposCurso();
            groupBoxIngCurso.Visible = false;
            dataAlum.Visible = true;
            LoadProfesoresData();
        }

        private void LimpiarCamposCurso()
        {
            textBoxIdCurso.Text = "";
            textBoxNomCurso.Text = "";
            textBoxDur.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        #endregion

       
        private void LoadCursosData()
        {
            using (NewWaveContext context = new NewWaveContext())
            {
                DataTable CursosTable = context.GetCursos();
                dataCurso.DataSource = CursosTable;
            }
        }

        private void bListarCurso_Click(object sender, EventArgs e)
        {
             dataCurso.Visible = true;
             LoadCursosData();           
        }
    }
}

