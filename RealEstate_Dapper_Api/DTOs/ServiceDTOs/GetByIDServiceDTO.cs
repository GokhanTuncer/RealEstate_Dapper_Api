﻿namespace RealEstate_Dapper_Api.DTOs.ServiceDTOs
{
    public class GetByIDServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
