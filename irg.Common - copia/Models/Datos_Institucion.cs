using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Datos_Institucion
    {
        public string Clave_Instituto { get; set; }
	    public string Razon_Social { get; set; }
	    public string Nombre_Colegio { get; set; }
	    public string Plantel { get; set; }
	    public string Calle { get; set; }
	    public string Colonia { get; set; }
	    public string Telefonos { get; set; }
	    public string Ciudad { get; set; }
	    public string Estado { get; set; }
	    public string RFC { get; set; }
	    public string Clave_Sistema { get; set; }
	    public string Cupo_Grupos { get; set; }
	    public string Ano_Base { get; set; }
	    public string Mes_Inicio { get; set; }
	    public byte[] Logotipo { get; set; }
    }
}
