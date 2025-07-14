using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{

    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper , IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //CREATE Walk
        // POST : /api/walks
        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel); 
            // Map Domain to DTOs
          var walkDomainDto = mapper.Map<WalkDto>(walkDomainModel);
         return Ok(walkDomainDto);


        }

        //GET Walks
        // /api/walks – returns all
        ///api/walks? name = Track – filter by name
        ///api/walks?lengthInKm = 5.2 – filter by length
        ///api/walks?name=Track&lengthInKm=5.2 – filter by both

        ///api/walks?description = coast – filters by description

        ///api/walks?name = track & description = coast – filters by both name and description

        ///api/walks?lengthInKm=5.2&description=forest – filters by length and description
        //https://localhost:7211/api/Walks?name=Lake&lengthInKm=4&description=walk
        //https://localhost:7211/api/Walks?name=Chalie&lengthInKm=4&description=walk%20&sortBy=name&isDescending=false
        //https://localhost:7211/api/Walks?name=Chalie&lengthInKm=4&description=walk%20&sortBy=length&isDescending=false


        [HttpGet] 

        //public async Task<IActionResult> GetAll()
        public async Task<IActionResult> GetAll(
            [FromQuery] string? name, 
            [FromQuery] double? lengthInKm, 
            [FromQuery] string? description,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isDescending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10

            )
        {
            var walkDomainModel = await walkRepository.GetAllAsyinc(name, 
                lengthInKm,
                description, 
                sortBy,
                isDescending??false,
                pageNumber,
                pageSize
                );

            //Map Domain Modele to DTOs

            //it may have mulitple walks but if it is single use like this
            //return Ok(mapper.Map<WalkDto>(walkDomainModel));

            //return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));


            var response = new PaginatedResponseDto<WalkDto>
            {
                PageNumber = walkDomainModel.PageNumber,
                PageSize = walkDomainModel.PageSize,
                TotalCount = walkDomainModel.TotalCount,
                Data = mapper.Map<List<WalkDto>>(walkDomainModel.Data),

            };
            return Ok(response);


        }
        // https://localhost:1234/api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")] 
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            // GET Walks Domain Model From Database 
            var walkDomainModle = await walkRepository.GetByIdAsync(id);
            if (walkDomainModle == null)
            {
                return NotFound();
            }

            // Map/Convert Walks Domain Model to Walks DTOs

            var walkDomainDto = mapper.Map<WalkDto>(walkDomainModle);
            // return DTOs back to the client
            return Ok(walkDomainDto);
        }


        //UPDATE To update Walks
        //PUT: https://localhost:1234/api/walks/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {

            // MAP DTO to Domain Model

            var walkDomainModle = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModle = await walkRepository.UpdateAsync(id, walkDomainModle);

            if (walkDomainModle == null)
            {
                return NotFound();
            } 
            // Map/Convert Region Domain Model to Region DTOs
            var regionDto = mapper.Map<WalkDto>(walkDomainModle);

            // return DTOs back to the client
            return Ok(regionDto);
        }
        //DELETE To  Walks
        //DELETE: https://localhost:1234/api/walks/{id}

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModle = await walkRepository.DeleteAsync(id);

            if (walkDomainModle == null)
            {
                return NotFound();
            }

            // Map/Convert Walk Domain Model to Walk DTOs

            var walkDto = mapper.Map<WalkDto>(walkDomainModle);
            // return DTOs back to the client
            return Ok(walkDto);
        }

    }
}
