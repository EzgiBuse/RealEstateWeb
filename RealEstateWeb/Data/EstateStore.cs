using RealEstateWeb.Models.Dto;
using System.Net.NetworkInformation;

namespace RealEstateWeb.Data
{
    public static class EstateStore
    {
        public static List<EstateDto> EstateList = new List<EstateDto> {
        new EstateDto { ID=1,Name="Bahcesehir Villa"},
                new EstateDto { ID=2,Name="nisantasi dublex"}
        };
    }
}
