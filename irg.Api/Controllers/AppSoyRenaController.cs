namespace irg.Api.Controllers
{
    using irg.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Web.Http;

    public class AppSoyRenaController : ApiController
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: api/AppSoyRena
        public IEnumerable<AppSoyRena> Get()
        {
            string stringSQL = "";
            List<AppSoyRena> appSoyRena = new List<AppSoyRena>();

            stringSQL = $"select * " +
                        $"from appsoyrena " +
                        $"order by id";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        Conexion.Open();
                        appSoyRena = LlenaAppSoyRena(cmd);
                        Conexion.Close();

                        return appSoyRena;
                    }
                }
            }
            catch { return null; }
        }

        // GET: api/AppSoyRena/5
        public AppSoyRena Get(int id)
        {
            string stringSQL = "";
            AppSoyRena appSoyRena = new AppSoyRena();

            stringSQL = $"select * " +
                        $"from appsoyrena " +
                        $"where id = @id " +
                        $"order by id";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("id", id));
                        Conexion.Open();
                        appSoyRena = LlenaAppSoyRenaRegistro(cmd);
                        Conexion.Close();
                        return appSoyRena;
                    }
                }
            }
            catch { return null; }
        }

        // GET: api/AppSoyRena/5
        public AppSoyRena Get(string descripcion)
        {
            string stringSQL = "";
            AppSoyRena appSoyRena = new AppSoyRena();

            stringSQL = $"select top 1 * " +
                        $"from appsoyrena " +
                        $"where descripcion = @descripcion ";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("descripcion", descripcion));
                        Conexion.Open();
                        appSoyRena = LlenaAppSoyRenaRegistro(cmd);
                        Conexion.Close();
                        return appSoyRena;
                    }
                }
            }
            catch { return null; }
        }

        // POST: api/AppSoyRena
        public bool Post([FromBody]AppSoyRena objeto)
        {
            string stringSQL = "";
            stringSQL = $"insert into appsoyrena (descripcion, version) " +
                        $"values (@descripcion, @version)";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("descripcion", objeto.descripcion));
                        cmd.Parameters.Add(new SqlParameter("version", objeto.version));

                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // PUT: api/AppSoyRena/5 EDITAR
        public bool Put(int id, [FromBody]AppSoyRena objeto)
        {
            string stringSQL = "";

            stringSQL = $"update appsoyrena set " +
                        $"descripcion = @descripcion, version = @version " +
                        $"where id = @id";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("id", id));
                        cmd.Parameters.Add(new SqlParameter("descripcion", objeto.descripcion));
                        cmd.Parameters.Add(new SqlParameter("version", objeto.version));
                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // DELETE: api/AppSoyRena/5
        public bool Delete(int id)
        {
            string stringSQL = "";

            stringSQL = $"delete from appsoyrena " +
                        $"where id = @id ";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("id", id));
                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        private List<AppSoyRena> LlenaAppSoyRena(SqlCommand command)
        {
            List<AppSoyRena> appSoyRena = new List<AppSoyRena>();

            using (SqlDataReader res = command.ExecuteReader())
            {
                if (res.HasRows)
                    while (res.Read())
                    {
                        AppSoyRena registro = new AppSoyRena();
                        if (!string.IsNullOrEmpty(res[0].ToString()))
                            registro.id = Convert.ToInt32(res[0]);
                        if (!string.IsNullOrEmpty(res[1].ToString()))
                            registro.descripcion = res[1].ToString().Trim();
                        if (!string.IsNullOrEmpty(res[2].ToString()))
                            registro.version = res[2].ToString().Trim();
                        appSoyRena.Add(registro);
                    }
            }
            return appSoyRena;
        }

        private AppSoyRena LlenaAppSoyRenaRegistro(SqlCommand command)
        {
            AppSoyRena appSoyRena = new AppSoyRena();

            using (SqlDataReader res = command.ExecuteReader())
            {
                if (res.HasRows)
                    while (res.Read())
                    {
                        if (!string.IsNullOrEmpty(res[0].ToString()))
                            appSoyRena.id = Convert.ToInt32(res[0]);
                        if (!string.IsNullOrEmpty(res[1].ToString()))
                            appSoyRena.descripcion = res[1].ToString().Trim();
                        if (!string.IsNullOrEmpty(res[2].ToString()))
                            appSoyRena.version = res[2].ToString().Trim();
                    }
            }
            return appSoyRena;
        }
    }
}
