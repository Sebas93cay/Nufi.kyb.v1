using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nufi.kyb.v1.Pages
{
    public class GeneralModel : PageModel
    {
		public Seccion[] secciones;
		public Dato[] datosGenerales { get; set; }
		public Dato[] datosDomiciliarios { get; set; }

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
        public void OnGet()
        {
			datosGenerales = new Dato[] {
				new Dato("Razón Social", "Texto Aquí"),
				new Dato("Marca", "Texto Aquí"),
				new Dato("Nacionalidad", "Texto Aquí"),
				new Dato("Registro Federal de Contribuyentes (RFC)", "Texto Aquí"),
				new Dato("Fecha de Constitución", "Texto Aquí"),
				new Dato("Número de Escritura Constitutiva", "Texto Aquí"),
				new Dato("Folio Mercantíl", "Texto Aquí"),
				new Dato("Fecha de inscripción de PRP", "Texto Aquí"),
				new Dato("Sector", "Texto Aquí"),
				new Dato("Giro Mercantíl", "Texto Aquí"),
				new Dato("Objeto Social", "Texto Aquí")
			};
			datosDomiciliarios = new Dato[] {
				new Dato("Calle", "Texto Aquí"),
				new Dato("Número Exterior", "Texto Aquí"),
				new Dato("Número Interior", "Texto Aquí"),
				new Dato("Entre Calles", "Texto Aquí"),
				new Dato("Colonia", "Texto Aquí"),
				new Dato("Código Postal", "Texto Aquí"),
				new Dato("Entidad Federativa / Demarcación", "Texto Aquí"),
				new Dato("País", "Texto Aquí"),
				new Dato("Delegación / Municipio", "Texto Aquí"),
			};
			secciones = new Seccion[]
			{
				new Seccion("Información General", datosGenerales),
				new Seccion("Información Domiciliaria", datosDomiciliarios)
			};
        }
    }
}
