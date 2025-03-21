﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NuGet.Configuration;
using RealEstate_Dapper_UI.DTOs.CategoryDTOs;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> PartialSearch()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return PartialView(values);
            }
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            TempData["searchKeyValue"] = searchKeyValue;
            TempData["propertyCategoryId"] = propertyCategoryId;
            TempData["city"] = city;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
