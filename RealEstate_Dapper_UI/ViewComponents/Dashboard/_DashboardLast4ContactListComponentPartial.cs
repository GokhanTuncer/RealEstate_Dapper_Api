using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ContactDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardLast4ContactListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardLast4ContactListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44382/api/Contacts/GetLast4Contact");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<Last4ContactResultDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
