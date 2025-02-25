using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WhoWeAreDetailController : ControllerBase
	{
		private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

		public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
		{
			_whoWeAreDetailRepository = whoWeAreDetailRepository;
		}
		[HttpGet]
		public async Task<IActionResult> WhoWeAreDetailList()
		{
			var values = await _whoWeAreDetailRepository.GetAllWhoWeareDetailAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
		{
			_whoWeAreDetailRepository.CreateWhoWeareDetail(createWhoWeAreDetailDTO);
			return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
		{
			_whoWeAreDetailRepository.DeleteWhoWeareDetail(id);
			return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeareDetailDTO updateWhoWeAreDetailDTO)
		{
			_whoWeAreDetailRepository.UpdateWhoWeareDetail(updateWhoWeAreDetailDTO);
			return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Güncellendi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetWhoWeAreDetail(int id)
		{
			var value = await _whoWeAreDetailRepository.GetWhoWeAreDetail(id);
			return Ok(value);
		}
	}
}
