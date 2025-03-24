﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoListsController : ControllerBase
	{
		private readonly ITodoListRepository _ToDoListRepository;
		public ToDoListsController(ITodoListRepository ToDoListRepository)
		{
			_ToDoListRepository = ToDoListRepository;
		}

		[HttpGet]
		public async Task<IActionResult> ToDoListList()
		{
			var values = await _ToDoListRepository.GetAllToDoList();
			return Ok(values);
		}
	}
}
