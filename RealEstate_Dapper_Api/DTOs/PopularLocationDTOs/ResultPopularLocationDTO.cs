﻿namespace RealEstate_Dapper_Api.DTOs.PopularLocationDTOs
{
    public class ResultPopularLocationDTO
    {
        public int LocationID { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public string PropertyCount { get; set; }
    }
}
