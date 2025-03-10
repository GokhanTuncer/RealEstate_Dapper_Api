using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
	public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;
		public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginservice)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginservice;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var id = _loginService.GetUserId;
			#region Statistics1 - ToplamIlanSayısı
			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/AllProductCount");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			ViewBag.productCount = jsonData1;
			#endregion

			#region Statistics2 - KullanıcınınToplamIlanSayısı
			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/ProductCountByEmployeeID?id=" + id);
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.employeebyProductCount = jsonData2;
			#endregion

			#region Statistics3 - AktifIlanSayısı
			var client3 = _httpClientFactory.CreateClient();
			var responseMessage3 = await client3.GetAsync("https://localhost:44382/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + id);
			var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
			ViewBag.productcountbyemployeestatusTrue = jsonData3;
			#endregion

			#region Statistics4 - Ortalama Kira
			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:44382/api/stateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + id);
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
			ViewBag.productcountbyemployeestatusFalse = jsonData4;
			#endregion

			return View();
		}
	}
}
