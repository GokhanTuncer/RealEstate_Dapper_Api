﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.BottomGridDTOs;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BottomGridController : ControllerBase
	{
		private readonly IBottomGridRepository _bottomGridRepository;

		public BottomGridController(IBottomGridRepository bottomGridRepository)
		{
			_bottomGridRepository = bottomGridRepository;
		}

		[HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDTO createBottomGridDto)
        {
            await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Alt metin Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Alt metin Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDto)
        {
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("Alt metin Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
        }
    }
}
