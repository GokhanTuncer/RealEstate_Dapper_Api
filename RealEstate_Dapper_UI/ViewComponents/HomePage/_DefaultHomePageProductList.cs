using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44382/api/Products/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
