using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.EstateAgentDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
	public class _EstateAgentDashboardChartComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:44382/api/EstateAgentChart");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
