using irg.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace irg.Api.Controllers
{
    public class BancoBajioController : ApiController
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //// GET: api/BancoBajio
        public BancosBbConsulta Get([FromBody]string objeto)
        {
            string stringSQL = "";
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            List<BancosBbConsulta> costos = new List<BancosBbConsulta>();

            BancosBbLog registro = new BancosBbLog();
            string matricula = string.Empty;
            string mes = string.Empty;
            Concepto datosConcepto = new Concepto();
            List<Pagos> pagosRealizados = new List<Pagos>();
            string concepto;
            string año = string.Empty;
            string periodo = string.Empty;
            decimal pagado = 0;
            int liquidado = 0;

            /*  Validar Datos Correctos de sitio web
             *  Obtener Datos del Concepto
             *  Validar Si el concepto esta cubierto
             *  Responder
             * */
            #region Deserializa Objeto
            //concepto/matricula/año/periodo/mes
            registro = (BancosBbLog)Newtonsoft.Json.JsonConvert.DeserializeObject(objeto);
                string[] datos = registro.referencia.Split('/');
                matricula = datos[1];
                mes = datos[5];
                concepto = datos[0];
                año = datos[3];
                periodo = datos[4];
            #endregion
            
            #region Obtener datos Concepto

            stringSQL = $"select c.clave_instituto, c.clave_concepto, c.nombre_concepto, c.costo, c.recargos, " +
                        $"c.c_carrera, c.abonos, c.obliga_inscripcion, repetible, c.diavencimiento " +
                        $"from concepto c" +
                        $"inner join alumnos a on a.c_carrera = c.c_carrera or c.c_carrera = '***'" +
                        $"where c.nombre_concepto like 'concepto%'";
            try
            {
                using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("concepto", concepto));
                    Conexion.Open();
                    using (SqlDataReader res = cmd.ExecuteReader())
                    {
                        res.Read();
                        datosConcepto.Clave_Instituto = res[0].ToString();
                        datosConcepto.clave_concepto = res[1].ToString();
                        datosConcepto.nombre_concepto = res[2].ToString();
                        datosConcepto.costo = Convert.ToDecimal(res[3]);
                        datosConcepto.Recargos = Convert.ToDecimal(res[4]);
                        datosConcepto.C_Carrera = res[5].ToString();
                        datosConcepto.Abonos = res[6].ToString();
                        datosConcepto.Obliga_Inscripcion = res[7].ToString();
                        datosConcepto.Repetible = res[8].ToString();
                        datosConcepto.DiaVencimiento = Convert.ToInt32(res[9]);
                    }
                    Conexion.Close();
                    if ( datosConcepto.clave_concepto == "-1")
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return null;
            }
            #endregion

            #region Obtener Datos Recibo a Pagar
            stringSQL = $"select matricula, clave_concepto, pagado " +
                        $"from pagos " +
                        $"where matricula = @matricula and " +
                        $"      ano = @año and " +
                        $"      no_cuatrimestre = @periodo and " +
                        $"      substring(clave_concepto,1,2) = @concepto and " +
                        $"      substring(clave_concepto,3,2) = @mes and " +
                        $"      cancelado = 0";

            try
            {
                using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("matricula", matricula));
                    cmd.Parameters.Add(new SqlParameter("mes", mes));
                    cmd.Parameters.Add(new SqlParameter("concepto", concepto));
                    cmd.Parameters.Add(new SqlParameter("año", año));
                    cmd.Parameters.Add(new SqlParameter("periodo", periodo));
                    Conexion.Open();

                    using (SqlDataReader res = cmd.ExecuteReader())
                    {
                        Pagos pago = new Pagos();
                        while (res.Read())
                        {
                            pago.Matricula = Convert.ToInt32(res[0]);
                            pago.Clave_Concepto = res[1].ToString();
                            pago.Pagado = Convert.ToDecimal(res[2]);
                            pagosRealizados.Add(pago);
                        }
                    }
                    Conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return null;
            }
            #endregion

            #region Genera Cantidades
            pagado = pagosRealizados.Sum(x => x.Pagado);
            //liquidado = Convert.ToInt32(pagosRealizados.Sum(x => x.Clave_Concepto.Substring(5,1)));
            liquidado = pagosRealizados.Sum(x => 
                                                 Convert.ToInt32(x.Clave_Concepto.Substring(
                                                     5 + Convert.ToInt32(x.Clave_Concepto.Substring(5, 1) + 1), 1))
                                           );
            #endregion
            return null;
        }

        //// GET: api/BancoBajio/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/BancoBajio
        public void Post([FromBody]string objeto)
        {
            string stringSQL = "";
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            List<BancosBbConsulta> costos = new List<BancosBbConsulta>();

            BancosBbLog registro = new BancosBbLog();
            string matricula = string.Empty;
            string mes = string.Empty;
            string concepto = string.Empty;
            string año = string.Empty;
            string periodo = string.Empty;
            decimal pagado = 0;
            int liquidado = 0;
            string claveConcepto = string.Empty;

            registro = (BancosBbLog)Newtonsoft.Json.JsonConvert.DeserializeObject(objeto);
            string[] datos = registro.referencia.Split('/');
            matricula = datos[0];
            mes = datos[1];
            concepto = datos[2];
            año = datos[3];
            periodo = datos[4];

            stringSQL = $"select val(isnull(p.clave_concepto, '-1'))" +
                        $"from pagos p" +
                        $"inner join concepto c on c.clave_concepto = substring(p.clave_concepto)" +
                        $"where p.matricula = @matricula and p.ano = @año and p.no_cuatrimestre = @periodo and p.cancelado = 0" +
                        $"order by p.ano, p.no_cuatrimestre, p.fecha";
            try
            {
                using (SqlCommand cmd = new SqlCommand(stringSQL, Conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("matricula", matricula));
                    cmd.Parameters.Add(new SqlParameter("mes", mes));
                    cmd.Parameters.Add(new SqlParameter("concepto", mes));
                    cmd.Parameters.Add(new SqlParameter("ano", mes));
                    cmd.Parameters.Add(new SqlParameter("periodo", mes));
                    Conexion.Open();

                    using (SqlDataReader res = cmd.ExecuteReader())
                    {

                        claveConcepto = res[0].ToString();
                    }
                    Conexion.Close();
                    if (claveConcepto == "-1")
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Conexion.Close();
                throw;
            }
            
            //stringSQL = $"select bsd.concepto, c.costo, c.recargos, upper(ca.n_carrera), ca.cuatrimestres, " +
            //            $"rtrim(a.apellido_p) + ' ' + rtrim(a.apellido_m) + ' ' + rtrim(a.nombre_1) + ' ' + rtrim(a.nombre_2), c.tipo," +
            //            $"rtrim(ca.c_carrera), rtrim(c.clave_concepto), rtrim(c.diavencimiento)" +
            //            $"from  bancosbbservicios bs" +
            //            $"inner join bancosbbserviciosdetalle bsd on bs.servicio = bsd.servicio" +
            //            $"inner join concepto c on bsd.concepto = c.nombre_concepto" +
            //            $"inner join alumnos a on c.c_carrera = a.c_carrera" +
            //            $"inner join carreras ca on a.c_carrera = ca.c_carrera" +
            //            $"where bs.servicio = @servicio and a.matricula = @referencia" +
            //            $"order by bsd.orden";
            //try
            //{
            //#region Consulta Conceptos incluidos en servicio _Variable_ costos
            //SqlCommand cmd = new SqlCommand(stringSQL, Conexion);
            //cmd.Parameters.Add(new SqlParameter("servicio", servicio));
            //cmd.Parameters.Add(new SqlParameter("referencia", referencia));
            //Conexion.Open();

            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.HasRows == false) return null;

            //while (reader.Read())
            //{
            //    BancosBbConsulta costo = new BancosBbConsulta();
            //    costo.Concepto = reader[0].ToString().Trim();
            //    costo.Costo = reader[1].ToString().Trim();
            //    costo.Recargos = reader[2].ToString().Trim();
            //    costo.Carrera = reader[3].ToString().Trim();
            //    costo.Cuatrimestres = reader[4].ToString().Trim();
            //    costo.Alumno = reader[5].ToString().Trim();
            //    costo.Tipo = reader[6].ToString().Trim();
            //    costo.ClaveCarrera = reader[7].ToString().Trim();
            //    costo.ClaveConcepto = reader[8].ToString().Trim();
            //    costo.Vencimiento = reader[9].ToString().Trim();
            //    costos.Add(costo);
            //}
            //Conexion.Close();
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
            //return costos;
            //return new string[] { "value1", "value2" };
        }

        // PUT: api/BancoBajio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BancoBajio/5
        public void Delete(int id)
        {
        }
    }
}
