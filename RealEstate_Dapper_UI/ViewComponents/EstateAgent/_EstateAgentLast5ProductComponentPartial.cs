using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.EstateAgentDTOs;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory , ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44382/api/EstateAgentLastProducts?id="+ id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
    }
