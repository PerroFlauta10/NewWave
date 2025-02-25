using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace NewWave
{
    public class NewWaveContext : IDisposable
    {
        private string connectionString;

        public NewWaveContext()
        {
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\julia\\source\\repos\\NewWave\\NewWave\\NewWaveDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public void AddAlumno(AlumnoC alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Dni))
            {
                throw new ArgumentException("El dni no puede estar vacio.");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string tableSchema = "Dni NVARCHAR(50) PRIMARY KEY, " +
                                         "Nombre NVARCHAR(100), " +
                                         "Apellido NVARCHAR(100), " +
                                         "Direccion NVARCHAR(200), " +
                                         "Telefono NVARCHAR(50), " +
                                         "Email NVARCHAR(100), " +
                                         "Sexo NVARCHAR(10), " +
                                         "FechaNacimiento NVARCHAR(50), " +
                                         "FechaIngreso NVARCHAR(50), " +
                                         "FechaSalida NVARCHAR(50), " +
                                         "Observaciones NVARCHAR(MAX), " +
                                         "Contador INT";
                    EnsureTableExists("Alumnos", connection, tableSchema);

                    int nuevoContador = GetNuevoContador(connection, "Alumnos");

                    string query = "INSERT INTO Alumnos (Dni, Nombre, Apellido, Direccion, Telefono, Email, Sexo, FechaNacimiento, FechaIngreso, FechaSalida, Observaciones, Contador) " +
                                   "VALUES (@Dni, @Nombre, @Apellido, @Direccion, @Telefono, @Email, @Sexo, @FechaNacimiento, @FechaIngreso, @FechaSalida, @Observaciones, @Contador)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddAlumnoParameters(command, alumno, nuevoContador);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                LogError("SQL Exception: " + ex.Message);
                throw;
            }

            MessageBox.Show("Alumno añadido correctamente");
        }

        public DataTable GetAlumnos()
        {
            return GetDataTable("SELECT * FROM Alumnos");
        }

        public void VaciarAlumnos()
        {
            ExecuteNonQuery("DELETE FROM Alumnos");
        }

        public DataTable BuscarAlumnoPorNombre(string nombre)
        {
            return GetDataTable("SELECT * FROM Alumnos WHERE Nombre LIKE @Nombre", new SqlParameter("@Nombre", "%" + nombre + "%"));
        }

        public void EliminarAlumnoPorDni(string dni)
        {
            ExecuteNonQuery("DELETE FROM Alumnos WHERE Dni = @Dni", new SqlParameter("@Dni", dni));
        }

        private void AddAlumnoParameters(SqlCommand command, AlumnoC alumno, int contador)
        {
            command.Parameters.AddWithValue("@Dni", alumno.Dni);
            command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
            command.Parameters.AddWithValue("@Apellido", alumno.Apellido);
            command.Parameters.AddWithValue("@Direccion", alumno.Direccion);
            command.Parameters.AddWithValue("@Telefono", alumno.Telefono);
            command.Parameters.AddWithValue("@Email", alumno.Email);
            command.Parameters.AddWithValue("@Sexo", alumno.Sexo);
            command.Parameters.AddWithValue("@FechaNacimiento", alumno.FechaNacimiento);
            command.Parameters.AddWithValue("@FechaIngreso", alumno.FechaIngreso);
            command.Parameters.AddWithValue("@FechaSalida", alumno.FechaSalida);
            command.Parameters.AddWithValue("@Observaciones", alumno.Observaciones);
            command.Parameters.AddWithValue("@Contador", contador);
        }
        public void AddProfesor(ProfesorC profesor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string tableSchema = "Dni NVARCHAR(50) PRIMARY KEY, " +
                                         "Nombre NVARCHAR(100), " +
                                         "Apellido NVARCHAR(100), " +
                                         "Direccion NVARCHAR(200), " +
                                         "Telefono NVARCHAR(50), " +
                                         "Email NVARCHAR(100), " +
                                         "Sexo NVARCHAR(10), " +
                                         "FechaNacimiento NVARCHAR(50), " +
                                         "FechaIngreso NVARCHAR(50), " +
                                         "FechaSalida NVARCHAR(50), " +
                                         "Observaciones NVARCHAR(MAX), " +
                                         "Contador INT";
                    EnsureTableExists("Profesores", connection, tableSchema);

                    int nuevoContador = GetNuevoContador(connection, "Profesores");

                    string query = "INSERT INTO Profesores (Dni, Nombre, Apellido, Direccion, Telefono, Email, Sexo, FechaNacimiento, FechaIngreso, FechaSalida, Observaciones, Contador) " +
                                   "VALUES (@Dni, @Nombre, @Apellido, @Direccion, @Telefono, @Email, @Sexo, @FechaNacimiento, @FechaIngreso, @FechaSalida, @Observaciones, @Contador)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddProfesorParameters(command, profesor, nuevoContador);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                LogError("SQL Exception: " + ex.Message);
                throw;
            }

            MessageBox.Show("Profesor añadido correctamente");
        }

        public DataTable GetProfesores()
        {
            return GetDataTable("SELECT * FROM Profesores");
        }

        public void VaciarProfesores()
        {
            ExecuteNonQuery("DELETE FROM Profesores");
        }

        public DataTable BuscarProfesorPorNombre(string nombre)
        {
            return GetDataTable("SELECT * FROM Profesores WHERE Nombre LIKE @Nombre", new SqlParameter("@Nombre", "%" + nombre + "%"));
        }

        public DataTable BuscarProfesorPorDni(string dni)
        {
            return GetDataTable("SELECT * FROM Profesores WHERE Dni = @Dni", new SqlParameter("@Dni", dni));
        }

        public void EliminarProfesorPorDni(string dni)
        {
            ExecuteNonQuery("DELETE FROM Profesores WHERE Dni = @Dni", new SqlParameter("@Dni", dni));
        }

        private void AddProfesorParameters(SqlCommand command, ProfesorC profesor, int contador)
        {
            command.Parameters.AddWithValue("@Dni", profesor.Dni);
            command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
            command.Parameters.AddWithValue("@Apellido", profesor.Apellido);
            command.Parameters.AddWithValue("@Direccion", profesor.Direccion);
            command.Parameters.AddWithValue("@Telefono", profesor.Telefono);
            command.Parameters.AddWithValue("@Email", profesor.Email);
            command.Parameters.AddWithValue("@Sexo", profesor.Sexo);
            command.Parameters.AddWithValue("@FechaNacimiento", profesor.FechaNacimiento);
            command.Parameters.AddWithValue("@FechaIngreso", profesor.FechaIngreso);
            command.Parameters.AddWithValue("@FechaSalida", profesor.FechaSalida);
            command.Parameters.AddWithValue("@Observaciones", profesor.Observaciones);
            command.Parameters.AddWithValue("@Contador", contador);
        }
        public void AddCurso(Curso curso)
        {
            if (string.IsNullOrWhiteSpace(curso.Id))
            {
                throw new ArgumentException("El identificador no puede estar vacio.");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string tableSchema = "Id NVARCHAR(50) PRIMARY KEY, " +
                                         "Nombre NVARCHAR(100), " +
                                         "Duracion NVARCHAR(50), " +
                                         "Precio NVARCHAR(50), " +
                                         "FechaIngreso NVARCHAR(50), " +
                                         "FechaSalida NVARCHAR(50), " +
                                         "Horario NVARCHAR(50), " +
                                         "Contador INT";
                    EnsureTableExists("Cursos", connection, tableSchema);

                    int nuevoContador = GetNuevoContador(connection, "Cursos");

                    string query = "INSERT INTO Cursos (Id, Nombre, Duracion, Precio, FechaIngreso, FechaSalida, Horario, Contador) " +
                                   "VALUES (@Id, @Nombre, @Duracion, @Precio, @FechaIngreso, @FechaSalida, @Horario, @Contador)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddCursosParameters(command, curso, nuevoContador);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                LogError("SQL Exception: " + ex.Message);
                throw;
            }

            MessageBox.Show("Curso añadido correctamente");
        }

        private void AddCursosParameters(SqlCommand command, Curso curso, int contador)
        {
            command.Parameters.AddWithValue("@Id", curso.Id);
            command.Parameters.AddWithValue("@Nombre", curso.Nombre);
            command.Parameters.AddWithValue("@Duracion", curso.Duracion);
            command.Parameters.AddWithValue("@Precio", curso.Precio);
            command.Parameters.AddWithValue("@FechaIngreso", curso.FechaInicio);
            command.Parameters.AddWithValue("@FechaSalida", curso.FechaFin);
            command.Parameters.AddWithValue("@Horario", curso.Horario);
            command.Parameters.AddWithValue("@Contador", contador);
        }

        public DataTable GetCursos()
        {
            return GetDataTable("SELECT * FROM Cursos");
        }

        public void VaciarCursos()
        {
            ExecuteNonQuery("DELETE FROM Cursos");
        }

        public DataTable BuscarCursoPorNombre(string nombre)
        {
            return GetDataTable("SELECT * FROM Cursos WHERE Nombre LIKE @Nombre", new SqlParameter("@Nombre", "%" + nombre + "%"));
        }

        public void EliminarCursosPorId(string Id)
        {
            ExecuteNonQuery("DELETE FROM Cursos WHERE Id = @Id", new SqlParameter("@Id", Id));
        }

        private void EnsureTableExists(string tableName, SqlConnection connection, string tableSchema)
        {
            string checkTableQuery = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}') " +
                                     "BEGIN " +
                                     $"CREATE TABLE {tableName} ({tableSchema}) " +
                                     "END";

            using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private int GetNuevoContador(SqlConnection connection, string tableName)
        {
            string getMaxContadorQuery = $"SELECT ISNULL(MAX(Contador), 0) FROM {tableName}";
            using (SqlCommand getMaxContadorCommand = new SqlCommand(getMaxContadorQuery, connection))
            {
                return (int)getMaxContadorCommand.ExecuteScalar() + 1;
            }
        }

        private DataTable GetDataTable(string query, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        private void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LogError(string message)
        {
            string logFilePath = "C:\\Users\\julia\\source\\repos\\NewWave\\NewWave\\ErrorLog.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir en el archivo de log: " + ex.Message);
            }
        }

        #region Métodos de Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Clase Connection
        public class Connection
        {
            private NewWaveContext context;

            public Connection()
            {
                context = new NewWaveContext();
            }

            public NewWaveContext GetContext()
            {
                return context;
            }
        }
        #endregion
    }
}

