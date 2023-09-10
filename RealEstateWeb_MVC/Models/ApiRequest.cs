using Microsoft.AspNetCore.Mvc;
using static Estate_Utility.SD;

namespace RealEstateWeb_MVC.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string? Url { get; set; }
        public object? Data { get; set; }
    }
}
