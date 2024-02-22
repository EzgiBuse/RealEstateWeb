using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateWeb.Data;
using RealEstateWeb.Models;
using RealEstateWeb.Models.Dto;
using RealEstateWeb.Repository;
using System.Net;

namespace RealEstateWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateNumberAPIController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly ILogger<EstateNumberAPIController> _logger;
        private readonly IEstateNumberRepository _dbEstateNumber;
        private readonly IEstateRepository _dbEstate;
        private readonly IMapper _mapper;
        public EstateNumberAPIController(ApplicationDbContext db, ILogger<EstateNumberAPIController> logger, IMapper mapper,IEstateNumberRepository dbEstateNumber, IEstateRepository dbEstate) { 
            this._logger = logger;
            this._dbEstateNumber = dbEstateNumber;
            this._mapper = mapper;
            this._response = new();
            this._dbEstate = dbEstate;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<ApiResponse>> GetEstateNumbers() {
            try
            {
                _logger.LogInformation("Getting All Estates");
                IEnumerable<EstateNumber> estatenumberList = await _dbEstateNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<EstateNumberDto>>(estatenumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    =new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet("id", Name = "GetEstateNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<ApiResponse>> GetEstateNumber(int id)
        {
            try
            {
                if (id == 0)
            {
                _logger.LogError("Get Estate Error With id=0");
                    _response.StatusCode=HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var EstNumber = await _dbEstateNumber.GetAsync(x => x.EstateNo == id);
            if (EstNumber == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<EstateNumberDto>(EstNumber);
            _response.StatusCode=HttpStatusCode.OK;
            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;

        }
        
        [HttpPost(Name = "CreateEstateNumber")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreateEstateNumber([FromBody] EstateNumberCreateDto createEstateNumberDto)
        {
            
            try
            {
                if(await _dbEstate.GetAsync(u=>u.ID == createEstateNumberDto.EstateID) == null){
                    return BadRequest(ModelState);
                }

                EstateNumber m = _mapper.Map<EstateNumber>(createEstateNumberDto);

            
           await _dbEstateNumber.CreateAsync(m);
            _response.Result = _mapper.Map<EstateNumberDto>(m);
            _response.StatusCode = HttpStatusCode.Created;
            //return Ok(_response);


            return CreatedAtRoute("GetEstateNumber", new { ID = m.EstateNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpDelete("id", Name = "DeleteEstateNumber")]
        public async Task<ActionResult<ApiResponse>> DeleteEstateNumber(int id)
        {
            try
            {
                if (id == null)
            {
                return BadRequest(id);
            }
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var estateNumber = await _dbEstateNumber.GetAsync(x => x.EstateNo == id);
            await _dbEstateNumber.RemoveAsync(estateNumber);

            
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpPut("id", Name = "UpdateEstateNumber")]
        public async Task<ActionResult<ApiResponse>> UpdateEstateNumber(int id, [FromBody] EstateNumberUpdateDto updateEstateNumberDto)
        {
            try
            {
                if (updateEstateNumberDto == null || id!= updateEstateNumberDto.EstateNo)
            {
                return BadRequest();
            }
                EstateNumber m = _mapper.Map<EstateNumber>(updateEstateNumberDto);
           await _dbEstateNumber.UpdateAsync(m);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;

            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        
        
    }
}
