﻿using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public interface IWhoWeAreRepositorycs
	{
		Task<List<ResultWhoWeareDetailDTO>> GetAllWhoWeareDetailAsync();
		void CreateWhoWeareDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
		void DeleteWhoWeareDetail(int id);
		void UpdateWhoWeareDetail(UpdateWhoWeareDetailDTO updateWhoWeareDetailDTO);
		Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
	}
}
