﻿namespace RealEstate_Dapper_Api.DTOs.EmployeeDTOs
{
    public class ResultEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public bool Status { get; set; }
    }
}
