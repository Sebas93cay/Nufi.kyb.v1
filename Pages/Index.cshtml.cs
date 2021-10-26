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
	public class IndexModel: PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public fieldForm[] fields { get; set; }
		public NufiApiService ApiService;
		public ActaConstitutiva actaConstitutiva { get; set; }

		public IndexModel(ILogger<IndexModel> logger, 
				NufiApiService apiService)
		{
			_logger = logger; // things I havent touch
			ApiService = apiService;
		}

		public class fieldForm
		{
			public fieldForm (string label, string id)
			{
				this.label = label;
				this.id = id;
			}
			public string label { get; set; }
			public string id { get; set; }
		}

		public void OnGet()
		{
			fields = new fieldForm[] {
				new fieldForm("Razón Social*", "razonSocialField"),
				new fieldForm("RFC", "RFCField"),
				new fieldForm("Marca", "MarcaField")
			};
			actaConstitutiva = ApiService.GetActaConstitutiva("Nufi", "el rfc", "la marca").Result;
		}
	}
}
