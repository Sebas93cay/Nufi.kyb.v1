using Microsoft.AspNetCore.Components;

namespace Nufi.kyb.v1.Components
{
	public class MenuOptionBase : ComponentBase
	{
		[Parameter]
		public string text { get; set; }

		[Parameter]
		public string icon { get; set; }
	}
}
