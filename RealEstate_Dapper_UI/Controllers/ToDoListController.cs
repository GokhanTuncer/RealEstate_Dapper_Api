using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_UI.Controllers
{
	public class ToDoListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ToDoListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44382/api/Categories");
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
