﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.WhoWeAreDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.GetAsync("https://localhost:44382/api/WhoWeAreDetail");
            if(resposeMessage.IsSuccessStatusCode)
			{
				var jsonData = await resposeMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDTO>>(jsonData);
				ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
				ViewBag.subTitle = value.Select(x => x.Subtitle).FirstOrDefault();
				ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
				ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
				return View();
			}
			return View();
        }
    }
}
