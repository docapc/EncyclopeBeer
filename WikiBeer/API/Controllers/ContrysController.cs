﻿using AutoMapper;
using Ipme.WikiBeer.Dtos;
using Ipme.WikiBeer.Entities;
using Ipme.WikiBeer.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ipme.WikiBeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoutriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<CountryEntity> _ddbRepository;

        public CoutriesController(IGenericRepository<CountryEntity> ddbRepository, IMapper mapper)
        {
            _ddbRepository = ddbRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryDto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                var allCountries = _mapper.Map<IEnumerable<CountryDto>>(_ddbRepository.GetAll());
                return Ok(allCountries);
            }
            catch (Exception e)
            {
                // toutes les exceptions non géré passe en 500
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var country = _ddbRepository.GetById(id);
                if (country == null)
                    return NotFound();
                return Ok(_mapper.Map<CountryDto>(country));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// CreatedAtAction doit retourner ici l'équivalent d'une méthode Get (cad un Dto!)!
        /// </summary>
        /// <param name="breweryDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] CountryDto countryDto)
        {
            try
            {
                var countryEntity = _mapper.Map<CountryEntity>(countryDto);
                var countryEntityCreated = _ddbRepository.Create(countryEntity);
                var correspondingCountryDto = _mapper.Map<CountryDto>(countryEntityCreated);
                return CreatedAtAction(nameof(Get), new { id = correspondingCountryDto.Id }, correspondingCountryDto);
            }
            catch (Exception e)
            {
                // On peut gérer les problèmes de mapping ici
                return StatusCode(500);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid id, [FromBody] CountryDto CountryDto)
        {
            try
            {
                var countryEntity = _mapper.Map<CountryEntity>(CountryDto);
                var updatedCountryEntity = _ddbRepository.UpdateById(id, countryEntity);
                if (updatedCountryEntity == null)
                    return NotFound();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id) // on pourrait retourner un boléen ici
        {
            try
            {
                var response = _ddbRepository.DeleteById(id);
                if (response == null)  // id non trouvé en base
                    return NotFound();
                // bool == true car ce bool en particulier peut etre null! (on ne peut pas faire if(bool?) directement!)
                if (response == true) // si vrai le delete à fonctionné
                    return Ok();
                // Ni null, ni vrai, alors faux, id correct mais pas de suppression en base
                return StatusCode(500);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
