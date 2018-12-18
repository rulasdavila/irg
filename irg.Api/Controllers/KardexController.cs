namespace irg.Api.Controllers
{
    using irg.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Web.Http;

    public class KardexController : ApiController
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string stringSQL = "";

        // GET: api/Kardex
        public IEnumerable<Kardex> Get(string matricula)
        {
            string stringSQL = "";
            List<Kardex> kardex = new List<Kardex>();

            stringSQL = $"select * " +
                        $"from cardex c " +
                        $"inner join alumnos a on a.matricula = c.matricula " +
                        $"inner join materias m on a.c_carrera = m.c_carrera and m.clave_materia = c.clave_materia " +
                        $"where c.matricula = @matricula and (m.clave_area = 'TC' or m.clave_area = a.area) " +
                        $"order by m.orden";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("matricula", matricula));
                        Conexion.Open();
                        kardex = LlenaMaterias(cmd);
                        Conexion.Close();

                        return kardex;
                    }
                }
            }
            catch { return null; }
        }

        // GET: api/Kardex/5
        public IEnumerable<Kardex> Get(string matricula, string año, string periodo)
        {
            string stringSQL = "";
            List<Kardex> kardex = new List<Kardex>();

            stringSQL = $"select * " +
                        $"from cardex c " +
                        $"inner join alumnos a on a.matricula = c.matricula " +
                        $"inner join materias m on a.c_carrera = m.c_carrera and m.clave_materia = c.clave_materia " +
                        $"where c.matricula = @matricula and (m.clave_area = 'TC' or m.clave_area = a.area) and " +
                        $"c.ano = @año and c.no_cuatrimestre = @periodo " +
                        $"order by m.orden";
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
                        kardex = LlenaMaterias(cmd);
                        Conexion.Close();
                        return kardex;
                    }
                }
            }
            catch { return null; }
        }

        // POST: api/Kardex
        public bool Post([FromBody]Kardex objeto)
        {
            stringSQL = $"insert into cardex (" +
                        $"Clave_Instituto, matricula, clave_materia, turno, " +
                        $"dia, hora, Salon, Bloque, " +
                        $"clave_forma, ano, no_cuatrimestre, fecha_otros, oportunidad, " +
                        $"calificacion_1, calificacion_2, calificacion_3, calificacion_4, " +
                        $"Calificacion_5, Calificacion_6, Calificacion_7, Calificacion_8, " +
                        $"Calificacion_9, Calificacion_10, Calificacion_11, Calificacion_12, " +
                        $"final, Especial, Estatus, VC1, " +
                        $"VC2, VC3, VC4, VC5, " +
                        $"VC6, VC7, VC8, VC9, " +
                        $"VC10, VC11, VC12, VCF, " +
                        $"Registrado, Academia_Nivel, Fecha_Alta, Fecha_UMov, FinalLetra) " +
                        $"values (" +
                        $"@Clave_Instituto, @matricula, @clave_materia, @turno, " +
                        $"@dia, @hora, @Salon, @Bloque, " +
                        $"@clave_forma, @año, @no_cuatrimestre, @fecha_otros, @oportunidad, " +
                        $"@calificacion_1, @calificacion_2, @calificacion_3, @calificacion_4, " +
                        $"@Calificacion_5, @Calificacion_6, @Calificacion_7, @Calificacion_8, " +
                        $"@Calificacion_9, @Calificacion_10, @Calificacion_11, @Calificacion_12, " +
                        $"@final, @Especial, @Estatus, @VC1, " +
                        $"@VC2, @VC3, @VC4, @VC5, " +
                        $"@VC6, @VC7, @VC8, @VC9, " +
                        $"@VC10, @VC11, @VC12, @VCF, " +
                        $"@Registrado, @Academia_Nivel, @Fecha_Alta, @Fecha_UMov, @FinalLetra)";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("Clave_Instituto", objeto.Clave_Instituto));
                        cmd.Parameters.Add(new SqlParameter("matricula", objeto.matricula));
                        cmd.Parameters.Add(new SqlParameter("clave_materia", objeto.clave_materia));
                        cmd.Parameters.Add(new SqlParameter("turno", objeto.turno));
                        cmd.Parameters.Add(new SqlParameter("dia", objeto.dia));
                        cmd.Parameters.Add(new SqlParameter("hora", objeto.hora));
                        cmd.Parameters.Add(new SqlParameter("Salon", objeto.Salon));
                        cmd.Parameters.Add(new SqlParameter("Bloque", objeto.Bloque));
                        cmd.Parameters.Add(new SqlParameter("clave_forma", objeto.clave_forma));
                        cmd.Parameters.Add(new SqlParameter("año", objeto.ano));
                        cmd.Parameters.Add(new SqlParameter("no_cuatrimestre", objeto.no_cuatrimestre));
                        cmd.Parameters.Add(new SqlParameter("fecha_otros", objeto.fecha_otros));
                        cmd.Parameters.Add(new SqlParameter("oportunidad", objeto.oportunidad));
                        cmd.Parameters.Add(new SqlParameter("calificacion_1", objeto.calificacion_1));
                        cmd.Parameters.Add(new SqlParameter("calificacion_2", objeto.calificacion_2));
                        cmd.Parameters.Add(new SqlParameter("calificacion_3", objeto.calificacion_3));
                        cmd.Parameters.Add(new SqlParameter("calificacion_4", objeto.calificacion_4));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_5", objeto.Calificacion_5));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_6", objeto.Calificacion_6));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_7", objeto.Calificacion_7));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_8", objeto.Calificacion_8));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_9", objeto.Calificacion_9));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_10", objeto.Calificacion_10));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_11", objeto.Calificacion_11));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_12", objeto.Calificacion_12));
                        cmd.Parameters.Add(new SqlParameter("final", objeto.final));
                        cmd.Parameters.Add(new SqlParameter("Especial", objeto.Especial));
                        cmd.Parameters.Add(new SqlParameter("Estatus", objeto.Estatus));
                        cmd.Parameters.Add(new SqlParameter("VC1", objeto.VC1));
                        cmd.Parameters.Add(new SqlParameter("VC2", objeto.VC2));
                        cmd.Parameters.Add(new SqlParameter("VC3", objeto.VC3));
                        cmd.Parameters.Add(new SqlParameter("VC4", objeto.VC4));
                        cmd.Parameters.Add(new SqlParameter("VC5", objeto.VC5));
                        cmd.Parameters.Add(new SqlParameter("VC6", objeto.VC6));
                        cmd.Parameters.Add(new SqlParameter("VC7", objeto.VC7));
                        cmd.Parameters.Add(new SqlParameter("VC8", objeto.VC8));
                        cmd.Parameters.Add(new SqlParameter("VC9", objeto.VC9));
                        cmd.Parameters.Add(new SqlParameter("VC10", objeto.VC10));
                        cmd.Parameters.Add(new SqlParameter("VC11", objeto.VC11));
                        cmd.Parameters.Add(new SqlParameter("VC12", objeto.VC12));
                        cmd.Parameters.Add(new SqlParameter("VCF", objeto.VCF));
                        cmd.Parameters.Add(new SqlParameter("Registrado", objeto.Registrado));
                        cmd.Parameters.Add(new SqlParameter("Academia_Nivel", objeto.Academia_Nivel));
                        cmd.Parameters.Add(new SqlParameter("Fecha_Alta", objeto.Fecha_Alta));
                        cmd.Parameters.Add(new SqlParameter("Fecha_UMov", objeto.Fecha_UMov));
                        cmd.Parameters.Add(new SqlParameter("FinalLetra", objeto.FinalLetra));

                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // PUT: api/Kardex/5
        public bool Put([FromBody]Kardex objeto)
        {
            stringSQL = $"update cardex set " +
                        $"Clave_Instituto = @Clave_Instituto, " +
                        $"matricula = @matricula, " +
                        $"clave_materia = @clave_materia, " +
                        $"turno = @turno, " +
                        $"dia = @dia, " +
                        $"hora = @hora, " +
                        $"Salon = @Salon, " +
                        $"Bloque = @Bloque, " +
                        $"clave_forma = @clave_forma, " +
                        $"año = @ano, " +
                        $"no_cuatrimestre = @no_cuatrimestre, " +
                        $"fecha_otros = @fecha_otros, " +
                        $"oportunidad = @oportunidad, " +
                        $"calificacion_1 = @calificacion_1, " +
                        $"calificacion_2 = @calificacion_2, " +
                        $"calificacion_3 = @calificacion_3, " +
                        $"calificacion_4 = @calificacion_4, " +
                        $"Calificacion_5 = @Calificacion_5, " +
                        $"Calificacion_6 = @Calificacion_6, " +
                        $"Calificacion_7 = @Calificacion_7, " +
                        $"Calificacion_8 = @Calificacion_8, " +
                        $"Calificacion_9 = @Calificacion_9, " +
                        $"Calificacion_10 = @Calificacion_10, " +
                        $"Calificacion_11 = @Calificacion_11, " +
                        $"Calificacion_12 = @Calificacion_12, " +
                        $"final = @final, " +
                        $"Especial = @Especial, " +
                        $"Estatus = @Estatus, " +
                        $"VC1 = @VC1, " +
                        $"VC2 = @VC2, " +
                        $"VC3 = @VC3, " +
                        $"VC4 = @VC4, " +
                        $"VC5 = @VC5, " +
                        $"VC6 = @VC6, " +
                        $"VC7 = @VC7, " +
                        $"VC8 = @VC8, " +
                        $"VC9 = @VC9, " +
                        $"VC10 = @VC10, " +
                        $"VC11 = @VC11, " +
                        $"VC12 = @VC12, " +
                        $"VCF = @VCF, " +
                        $"Registrado = @Registrado, " +
                        $"Academia_Nivel = @Academia_Nivel, " +
                        $"Fecha_Alta = @Fecha_Alta, " +
                        $"Fecha_UMov = @Fecha_UMov, " +
                        $"FinalLetra = @FinalLetra" +
                        $"where " +
                        $"matricula = @matricula and " +
                        $"clave_materia = @clave_materia and " +
                        $"turno = @turno and " +
                        $"dia = @dia and " +
                        $"hora = @hora and " +
                        $"Salon = @Salon and " +
                        $"Bloque = @Bloque and " +
                        $"clave_forma = @clave_forma and " +
                        $"año = @ano and " +
                        $"no_cuatrimestre = @no_cuatrimestre";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("Clave_Instituto", objeto.Clave_Instituto));
                        cmd.Parameters.Add(new SqlParameter("matricula", objeto.matricula));
                        cmd.Parameters.Add(new SqlParameter("clave_materia", objeto.clave_materia));
                        cmd.Parameters.Add(new SqlParameter("turno", objeto.turno));
                        cmd.Parameters.Add(new SqlParameter("dia", objeto.dia));
                        cmd.Parameters.Add(new SqlParameter("hora", objeto.hora));
                        cmd.Parameters.Add(new SqlParameter("Salon", objeto.Salon));
                        cmd.Parameters.Add(new SqlParameter("Bloque", objeto.Bloque));
                        cmd.Parameters.Add(new SqlParameter("clave_forma", objeto.clave_forma));
                        cmd.Parameters.Add(new SqlParameter("año", objeto.ano));
                        cmd.Parameters.Add(new SqlParameter("no_cuatrimestre", objeto.no_cuatrimestre));
                        cmd.Parameters.Add(new SqlParameter("fecha_otros", objeto.fecha_otros));
                        cmd.Parameters.Add(new SqlParameter("oportunidad", objeto.oportunidad));
                        cmd.Parameters.Add(new SqlParameter("calificacion_1", objeto.calificacion_1));
                        cmd.Parameters.Add(new SqlParameter("calificacion_2", objeto.calificacion_2));
                        cmd.Parameters.Add(new SqlParameter("calificacion_3", objeto.calificacion_3));
                        cmd.Parameters.Add(new SqlParameter("calificacion_4", objeto.calificacion_4));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_5", objeto.Calificacion_5));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_6", objeto.Calificacion_6));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_7", objeto.Calificacion_7));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_8", objeto.Calificacion_8));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_9", objeto.Calificacion_9));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_10", objeto.Calificacion_10));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_11", objeto.Calificacion_11));
                        cmd.Parameters.Add(new SqlParameter("Calificacion_12", objeto.Calificacion_12));
                        cmd.Parameters.Add(new SqlParameter("final", objeto.final));
                        cmd.Parameters.Add(new SqlParameter("Especial", objeto.Especial));
                        cmd.Parameters.Add(new SqlParameter("Estatus", objeto.Estatus));
                        cmd.Parameters.Add(new SqlParameter("VC1", objeto.VC1));
                        cmd.Parameters.Add(new SqlParameter("VC2", objeto.VC2));
                        cmd.Parameters.Add(new SqlParameter("VC3", objeto.VC3));
                        cmd.Parameters.Add(new SqlParameter("VC4", objeto.VC4));
                        cmd.Parameters.Add(new SqlParameter("VC5", objeto.VC5));
                        cmd.Parameters.Add(new SqlParameter("VC6", objeto.VC6));
                        cmd.Parameters.Add(new SqlParameter("VC7", objeto.VC7));
                        cmd.Parameters.Add(new SqlParameter("VC8", objeto.VC8));
                        cmd.Parameters.Add(new SqlParameter("VC9", objeto.VC9));
                        cmd.Parameters.Add(new SqlParameter("VC10", objeto.VC10));
                        cmd.Parameters.Add(new SqlParameter("VC11", objeto.VC11));
                        cmd.Parameters.Add(new SqlParameter("VC12", objeto.VC12));
                        cmd.Parameters.Add(new SqlParameter("VCF", objeto.VCF));
                        cmd.Parameters.Add(new SqlParameter("Registrado", objeto.Registrado));
                        cmd.Parameters.Add(new SqlParameter("Academia_Nivel", objeto.Academia_Nivel));
                        cmd.Parameters.Add(new SqlParameter("Fecha_Alta", objeto.Fecha_Alta));
                        cmd.Parameters.Add(new SqlParameter("Fecha_UMov", objeto.Fecha_UMov));
                        cmd.Parameters.Add(new SqlParameter("FinalLetra", objeto.FinalLetra));

                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        // DELETE: api/Kardex/5
        public bool Delete(Kardex objeto)
        {
            stringSQL = $"delete cardex " +
                        $"where " +
                        $"matricula = @matricula and " +
                        $"clave_materia = @clave_materia and " +
                        $"turno = @turno and " +
                        $"dia = @dia and " +
                        $"hora = @hora and " +
                        $"Salon = @Salon and " +
                        $"Bloque = @Bloque and " +
                        $"clave_forma = @clave_forma and " +
                        $"año = @ano and " +
                        $"no_cuatrimestre = @no_cuatrimestre";
            try
            {
                using (SqlConnection Conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("matricula", objeto.matricula));
                        cmd.Parameters.Add(new SqlParameter("clave_materia", objeto.clave_materia));
                        cmd.Parameters.Add(new SqlParameter("turno", objeto.turno));
                        cmd.Parameters.Add(new SqlParameter("dia", objeto.dia));
                        cmd.Parameters.Add(new SqlParameter("hora", objeto.hora));
                        cmd.Parameters.Add(new SqlParameter("Salon", objeto.Salon));
                        cmd.Parameters.Add(new SqlParameter("Bloque", objeto.Bloque));
                        cmd.Parameters.Add(new SqlParameter("clave_forma", objeto.clave_forma));
                        cmd.Parameters.Add(new SqlParameter("año", objeto.ano));
                        cmd.Parameters.Add(new SqlParameter("no_cuatrimestre", objeto.no_cuatrimestre));

                        Conexion.Open();
                        cmd.ExecuteNonQueryAsync();
                        Conexion.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        private List<Kardex> LlenaMaterias(SqlCommand command)
        {
            List<Kardex> kardex = new List<Kardex>();

            using (SqlDataReader res = command.ExecuteReader())
            {
                while (res.Read())
                {
                    Kardex registro = new Kardex();
                    if (!string.IsNullOrEmpty(res[0].ToString()))
                        registro.Clave_Instituto = res[0].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[1].ToString()))
                        registro.matricula = Convert.ToInt32(res[1]);
                    if (!string.IsNullOrEmpty(res[2].ToString()))
                        registro.clave_materia = res[2].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[3].ToString()))
                        registro.turno = res[3].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[4].ToString()))
                        registro.dia = res[4].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[5].ToString()))
                        registro.hora = res[5].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[6].ToString()))
                        registro.Salon = res[6].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[7].ToString()))
                        registro.Bloque = res[7].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[8].ToString()))
                        registro.clave_forma = res[8].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[9].ToString()))
                        registro.ano = Convert.ToInt32(res[9]);
                    if (!string.IsNullOrEmpty(res[10].ToString()))
                        registro.no_cuatrimestre = res[10].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[11].ToString()))
                        registro.fecha_otros = res[11].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[12].ToString()))
                        registro.oportunidad = res[12].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[13].ToString()))
                        registro.calificacion_1 = Convert.ToSingle(res[13]);
                    if (!string.IsNullOrEmpty(res[14].ToString()))
                        registro.calificacion_2 = Convert.ToSingle(res[14]);
                    if (!string.IsNullOrEmpty(res[15].ToString()))
                        registro.calificacion_3 = Convert.ToSingle(res[15]);
                    if (!string.IsNullOrEmpty(res[16].ToString()))
                        registro.calificacion_4 = Convert.ToSingle(res[16]);
                    if (!string.IsNullOrEmpty(res[17].ToString()))
                        registro.Calificacion_5 = Convert.ToSingle(res[17]);
                    if (!string.IsNullOrEmpty(res[18].ToString()))
                        registro.Calificacion_6 = Convert.ToSingle(res[18]);
                    if (!string.IsNullOrEmpty(res[19].ToString()))
                        registro.Calificacion_7 = Convert.ToSingle(res[19]);
                    if (!string.IsNullOrEmpty(res[20].ToString()))
                        registro.Calificacion_8 = Convert.ToSingle(res[20]);
                    if (!string.IsNullOrEmpty(res[21].ToString()))
                        registro.Calificacion_9 = Convert.ToSingle(res[21]);
                    if (!string.IsNullOrEmpty(res[22].ToString()))
                        registro.Calificacion_10 = Convert.ToSingle(res[22]);
                    if (!string.IsNullOrEmpty(res[23].ToString()))
                        registro.Calificacion_11 = Convert.ToSingle(res[23]);
                    if (!string.IsNullOrEmpty(res[24].ToString()))
                        registro.Calificacion_12 = Convert.ToSingle(res[24]);
                    if (!string.IsNullOrEmpty(res[25].ToString()))
                        registro.final = Convert.ToSingle(res[25]);
                    if (!string.IsNullOrEmpty(res[26].ToString()))
                        registro.Especial = res[26].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[27].ToString()))
                        registro.Estatus = res[27].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[28].ToString()))
                        registro.VC1 = res[28].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[29].ToString()))
                        registro.VC2 = res[29].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[30].ToString()))
                        registro.VC3 = res[30].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[31].ToString()))
                        registro.VC4 = res[31].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[32].ToString()))
                        registro.VC5 = res[32].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[33].ToString()))
                        registro.VC6 = res[33].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[34].ToString()))
                        registro.VC7 = res[34].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[35].ToString()))
                        registro.VC8 = res[35].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[36].ToString()))
                        registro.VC9 = res[36].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[37].ToString()))
                        registro.VC10 = res[37].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[38].ToString()))
                        registro.VC11 = res[38].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[39].ToString()))
                        registro.VC12 = res[39].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[40].ToString()))
                        registro.VCF = res[40].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[41].ToString()))
                        registro.Registrado = res[41].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[42].ToString()))
                        registro.Academia_Nivel = res[42].ToString().Trim();
                    if (!string.IsNullOrEmpty(res[43].ToString()))
                        registro.Fecha_Alta = Convert.ToDateTime(res[43]);
                    if (!string.IsNullOrEmpty(res[44].ToString()))
                        registro.Fecha_UMov = Convert.ToDateTime(res[44]);
                    if (!string.IsNullOrEmpty(res[45].ToString()))
                        registro.FinalLetra = res[45].ToString().Trim();
                    kardex.Add(registro);
                }
            }
            return kardex;
        }
    }
}
