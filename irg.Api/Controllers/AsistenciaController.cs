namespace irg.Api.Controllers
{
    using irg.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Web.Http;

    public class AsistenciaController : ApiController
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: api/Asistencia
        public IEnumerable<Asistencia> Get(string matricula, string año, string periodo)
        {
            string stringSQL = "";
            List<Asistencia> asistencia = new List<Asistencia>();

            stringSQL = $"select * " +
                        $"from asistencia asi " +
                        $"inner join alumnos a on a.matricula = asi.matricula " +
                        $"inner join materias m on a.c_carrera = m.c_carrera and m.clave_materia = asi.clave_materia " +
                        $"where asi.matricula = @matricula and asi.ano = @año and asi.no_cuatrimestre = @periodo " +
                        $"order by m.orden, asi.id";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("matricula", matricula));
                        cmd.Parameters.Add(new SqlParameter("año", año));
                        cmd.Parameters.Add(new SqlParameter("periodo", periodo));

                        Conexion.Open();
                        asistencia = LlenaAsistencia(cmd);
                        Conexion.Close();

                        return asistencia;
                    }
                }
            }
            catch { return null; }
        }

        // GET: api/Asistencia/5
        public IEnumerable<Asistencia> Get(string matricula, string materia, string año, string periodo)
        {
            string stringSQL = "";
            List<Asistencia> asistencia = new List<Asistencia>();

            stringSQL = $"select * " +
                        $"from asistencia asi " +
                        $"inner join alumnos a on a.matricula = asi.matricula " +
                        $"inner join materias m on a.c_carrera = m.c_carrera and m.clave_materia = asi.clave_materia " +
                        $"where asi.matricula = @matricula and clave_materia = @materia and asi.ano = @año, and asi.no_cuatrimestre = asi.periodo " +
                        $"order by m.orden, asi.fecha";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("matricula", matricula));
                        cmd.Parameters.Add(new SqlParameter("año", año));
                        cmd.Parameters.Add(new SqlParameter("periodo", periodo));

                        Conexion.Open();
                        asistencia = LlenaAsistencia(cmd);
                        Conexion.Close();

                        return asistencia;
                    }
                }
            }
            catch { return null; }
        }

        // POST: api/Asistencia
        public bool Post([FromBody]Asistencia objeto)
        {
            string stringSQL = "";
            stringSQL = $"insert into asistencia (" +
                        $"Clave_Instituto, Matricula, Clave_Materia, " +
                        $"Turno, Dia, Hora, Ano, No_Cuatrimestre, " +
                        $"Fecha_Falta, Fecha_Reporta, Usuario, estatus)" +
                        $"values(" +
                        $"@Clave_Instituto, @Matricula, @Clave_Materia, " +
                        $"@Turno, @Dia, @Hora, @Ano, @No_Cuatrimestre, " +
                        $"@Fecha_Falta, @Fecha_Reporta, @Usuario, @estatus)" +
                        $")";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("Clave_Instituto", objeto.Clave_Instituto));
                        cmd.Parameters.Add(new SqlParameter("Matricula", objeto.Matricula));
                        cmd.Parameters.Add(new SqlParameter("Clave_Materia", objeto.Clave_Materia));
                        cmd.Parameters.Add(new SqlParameter("Turno", objeto.Turno));
                        cmd.Parameters.Add(new SqlParameter("Dia", objeto.Dia));
                        cmd.Parameters.Add(new SqlParameter("Hora", objeto.Hora));
                        cmd.Parameters.Add(new SqlParameter("Ano", objeto.Ano));
                        cmd.Parameters.Add(new SqlParameter("No_Cuatrimestre", objeto.No_Cuatrimestre));
                        cmd.Parameters.Add(new SqlParameter("Fecha_Falta", objeto.Fecha_Reporta));
                        cmd.Parameters.Add(new SqlParameter("Fecha_Reporta", objeto.Fecha_Reporta));
                        cmd.Parameters.Add(new SqlParameter("Usuario", objeto.Usuario));
                        cmd.Parameters.Add(new SqlParameter("estatus", objeto.estatus));
                        cmd.Parameters.Add(new SqlParameter("id", objeto.id));
                        
                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }

        }

        // PUT: api/Asistencia/5
        public bool Put(int id, [FromBody]Asistencia objeto)
        {
            string stringSQL = "";
            stringSQL = $"update asistencia set" +
                        $"Clave_Instituto = @Clave_Instituto, " +
                        $"Matricula = @Matricula, " +
                        $"Clave_Materia = @Clave_Materia, " +
                        $"Turno = @Turno, " +
                        $"Dia = @Dia, " +
                        $"Hora = @Hora, " +
                        $"Ano = @Ano, " +
                        $"No_Cuatrimestre = @No_Cuatrimestre, " +
                        $"Fecha_Falta = @Fecha_Falta, " +
                        $"Fecha_Reporta = @Fecha_Reporta, " +
                        $"Usuario = @Usuario, " +
                        $"estatus = @estatus, " +
                        $"where " +
                        $"id = @id";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("Clave_Instituto", objeto.Clave_Instituto));
                        cmd.Parameters.Add(new SqlParameter("Matricula", objeto.Matricula));
                        cmd.Parameters.Add(new SqlParameter("Clave_Materia", objeto.Clave_Materia));
                        cmd.Parameters.Add(new SqlParameter("Turno", objeto.Turno));
                        cmd.Parameters.Add(new SqlParameter("Dia", objeto.Dia));
                        cmd.Parameters.Add(new SqlParameter("Hora", objeto.Hora));
                        cmd.Parameters.Add(new SqlParameter("Ano", objeto.Ano));
                        cmd.Parameters.Add(new SqlParameter("No_Cuatrimestre", objeto.No_Cuatrimestre));
                        cmd.Parameters.Add(new SqlParameter("Fecha_Falta", objeto.Fecha_Reporta));
                        cmd.Parameters.Add(new SqlParameter("Fecha_Reporta", objeto.Fecha_Reporta));
                        cmd.Parameters.Add(new SqlParameter("Usuario", objeto.Usuario));
                        cmd.Parameters.Add(new SqlParameter("estatus", objeto.estatus));
                        cmd.Parameters.Add(new SqlParameter("id", objeto.id));

                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // DELETE: api/Asistencia/5
        public bool Delete(Asistencia objeto)
        {
            string stringSQL = "";
            stringSQL = $"delete asistencia " +
                        $"where " +
                        $"id = @id";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("id", objeto.id));

                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        private List<Asistencia> LlenaAsistencia(SqlCommand command)
        {
            List<Asistencia> asistencia = new List<Asistencia>();

            using (SqlDataReader res = command.ExecuteReader())
            {
                if (res.HasRows)
                while (res.Read())
                {
                    Asistencia registro = new Asistencia();
                    if (!string.IsNullOrEmpty(res[0].ToString()))
                        registro.Clave_Instituto = res[0].ToString().Trim(); ;
                    if (!string.IsNullOrEmpty(res[1].ToString()))
                        registro.Matricula = Convert.ToInt32(res[1]);
                    if (!string.IsNullOrEmpty(res[2].ToString()))
                        registro.Clave_Materia = res[2].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[3].ToString()))
                        registro.Turno = res[3].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[4].ToString()))
                        registro.Dia = res[4].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[5].ToString()))
                        registro.Hora = Convert.ToInt32(res[5]);
                    if (!string.IsNullOrEmpty(res[6].ToString()))
                        registro.Ano = Convert.ToInt32(res[6]);
                    if (!string.IsNullOrEmpty(res[7].ToString()))
                        registro.No_Cuatrimestre = Convert.ToInt32(res[7]);
                    if (!string.IsNullOrEmpty(res[8].ToString()))
                        registro.Fecha_Falta = res[8].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[9].ToString()))
                        registro.Fecha_Reporta = Convert.ToDateTime(res[9]);
                    if (!string.IsNullOrEmpty(res[10].ToString()))
                        registro.Usuario = res[10].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[11].ToString()))
                        registro.estatus = res[11].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[12].ToString()))
                        registro.id = Convert.ToInt32(res[12]);
                    asistencia.Add(registro);
                }
            }
            return asistencia;
        }
    }
}
