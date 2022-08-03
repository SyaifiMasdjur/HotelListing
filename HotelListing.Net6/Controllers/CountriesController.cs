using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Net6.Data;
using HotelListing.Net6.Models.Country;
using AutoMapper;
using HotelListing.Net6.Contracts;

namespace HotelListing.Net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(IMapper mapper,ICountryRepository countryRepository)
        {
            _mapper = mapper;
            this._countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var c = await _countryRepository.GetAllAsync();
            var countries = _mapper.Map<List<CountryDto>>(c);
            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {

            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CountryDto>(country));
        }

        // GET: api/Country/Detail/5
        [HttpGet("Detail/{id}")]
        public async Task<ActionResult<CountryDetailDto>> GetCountryDetail(int id)
        {
            var country = await _countryRepository.GetDetails(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CountryDetailDto>(country));
        }


        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto country)
        {
            if (id != country.id)
            {
                return BadRequest();
            }

            var c = await _countryRepository.GetAsync(id);
            if (c == null)
            {
                return NotFound();
            }

            _mapper.Map(country, c);

            try
            {
                await _countryRepository.UpdateAsync(c);
                await _countryRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto countrydto)
        {
            var country = _mapper.Map<Country>(countrydto);
            await _countryRepository.AddAsync(country);
            await _countryRepository.SaveAsync();

            return CreatedAtAction("GetCountry", new { id = country.id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countryRepository.DeleteAsync(id);
            await _hotelsRepository.SaveAsync();

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            var b = await _countryRepository.Exists(id);
            return b;
        }
    }
}
