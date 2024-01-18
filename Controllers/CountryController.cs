using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WorldAPI.Data;
using WorldAPI.DTO.Country;
using WorldAPI.Model;
using WorldAPI.Repositery;
using WorldAPI.Repositery.IRepositery;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepositery _countryRepo;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepositery countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CountryDTO>> CreateCountry( [FromBody] CountryDTO countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);

            await _countryRepo.Create(country);
            return CreatedAtAction("GetCountry", new { Id = country.Id }, country);

        }

        [HttpGet]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
            var countries = await _countryRepo.GetAll();
            var getCountryDTOs = _mapper.Map<List<GetCountryDTO>>(countries);
            if (countries != null)
                return Ok (getCountryDTOs);
            else
                return NoContent();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetCountryDTO>> GetCountry( int id) {
            var country = await _countryRepo.Get(id);

            var getCountryDTO = _mapper.Map<GetCountryDTO>(country);
            if(country != null)
                return Ok(getCountryDTO);
            else
                return NoContent();
        }

        [HttpPut]

        public async Task< ActionResult<Country>> UpdateCountry ([FromBody] UpdateCountryDTO updateCountryDTO)
        {
            var country = _mapper.Map<Country>(updateCountryDTO);
            var countryObject= await _countryRepo.Get(country.Id);
            if (countryObject != null)
            {
               await _countryRepo.Update(country);
                return countryObject;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteCountry (int id)
        {
            var country = await _countryRepo.Get(id);
            if( country != null) {
                _countryRepo.Delete(country);
                return Ok();
            } else
            {
                return NotFound();
            }
            
        }
    }
}
