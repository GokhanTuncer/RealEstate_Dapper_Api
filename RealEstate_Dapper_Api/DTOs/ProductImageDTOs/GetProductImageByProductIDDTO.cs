namespace RealEstate_Dapper_Api.DTOs.ProductImageDTOs
{
    public class GetProductImageByProductIDDTO
    {
        public int ProductImageID { get; set; }
        public string ImageURL{ get; set; }
        public int ProductID { get; set; }
    }
}
