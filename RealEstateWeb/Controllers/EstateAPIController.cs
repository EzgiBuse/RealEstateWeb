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
    public class EstateAPIController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly ILogger<EstateAPIController> _logger;
        private readonly IEstateRepository _dbEstate;
        private readonly IMapper _mapper;
        public EstateAPIController(ApplicationDbContext db, ILogger<EstateAPIController> logger, IMapper mapper,IEstateRepository dbEstate) { 
            this._logger = logger;
            this._dbEstate = dbEstate;
            this._mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetEstates() {
            try
            {
                _logger.LogInformation("Getting All Estates");
                IEnumerable<Estate> estateList = await _dbEstate.GetAllAsync();
                _response.Result = _mapper.Map<List<EstateDto>>(estateList);
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

        [HttpGet("{id}", Name = "GetEstate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> GetEstate(int id)
        {
            try
            {
                if (id == 0)
            {
                _logger.LogError("Get Estate Error With id=0");
                    _response.StatusCode=HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var Est = await _dbEstate.GetAsync(x => x.ID == id);
            if (Est == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<EstateDto>(Est);
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
        
        [HttpPost(Name = "CreateEstate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreateEstate([FromBody] EstateCreateDto createEstateDto)
        {
            
            try
            {
                Estate m = _mapper.Map<Estate>(createEstateDto);

            
           await _dbEstate.CreateAsync(m);
            _response.Result = _mapper.Map<EstateDto>(m);
            _response.StatusCode = HttpStatusCode.Created;
            //return Ok(_response);


            return CreatedAtRoute("GetEstate", new { ID = m.ID }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        //[HttpDelete("{id}", Name = "DeleteEstate")]
        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> DeleteEstate(int id)
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
            var estate = await _dbEstate.GetAsync(x => x.ID == id);
            await _dbEstate.RemoveAsync(estate);

            
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

        [HttpPut("{id}", Name = "UpdateEstate")]
        public async Task<ActionResult<ApiResponse>> UpdateEstate(int id, [FromBody] EstateUpdateDto updateEstateDto)
        {
            try
            {
                if (updateEstateDto == null || id!= updateEstateDto.ID)
            {
                return BadRequest();
            }
            Estate m = _mapper.Map<Estate>(updateEstateDto);
           await _dbEstate.UpdateAsync(m);
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

        [HttpPatch("{id}", Name = "UpdatePartialEstate")]
        public async Task<ActionResult> UpdatePartialEstate(int id, JsonPatchDocument<EstateUpdateDto> estateUpdateDto)
        {
            if (estateUpdateDto == null || id != 0)
            {
                return BadRequest();
            }
            var est = await _dbEstate.GetAsync(y => y.ID == id,tracked:false);
            
            EstateUpdateDto estatedto = _mapper.Map<EstateUpdateDto>(est);
            if (est == null)
            {
                return BadRequest();
            }
            estateUpdateDto.ApplyTo(estatedto, ModelState);
            Estate m = _mapper.Map<Estate>(estatedto);

            await _dbEstate.UpdateAsync(m);
           
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
