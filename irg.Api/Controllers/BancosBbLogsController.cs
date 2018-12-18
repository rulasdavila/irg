namespace irg.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using irg.Common.Models;
    using irg.Domain.Models;

    public class BancosBbLogsController : ApiController
    {
        private DataContext db = new DataContext();
        string cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string stringSQL = "";

        // GET: api/BancosBbLogs
        public IQueryable<BancosBbLog> GetBancosBbLogs()
        {
            stringSQL = $"select accion, referencia, bancoemisor, serviciobb, monto, formapago, firma, fecha, ip " +
                        $"from bancosbblog " +
                        $"order by id desc";
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand(stringSQL, Conexion);
            try
            {
                Conexion.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == false) return null;

                List<BancosBbLog> registros = new List<BancosBbLog>();
                while (reader.Read())
                {
                    BancosBbLog registro = new BancosBbLog();
                    registro.accion = reader[0].ToString().Trim();
                    registro.referencia = reader[1].ToString().Trim();
                    registro.bancoemisor = reader[2].ToString().Trim();
                    registro.serviciobb = reader[3].ToString().Trim();
                    registro.monto = reader[4].ToString().Trim();
                    registro.formapago = reader[5].ToString().Trim();
                    registro.firma = reader[6].ToString().Trim();
                    registro.fecha = reader[7].ToString().Trim();
                    registro.ip = reader[8].ToString().Trim();
                    
                    registros.Add(registro);
                }
                Conexion.Close();
                Conexion.Dispose();
                return registros.AsQueryable();
            }
            catch (Exception ex)
            {
                Conexion.Close();
                Conexion.Dispose();
                //    return BadRequest(ModelState);

                return null;
            }

            //return db.BancosBbLogs;
        }

        // GET: api/BancosBbLogs/5
        [ResponseType(typeof(BancosBbLog))]
        public async Task<IHttpActionResult> GetBancosBbLog(int id)
        {
            BancosBbLog bancosBbLog = await db.BancosBbLogs.FindAsync(id);
            if (bancosBbLog == null)
            {
                return NotFound();
            }

            return Ok(bancosBbLog);
        }

        // PUT: api/BancosBbLogs/5 EDITAR
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBancosBbLog(int id, BancosBbLog bancosBbLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bancosBbLog.id)
            {
                return BadRequest();
            }

            db.Entry(bancosBbLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancosBbLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BancosBbLogs INSERTAR
        [ResponseType(typeof(BancosBbLog))]
        public Task<IHttpActionResult> PostBancosBbLog(BancosBbLog bancosBbLog)
        {
            //if (bancosBbLog.ip != "200.76.36.117" && bancosBbLog.ip != "177.228.50.7" &&
            //    bancosBbLog.ip != "192.168.200.9" && bancosBbLog.ip != "192.168.0.9")
            ////    return BadRequest("Direccion IP No Valida");

            
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            //OtrosModel encripta = new OtrosModel(); string ip = encripta.GetIPRemote();

            stringSQL = $"insert into bancosbblog " +
                        $"(accion, referencia, bancoemisor, serviciobb, monto, formapago, firma, fecha, ip) " +
                        $"Values " +
                        $"(@accion, @referencia, @bancoemisor, @serviciobb, @monto, @formapago, @firma, getdate(), @ip)";

            SqlCommand cmd = new SqlCommand(stringSQL, Conexion);
            cmd.Parameters.Add(new SqlParameter("accion", bancosBbLog.accion));
            cmd.Parameters.Add(new SqlParameter("referencia", bancosBbLog.referencia));
            cmd.Parameters.Add(new SqlParameter("bancoemisor", bancosBbLog.bancoemisor));
            cmd.Parameters.Add(new SqlParameter("serviciobb", bancosBbLog.serviciobb));
            cmd.Parameters.Add(new SqlParameter("monto", bancosBbLog.monto));
            cmd.Parameters.Add(new SqlParameter("formapago", bancosBbLog.formapago));
            cmd.Parameters.Add(new SqlParameter("firma", bancosBbLog.firma));
            cmd.Parameters.Add(new SqlParameter("firma", bancosBbLog.fecha));
            cmd.Parameters.Add(new SqlParameter("ip", bancosBbLog.ip));

            try
            {
                Conexion.Open();
                cmd.ExecuteNonQueryAsync();
                Conexion.Close();
                Conexion.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                Conexion.Dispose();
                //    return BadRequest(ModelState);

                return null;
            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.BancosBbLogs.Add(bancosBbLog);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = bancosBbLog.id }, bancosBbLog);
        }

        //// DELETE: api/BancosBbLogs/5
        //[ResponseType(typeof(BancosBbLog))]
        //public async Task<IHttpActionResult> DeleteBancosBbLog(int id)
        //{
        //    BancosBbLog bancosBbLog = await db.BancosBbLogs.FindAsync(id);
        //    if (bancosBbLog == null)
        //    {
        //        return NotFound();
        //    }

        //    db.BancosBbLogs.Remove(bancosBbLog);
        //    await db.SaveChangesAsync();

        //    return Ok(bancosBbLog);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BancosBbLogExists(int id)
        {
            return db.BancosBbLogs.Count(e => e.id == id) > 0;
        }
    }


    //#region Bancos
    //#region BB
    //private List<BancosBbConsulta> GetConceptosServicios(string servicio, string referencia)
    //{
    //    string stringSQL = "";
    //    SqlConnection Conexion = new SqlConnection(cadenaConexion);
    //    List<BancosBbConsulta> costos = new List<BancosBbConsulta>();


    //    stringSQL = string.Format(@"
    //                                    select bsd.concepto, c.costo, c.recargos, upper(ca.n_carrera), ca.cuatrimestres, 
    //                                        rtrim(a.apellido_p) + ' ' + rtrim(a.apellido_m) + ' ' + rtrim(a.nombre_1) + ' ' + rtrim(a.nombre_2), c.tipo,
    //                                        rtrim(ca.c_carrera), rtrim(c.clave_concepto), rtrim(c.diavencimiento)
    //                                    from  bancosbbservicios bs 
    //                                    inner join bancosbbserviciosdetalle bsd on bs.servicio = bsd.servicio
    //                                    inner join concepto c on bsd.concepto = c.nombre_concepto
    //                                    inner join alumnos a on c.c_carrera = a.c_carrera
    //                                    inner join carreras ca on a.c_carrera = ca.c_carrera
    //                                    where bs.servicio = @servicio and a.matricula = @referencia
    //                                    order by bsd.orden");
    //    try
    //    {
    //        #region Consulta Conceptos incluidos en servicio _Variable_ costos
    //        SqlCommand cmd = new SqlCommand(stringSQL, Conexion);
    //        cmd.Parameters.Add(new SqlParameter("servicio", servicio));
    //        cmd.Parameters.Add(new SqlParameter("referencia", referencia));
    //        Conexion.Open();

    //        SqlDataReader reader = cmd.ExecuteReader();
    //        if (reader.HasRows == false) return null;

    //        while (reader.Read())
    //        {
    //            BancosBbConsulta costo = new BancosBbConsulta();
    //            costo.Concepto = reader[0].ToString().Trim();
    //            costo.Costo = reader[1].ToString().Trim();
    //            costo.Recargos = reader[2].ToString().Trim();
    //            costo.Carrera = reader[3].ToString().Trim();
    //            costo.Cuatrimestres = reader[4].ToString().Trim();
    //            costo.Alumno = reader[5].ToString().Trim();
    //            costo.Tipo = reader[6].ToString().Trim();
    //            costo.ClaveCarrera = reader[7].ToString().Trim();
    //            costo.ClaveConcepto = reader[8].ToString().Trim();
    //            costo.Vencimiento = reader[9].ToString().Trim();
    //            costos.Add(costo);
    //        }
    //        Conexion.Close();
    //        #endregion
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //    }
    //    return costos;
    //}

    //private PagosMontos GetReglasNegocio(BancosBbLog registro, BancosBbConsulta costo)
    //{
    //    BancosBbLog reg = new BancosBbLog();
    //    List<BancosBbConsulta> costos = new List<BancosBbConsulta>();

    //    MesPagar mes = new MesPagar();
    //    //List<PagosMontos> resultados = new List<PagosMontos>();
    //    PagosMontos resultado = new PagosMontos();

    //    //costos = GetConceptosServicios(registro.ServicioBb, registro.Referencia);
    //    //foreach (BancosBbConsulta costo in costos)
    //    //{

    //    if (costo.Concepto == "COLEGIATURA")
    //    {
    //        PagosModel pago = new PagosModel();
    //        mes = pago.GetColegiaturaXPagar(registro.Referencia);
    //    }
    //    else if (costo.Concepto == "REINSCRIPCION")
    //    {
    //        PagosModel pago = new PagosModel();
    //        mes = pago.GetInscripcionXPagar(registro.Referencia);
    //    }

    //    #region Calcula Becas, Descuentos y Recargos

    //    if (mes != null)
    //    {
    //        resultado.Año = mes.Año;
    //        resultado.Periodo = mes.Periodo.ToString();
    //        resultado.Mes = string.Format("{0:00}", mes.NoMes.ToString());
    //        resultado.MesNombre = mes.Mes;
    //        //resultado.ClaveInstituto = "";
    //        //resultado.DetalleDescuento = "";
    //        //resultado.HorasClase = "";

    //        //PagosMontos resultado = new PagosMontos();

    //        resultado.MontoOriginal = Convert.ToDouble(costo.Costo);
    //        if (mes.Beca > 0)
    //        {
    //            resultado.DescuentoAplicar = 0;
    //            resultado.BecaAplicar = resultado.MontoOriginal * mes.Beca / 100;
    //        }
    //        else
    //        {
    //            resultado.DescuentoAplicar = resultado.MontoOriginal * mes.Descuento / 100;
    //            resultado.BecaAplicar = 0;
    //        }

    //        resultado.RecargoAplicar = Convert.ToDouble(costo.Recargos) * mes.DiasRecargo;
    //        resultado.MontoTotal = resultado.MontoOriginal - resultado.DescuentoAplicar + resultado.RecargoAplicar;

    //        //resultados.Add(resultado);
    //    }
    //    #endregion
    //    return resultado;
    //    //}
    //    //return null;
    //}

    //public string GetServiciosREST(BancosBbLog registro)
    //{
    //    PutServiciosRESTLog(registro);
    //    OtrosModel ip = new OtrosModel(); if (ip.GetIPLogged() == false) return null;

    //    BancosBbLog reg = new BancosBbLog();
    //    List<BancosBbConsulta> costos = new List<BancosBbConsulta>();
    //    List<PagosMontos> resultados = new List<PagosMontos>();
    //    string firma = "";
    //    string bancoKey = "";
    //    string mensaje = "";
    //    string nombre = "";
    //    string comilla = "\"";
    //    string estatus = "";
    //    MesPagar mes = new MesPagar();
    //    bool pagado = false;
    //    double saldo = 0;

    //    #region ValidacionConsulta
    //    //Validaciones de informacion recibida

    //    //registro.Referencia referencia bancaria que genera la sucursal
    //    //registro.ServicioBb Numero asignado para el concepto de pago
    //    //registro.Monto Monto numerico 2 decimales
    //    //registro.Firma Firma verificadora 
    //    //firma = SHA1(accion,"|",referenciabanco_emisor,"|",servicio_bb,"|",monto,"|",forma_pago,"|",llave_banco)
    //    //registro.Accion consulta|pago|reverso
    //    //registro.BancoEmisor 030 valor fijo
    //    //registro.FormaPago efectivo|cargo|tc|xx

    //    if (registro.Accion != "consulta" && registro.Accion != "pago" && registro.Accion != "reverso")
    //    {
    //        //mensaje = "ACCION INCORRECTA";
    //        estatus = "006";
    //        mensaje = "ERROR DE VALIDACION (NO COBRAR)";
    //    }
    //    if (registro.BancoEmisor != "030")
    //    {
    //        //mensaje = "BANCO NO RECONOCIDO (NO COBRAR)";
    //        estatus = "006";
    //        mensaje = "ERROR DE VALIDACION (NO COBRAR)";
    //    }
    //    if (registro.FormaPago != "efectivo" &&
    //        registro.FormaPago != "cargo" &&
    //        registro.FormaPago != "tc" &&
    //        registro.FormaPago != "xx")
    //    {
    //        //mensaje = "TIPO DE PAGO NO RECONOCIDO (NO COBRAR)";
    //        estatus = "006";
    //        mensaje = "ERROR DE VALIDACION (NO COBRAR)";
    //    }

    //    string stringSQL = "";
    //    SqlConnection Conexion = new SqlConnection(cadenaConexion);
    //    stringSQL = string.Format(@"select llaveBanco 
    //                                        from banco_cuentas 
    //                                        where banco = 'BANCO DEL BAJIO'");
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(stringSQL, Conexion);
    //        //cmd.Parameters.Add(new SqlParameter("inicio", inicio));
    //        Conexion.Open();

    //        SqlDataReader reader = cmd.ExecuteReader();
    //        if (reader.HasRows == false) return null;
    //        reader.Read();
    //        bancoKey = reader[0].ToString();
    //        Conexion.Close();
    //    }
    //    catch (Exception)
    //    {
    //        return "FALLA AL LEER LA LLAVE";
    //    }
    //    OtrosModel encripta = new OtrosModel();
    //    firma = encripta.CryptographyGetSHA1(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
    //        registro.Accion, registro.Referencia, registro.BancoEmisor, registro.ServicioBb, registro.Monto, registro.FormaPago, bancoKey));
    //    if (registro.Firma != firma)
    //    {
    //        //mensaje = "FIRMA INCORRECTA(NO COBRAR)";
    //        estatus = "006";
    //        mensaje = "ERROR DE VALIDACION (NO COBRAR)";
    //    }

    //    if (mensaje != "") return mensaje;

    //    #endregion
    //    ////////Consulta de informacion al sistema de pagos

    //    if (mensaje == "")
    //    {
    //        #region AccionConsulta
    //        if (registro.Accion == "consulta" || registro.Accion == "pago")
    //        {
    //            saldo = Convert.ToDouble(registro.Monto);
    //            costos = GetConceptosServicios(registro.ServicioBb, registro.Referencia);
    //            foreach (BancosBbConsulta costo in costos)
    //            {
    //                PagosMontos resultado = GetReglasNegocio(registro, costo);
    //                resultados.Add(resultado);

    //                if (registro.Accion == "pago")
    //                {
    //                    string formaPago = "";
    //                    if (registro.FormaPago == "efectivo")
    //                        formaPago = "EF";
    //                    else if (registro.FormaPago == "cargo")
    //                        formaPago = "TD";
    //                    else if (registro.FormaPago == "tc")
    //                        formaPago = "TC";

    //                    Pago recibo = new Pago();
    //                    recibo.Año = resultado.Año;
    //                    recibo.Beca = string.Format("{0:00}", resultado.BecaAplicar);
    //                    recibo.Cancelado = "0";
    //                    recibo.Cc = costo.ClaveConcepto;
    //                    recibo.Cv = "0";

    //                    if (Convert.ToDouble(resultado.MontoTotal) <= saldo)
    //                    {
    //                        recibo.Li = "1";
    //                    }
    //                    else
    //                    {
    //                        recibo.Li = "0";
    //                    }
    //                    saldo = saldo - Convert.ToDouble(resultado.MontoTotal);

    //                    recibo.Me = string.Format("{0:00}", mes.Mes);
    //                    recibo.Na = (resultado.Abonos + 1).ToString().Trim();
    //                    recibo.Descuento = string.Format("{0:00}", resultado.DescuentoAplicar);

    //                    recibo.ClaveConcepto = string.Concat(recibo.Cc, recibo.Me, recibo.Cv, recibo.Li, recibo.Na, recibo.Beca, recibo.Descuento);
    //                    //recibo.ClaveInstituto = resultado.ClaveInstituto.ToString().Trim();
    //                    recibo.Costo = resultado.MontoTotal;

    //                    //recibo.DetalleDescuento = resultado.DetalleDescuento.Trim();
    //                    recibo.Detalles = string.Concat(costo.Concepto, " ", costo.ClaveCarrera, " ", costo.Cuatrimestres);
    //                    recibo.Estatus = "0";
    //                    recibo.Factura = "";
    //                    recibo.Fecha = DateTime.Now;
    //                    recibo.FechaBanco = string.Format("{0:yyyy/MM/dd}", recibo.Fecha);
    //                    recibo.Folio = "";
    //                    recibo.FolioBancario = "BajioREST";
    //                    recibo.FormaPago = formaPago;
    //                    recibo.HorasClase = resultado.HorasClase.ToString().Trim();
    //                    recibo.Matricula = registro.Referencia.ToString().Trim();
    //                    recibo.Pagado = resultado.MontoTotal;
    //                    recibo.Periodo = resultado.Periodo;
    //                    recibo.Recargos = resultado.RecargoAplicar;
    //                    recibo.TotalCalculado = resultado.MontoTotal;
    //                    recibo.Usuario = "0";

    //                    PagosModel pago = new PagosModel();
    //                    pago.PutPagos(recibo, costo.Tipo);
    //                }
    //            }

    //            if (registro.Accion == "consulta")
    //                if (mes != null)
    //                {
    //                    double original = resultados.Sum(r => r.MontoOriginal);
    //                    double recargos = resultados.Sum(r => r.RecargoAplicar);
    //                    double descuento = resultados.Sum(r => r.DescuentoAplicar + r.BecaAplicar);
    //                    double total = resultados.Sum(r => r.MontoTotal);

    //                    nombre = costos[0].Alumno;
    //                    mensaje = string.Concat("{",
    //                                comilla, "estatus", comilla, ":", comilla, "000", comilla, ",",
    //                                comilla, "mensaje", comilla, ":", comilla, "Recibo vigente y listo para cobrarse", comilla, ",",
    //                                comilla, "accion", comilla, ":", comilla, registro.Accion, comilla, ",",
    //                                comilla, "referencia", comilla, ":", comilla, registro.Referencia, comilla, ",",
    //                                comilla, "monto_original", comilla, ":", comilla, string.Format("{0:0.00}", original), comilla, ",",
    //                                comilla, "recargo_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", recargos), comilla, ",",
    //                                comilla, "descuento_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", descuento), comilla, ",",
    //                                comilla, "monto_a_pagar", comilla, ":", comilla, string.Format("{0:0.00}", total), comilla, ",",
    //                                comilla, "nombre", comilla, ":", comilla, nombre, comilla, "}");

    //                }
    //                else
    //                {
    //                    mensaje = string.Concat("{",
    //                                comilla, "estatus", comilla, ":", comilla, "006", comilla, ",",
    //                                comilla, "mensaje", comilla, ":", comilla, "(no cobrar)", comilla, ",",
    //                                comilla, "accion", comilla, ":", comilla, registro.Accion, comilla, ",",
    //                                comilla, "referencia", comilla, ":", comilla, registro.Referencia, comilla, ",",
    //                                comilla, "monto_original", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                                comilla, "recargo_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                                comilla, "descuento_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                                comilla, "monto_a_pagar", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                                comilla, "nombre", comilla, ":", comilla, nombre, comilla, "}");
    //                }
    //            else if (registro.Accion == "pago")
    //            {

    //            }
    //            return mensaje;
    //        }
    //        #endregion
    //        #region AccionPago
    //        if (registro.Accion == "reverso")
    //        {
    //            costos = GetConceptosServicios(registro.ServicioBb, registro.Referencia);
    //            foreach (BancosBbConsulta costo in costos)
    //            {
    //                PagosMontos resultado = GetReglasNegocio(registro, costo);
    //                resultados.Add(resultado);
    //            }

    //            if (mes != null)
    //            {
    //                double original = resultados.Sum(r => r.MontoOriginal);
    //                double recargos = resultados.Sum(r => r.RecargoAplicar);
    //                double descuento = resultados.Sum(r => r.DescuentoAplicar + r.BecaAplicar);
    //                double total = resultados.Sum(r => r.MontoTotal);
    //                nombre = costos[0].Alumno;
    //                mensaje = string.Concat("{",
    //                            comilla, "estatus", comilla, ":", comilla, "000", comilla, ",",
    //                            comilla, "mensaje", comilla, ":", comilla, "Recibo vigente y listo para cobrarse", comilla, ",",
    //                            comilla, "accion", comilla, ":", comilla, registro.Accion, comilla, ",",
    //                            comilla, "referencia", comilla, ":", comilla, registro.Referencia, comilla, ",",
    //                            comilla, "monto_original", comilla, ":", comilla, string.Format("{0:0.00}", original), comilla, ",",
    //                            comilla, "recargo_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", recargos), comilla, ",",
    //                            comilla, "descuento_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", descuento), comilla, ",",
    //                            comilla, "monto_a_pagar", comilla, ":", comilla, string.Format("{0:0.00}", total), comilla, ",",
    //                            comilla, "nombre", comilla, ":", comilla, nombre, comilla, "}");

    //            }
    //            else
    //            {
    //                mensaje = string.Concat("{",
    //                            comilla, "estatus", comilla, ":", comilla, "006", comilla, ",",
    //                            comilla, "mensaje", comilla, ":", comilla, "(no cobrar)", comilla, ",",
    //                            comilla, "accion", comilla, ":", comilla, registro.Accion, comilla, ",",
    //                            comilla, "referencia", comilla, ":", comilla, registro.Referencia, comilla, ",",
    //                            comilla, "monto_original", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                            comilla, "recargo_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                            comilla, "descuento_aplicado", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                            comilla, "monto_a_pagar", comilla, ":", comilla, string.Format("{0:0.00}", 0), comilla, ",",
    //                            comilla, "nombre", comilla, ":", comilla, nombre, comilla, "}");
    //            }
    //            return mensaje;

    //        }
    //        #endregion
    //        #region AccionReverso
    //        if (registro.Accion == "reverso")
    //        {

    //            return "";
    //        }
    //        #endregion
    //        return "";
    //    }
    //    return "";
    //}

    //private bool PutServiciosRESTLog(BancosBbLog registro)
    //{
    //    string stringSQL = "";
    //    SqlConnection Conexion = new SqlConnection(cadenaConexion);
    //    //OtrosModel encripta = new OtrosModel(); string ip = encripta.GetIPRemote();

    //    stringSQL = string.Format(@"insert into bancosbblog
    //                                        (accion, referencia, bancoemisor, serviciobb, monto, formapago, firma, fecha, ip)
    //                                        Values
    //                                        (@accion, @referencia, @bancoemisor, @serviciobb, @monto, @formapago, @firma, getdate(), @ip)");

    //    SqlCommand cmd = new SqlCommand(stringSQL, Conexion);
    //    cmd.Parameters.Add(new SqlParameter("accion", registro.Accion));
    //    cmd.Parameters.Add(new SqlParameter("referencia", registro.Referencia));
    //    cmd.Parameters.Add(new SqlParameter("bancoemisor", registro.BancoEmisor));
    //    cmd.Parameters.Add(new SqlParameter("serviciobb", registro.ServicioBb));
    //    cmd.Parameters.Add(new SqlParameter("monto", registro.Monto));
    //    cmd.Parameters.Add(new SqlParameter("formapago", registro.FormaPago));
    //    cmd.Parameters.Add(new SqlParameter("firma", registro.Firma));
    //    cmd.Parameters.Add(new SqlParameter("ip", ip));

    //    try
    //    {
    //        Conexion.Open();
    //        cmd.ExecuteNonQuery();
    //        Conexion.Close();
    //        Conexion.Dispose();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        Conexion.Close();
    //        Conexion.Dispose();
    //        return false;
    //    }
    //}
    
    ////private string GetEstatus(TiposDatos.enumBancoBbEstatus tipo, string consulta)
    ////{
    ////    string cad = "";

    ////    if (consulta == "consulta")
    ////    {
    ////        if (tipo == enumBancoBbEstatus.ReferenciaVigente_Cobrar) cad = "Referencia Vigente (Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaPagadaPreviamente_NoCobrar) cad = "Referencia pagada previamente (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.HayRecibosAnterioresPendientes_NoCobrar) cad = "Hay recibo(s) anteriores pendiente(s) de pago (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaCancelada_NoCobrar) cad = "Referencia Cancelada (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaVencida_NoCobrar) cad = "Referencia Vencida (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaNoEncontrada_NoCobrar) cad = "Referencia no Encontrada (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaPersonalizada_NoCobrar) cad = "Pendientes Administrativos (No Cobrar)";
    ////    }
    ////    if (consulta == "pago")
    ////    {
    ////        if (tipo == enumBancoBbEstatus.ReferenciaVigente_Cobrar) cad = "Pago realizado correctamente (Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaPagadaPreviamente_NoCobrar) cad = "Referencia pagada previamente (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.HayRecibosAnterioresPendientes_NoCobrar) cad = "Hay recibo(s) anteriores pendiente(s) de pago (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaCancelada_NoCobrar) cad = "Referencia Cancelada (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaVencida_NoCobrar) cad = "Referencia Vencida (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaNoEncontrada_NoCobrar) cad = "Referencia no Encontrada (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaErrorValidacion_NoCobrar) cad = "El monto de pago no concide (No Cobrar)";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaPersonalizada_NoCobrar) cad = "Pendientes Administrativos (No Cobrar)";
    ////    }
    ////    if (consulta == "reverso")
    ////    {
    ////        if (tipo == enumBancoBbEstatus.ReferenciaVigente_Cobrar) cad = "Pago reversado correctamente";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaPagadaPreviamente_NoCobrar) cad = "Recibo no esta pagado";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaNoEncontrada_NoCobrar) cad = "Referencia no Encontrada";
    ////        if (tipo == enumBancoBbEstatus.ReferenciaPersonalizada_NoCobrar) cad = "Error al reversar el pago (favor de verificar)";
    ////    }
    ////    return cad;
    ////}
    //#endregion
    //#endregion
}
