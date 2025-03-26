using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ProductDetailDTOs;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44382/api/Products/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            ViewBag.searchKeyValue = TempData["searchKeyValue"];
            ViewBag.propertyCategoryId = TempData["propertyCategoryId"];
            ViewBag.city = TempData["city"];

            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44382/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Products/GetProductByProductID?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDTO>(jsonData);

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44382/api/ProductDetails/GetProductDetailByProductID?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIDDTO>(jsonData2);

            ViewBag.title1= values.title.ToString();
            ViewBag.price = values.price;
            ViewBag.city = values.city;
            ViewBag.district = values.district;
            ViewBag.address = values.address;
            ViewBag.type = values.type;
            ViewBag.description = values.description;
            ViewBag.slugUrl = values.SlugUrl;

            ViewBag.bathCount = values2.bathCount;
            ViewBag.bedCount = values2.bedRoomCount;
            ViewBag.size = values2.productSize;
            ViewBag.roomCount = values2.roomCount;
            ViewBag.garageCount = values2.garageSize;
            ViewBag.buildYear = values2.buildYear;
            ViewBag.date = values2.AdvertisementDate;
            ViewBag.location = values2.location;
            ViewBag.videoUrl = values2.videoUrl;

            DateTime date1 = DateTime.Now;
            DateTime date2 = values.AdvertisementDate;

            TimeSpan timeSpan = date1 - date2;
            int month = timeSpan.Days;

            ViewBag.datediff = month / 30;

            string slugFromTitle = CreateSlug(values.title);
            ViewBag.slugUrl = slugFromTitle;

            return View();
        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }
    }
}

