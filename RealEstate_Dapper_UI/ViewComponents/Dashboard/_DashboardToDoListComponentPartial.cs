using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardToDoListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44382/api/ToDoLists");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultToDoListDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
