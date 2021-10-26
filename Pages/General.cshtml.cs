using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Nufi.kyb.v1.Services;
using Nufi.kyb.v1.Models;

namespace Nufi.kyb.v1.Pages
{
    public class GeneralModel : PageModel
    {
		private readonly ILogger<GeneralModel> _logger;    	
    	public ActaConstitutiva actaConstitutiva { get; set; }
		public NufiApiService ApiService;    	
		public Seccion[] secciones { get; set; }
		public Dato[] datosGenerales { get; set; }
		public Dato[] datosDomiciliarios { get; set; }

		public GeneralModel(ILogger<GeneralModel> logger, 
				NufiApiService apiService)
		{
			_logger = logger; // things I havent touch
			ApiService = apiService;
		}

		public class Seccion
		{
			public Seccion (string titulo, Dato[] datos)
			{
				this.titulo = titulo;
				this.datos = datos;
			}
			public string titulo {get; set;}
			public Dato[] datos {get; set;}
		}
		public class Dato
		{
			public Dato (string label, string texto)
			{
				this.label = label;
				this.texto = texto;
			}
			public string label { get; set; }
			public string texto { get; set; }

		}
		public string createName(string a, string b)
		{
			return a + b;
		}

        public async Task OnGet()
        {
			actaConstitutiva = ApiService.GetActaConstitutiva("Nufi", "el rfc", "la marca").Result;

			var datosGenerales = new Dato[]
			{
				new Dato("Razón Social", actaConstitutiva.razon_social),
				new Dato("Marca", actaConstitutiva.marca),
				new Dato("Nacionalidad", actaConstitutiva.nacionalidad),
				new Dato("Registro Federal de Contribuyentes (RFC)", actaConstitutiva.rfc),
				new Dato("Fecha de Constitución", actaConstitutiva.fecha_constitucion),
				new Dato("Número de Escritura Constitutiva", actaConstitutiva.numero_escritura.ToString()),
				new Dato("Folio Mercantil", actaConstitutiva.folio_mercantil.ToString()),
				new Dato("Fecha de inscripción de PRP", actaConstitutiva.fecha_inscripcion_prp),
				new Dato("Sector", actaConstitutiva.sector),
				new Dato("Giro Mercantíl", actaConstitutiva.giro_mercantil),
				new Dato("Objeto Social", actaConstitutiva.objeto_social)
			};
			var datosDomiciliarios = new Dato[]
			{
				new Dato("Calle", actaConstitutiva.domicilio_fiscal.calle),
				new Dato("Número Exterior", actaConstitutiva.domicilio_fiscal.num_ext.ToString()),
				new Dato("Número Interior", actaConstitutiva.domicilio_fiscal.num_int.ToString()),
				new Dato("Entre Calles", actaConstitutiva.domicilio_fiscal.entre_calles),
				new Dato("Colonia", actaConstitutiva.domicilio_fiscal.colonia),
				new Dato("Código Postal", actaConstitutiva.domicilio_fiscal.codigo_postal.ToString()),
				new Dato("Entidad Federativa / Demarcación", actaConstitutiva.domicilio_fiscal.entidad_federativa),
				new Dato("País", actaConstitutiva.domicilio_fiscal.pais),
				new Dato("Delegación / Municipio", actaConstitutiva.domicilio_fiscal.municipio),
			};

			secciones = new Seccion[]
			{
				new Seccion("Información General", datosGenerales),
				new Seccion("Información Domiciliaria", datosDomiciliarios)
			};
        }
    }
}
