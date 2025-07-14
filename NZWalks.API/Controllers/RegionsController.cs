using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;
using System;
using System.Collections.Generic;

namespace NZWalks.API.Controllers
{

    // https://localhost:1234/api/regions

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepositoy regionRepositoy;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepositoy regionRepositoy,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepositoy = regionRepositoy;
            this.mapper = mapper;
        }
        [HttpGet] 

        //public IActionResult GetAll()
        public async Task<IActionResult>  GetAll()
        {

      // Get Data From Database - Domain modles
            var regions = await regionRepositoy.GetAllAsync();
           
            // Map Domain Models to DTOs
           var regionsDto =  mapper.Map<List<RegionDto>>(regions); 

            return Ok(regionsDto);
             
        }



        // https://localhost:1234/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")] 

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            
            // GET Region Domain Model From Database
            //var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomainModle = await regionRepositoy.GetByIdAsync(id);
            if (regionDomainModle == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTOs

            var regionsDto = mapper.Map<RegionDto>(regionDomainModle);
            // return DTOs back to the client
            return Ok(regionsDto);
        }


        //POST To Create New Region
        //POST: https://localhost:1234/api/regions

        [HttpPost]
        [ValidateModel] 

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionReques)
        {

            //validate the Model
           
            // Map or Convert DTOs to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionReques);

            // Use Domain Model to create Region

            regionDomainModel = await regionRepositoy.CreateAsync(regionDomainModel);

            // Map Domain model back to DTOs
            var regionsDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id }, regionsDto);
          
           
        }

        //UPDATE To update Region
        //PUT: https://localhost:1234/api/regions/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionsRequestDto updateRegionsRequestDto) {

            // MAP DTO to Domain Model

            var regionDomainModle = mapper.Map<Region>(updateRegionsRequestDto);


            regionDomainModle =  await regionRepositoy.UpdateAsync(id, regionDomainModle);
 
            if(regionDomainModle == null)
            {
                return NotFound();
            }


            // Map/Convert Region Domain Model to Region DTOs
            var regionDto = mapper.Map<RegionDto>(regionDomainModle);
             
            // return DTOs back to the client
            return Ok(regionDto);
        }


        //DELETE To delete region  https://localhost:1234/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")] 

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        { 
            var regionDomainModle = await regionRepositoy.DeleteAsync(id);

            if (regionDomainModle == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTOs

            var regionDto = mapper.Map<RegionDto>(regionDomainModle);
            // return DTOs back to the client
            return Ok(regionDto);
        }

    }
}
