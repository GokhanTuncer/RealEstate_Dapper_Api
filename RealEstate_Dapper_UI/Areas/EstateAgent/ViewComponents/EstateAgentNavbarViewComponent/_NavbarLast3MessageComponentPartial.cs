using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.MessageDTOs;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponent
{
    public class _NavbarLast3MessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _NavbarLast3MessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44382/api/Messages?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
