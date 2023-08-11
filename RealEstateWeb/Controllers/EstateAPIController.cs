using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateWeb.Data;
using RealEstateWeb.Models;
using RealEstateWeb.Models.Dto;

namespace RealEstateWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EstateDto>> GetEstates() {
            return Ok(EstateStore.EstateList);

        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EstateDto> GetEstate(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }
            var Est = EstateStore.EstateList.FirstOrDefault(x => x.ID == id);
            if(Est == null)
            {
                return NotFound();
            }
            return Ok(Est);

        }
    }
}
