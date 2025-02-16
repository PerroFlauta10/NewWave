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
        //
        //El método AddAlumno recibe un objeto de tipo AlumnoC y lo añade a la base de datos.
        //
        //
        public void AddAlumno(AlumnoC alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Dni))
            {
                throw new ArgumentException("Dni cannot be empty.");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    EnsureTableExists("Alumnos", connection);

                    //Se obtiene el contador para el nuevo alumno
                    int nuevoContador = GetNuevoContador(connection, "Alumnos");

                    string query = "INSERT INTO Alumnos (Dni, Nombre, Apellido, Direccion, Telefono, Email, Sexo, FechaNacimiento, FechaIngreso, FechaSalida, Observaciones, Contador) " +
                                   "VALUES (@Dni, @Nombre, @Apellido, @Direccion, @Telefono, @Email, @Sexo, @FechaNacimiento, @FechaIngreso, @FechaSalida, @Observaciones, @Contador)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //Se añaden los parámetros del alumno al comando SQL  (Linea 188).
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
        //
        //El método GetAlumnos devuelve una tabla con todos los alumnos de la base de datos.
        //
        public DataTable GetAlumnos()
        {
            return GetDataTable("SELECT * FROM Alumnos");
        }
        //
        //El método VaciarAlumnos elimina todos los alumnos de la base de datos.
        //
        public void VaciarAlumnos()
        {
            ExecuteNonQuery("DELETE FROM Alumnos");
        }
        //
        //El método BuscarAlumnoPorNombre recibe un string con el nombre del alumno a buscar y devuelve una tabla con los resultados.
        //
        public DataTable BuscarAlumnoPorNombre(string nombre)
        {
            return GetDataTable("SELECT * FROM Alumnos WHERE Nombre LIKE @Nombre", new SqlParameter("@Nombre", "%" + nombre + "%"));
        }
        //
        //El método BuscarAlumnoPorDni recibe un string con el DNI del alumno a buscar y devuelve una tabla con los resultados.
        //
        public void EliminarAlumnoPorDni(string dni)
        {
            ExecuteNonQuery("DELETE FROM Alumnos WHERE Dni = @Dni", new SqlParameter("@Dni", dni));
        }
        //
        //el metodo AddProfesor recibe un objeto de tipo ProfesorC y lo añade a la base de datos.
        //
        public void AddProfesor(ProfesorC profesor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    EnsureTableExists("Profesores", connection);

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
        //
        //El método GetProfesores devuelve una tabla con todos los profesores de la base de datos.
        //
        public DataTable GetProfesores()
        {
            return GetDataTable("SELECT * FROM Profesores");
        }
        //
        //El método VaciarProfesores elimina todos los profesores de la base de datos.
        //
        public void VaciarProfesores()
        {
            ExecuteNonQuery("DELETE FROM Profesores");
        }
        //
        //El método BuscarProfesorPorNombre recibe un string con el nombre del profesor a buscar y devuelve una tabla con los resultados.
        //
        public DataTable BuscarProfesorPorNombre(string nombre)
        {
            return GetDataTable("SELECT * FROM Profesores WHERE Nombre LIKE @Nombre", new SqlParameter("@Nombre", "%" + nombre + "%"));
        }
        //
        //El método BuscarProfesorPorDni recibe un string con el DNI del profesor a buscar y devuelve una tabla con los resultados.
        //
        public DataTable BuscarProfesorPorDni(string dni)
        {
            return GetDataTable("SELECT * FROM Profesores WHERE Dni = @Dni", new SqlParameter("@Dni", dni));
        }
        //
        //El método EliminarProfesorPorDni recibe un string con el DNI del profesor a eliminar y lo elimina de la base de datos.
        //
        public void EliminarProfesorPorDni(string dni)
        {
            ExecuteNonQuery("DELETE FROM Profesores WHERE Dni = @Dni", new SqlParameter("@Dni", dni));
        }
        //
        //El método Dispose libera los recursos no administrados utilizados por el objeto NewWaveContext.
        //
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //
        //El método EnsureTableExists se asegura de que la tabla especificada exista en la base de datos.
        //
        private void EnsureTableExists(string tableName, SqlConnection connection)
        {
            string checkTableQuery = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}') " +
                                     "BEGIN " +
                                     $"CREATE TABLE {tableName} (" +
                                     "Num INT, " +
                                     "Contador INT, " +
                                     "Dni NVARCHAR(50) PRIMARY KEY, " +
                                     "Nombre NVARCHAR(100), " +
                                     "Apellido NVARCHAR(100), " +
                                     "Direccion NVARCHAR(200), " +
                                     "Telefono NVARCHAR(50), " +
                                     "Email NVARCHAR(100), " +
                                     "Sexo NVARCHAR(10), " +
                                     "FechaNacimiento NVARCHAR(50), " +
                                     "FechaIngreso NVARCHAR(50), " +
                                     "FechaSalida NVARCHAR(50), " +
                                     "Observaciones NVARCHAR(MAX)) " +
                                     "END";

            using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            string checkColumnQuery = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = 'Contador') " +
                                      "BEGIN " +
                                      $"ALTER TABLE {tableName} ADD Contador INT " +
                                      "END";

            using (SqlCommand command = new SqlCommand(checkColumnQuery, connection))
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
        //
        //El método AddAlumnoParameters añade los parámetros de un objeto de tipo AlumnoC a un comando SQL.
        //
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
        //
        //El método GetDataTable ejecuta una consulta SQL y devuelve una tabla con los resultados.
        //
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
        //
        //El método ExecuteNonQuery ejecuta una consulta SQL que no devuelve resultados.
        //
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
        //
        //El método LogError escribe un mensaje de error en un archivo de log.
        //
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
        //
        //La clase Connection representa una conexión a la base de datos.
        //
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
    }
}

