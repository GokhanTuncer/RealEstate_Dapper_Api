namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
	public interface IStatisticRepository
	{
		int ProductCountByEmployeeID(int id);   //Kullanıcının id'leri
		int ProductCountByStatusTrue(int id);
		int ProductCountByStatusFalse(int id);
		int AllProductCount();
	}
}
