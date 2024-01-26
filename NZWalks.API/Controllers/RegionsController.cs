using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        private readonly NZWalksDbContext dBContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext DBContext, IRegionRepository regionRepository,IMapper mapper)
        {
            dBContext = DBContext;
            _regionRepository = regionRepository;
           _mapper = mapper;
        }
       
        //Get All Regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
         var result = await _regionRepository.GetAllAsync();
            
            List<RegionDTO> regions = new List<RegionDTO>();
            
            return Ok(_mapper.Map<List<RegionDTO>>(result));
        }

        //Get Regions By Id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _regionRepository.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            
           
         return Ok(_mapper.Map<RegionDTO>(result));
        }
      
        //Create region
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO regionDto)
        {
            Region region = _mapper.Map<Region>(regionDto);

            region = await _regionRepository.CreateAsync(region);

            

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, _mapper.Map<RegionDTO>(region));
        }

        //Update Region
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDto)
        {
           Region RegionDataModel = await _regionRepository.UpdateAsync(id, _mapper.Map<Region>(updateRegionDto));

            if (RegionDataModel == null)
            {
                return NotFound();
            }

           return Ok(_mapper.Map<RegionDTO>(RegionDataModel));

        }

        //Delete Region
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task< IActionResult> Delete([FromRoute] Guid id)
        {
            var RegionDomainModel = await _regionRepository.DeleteAsync(id);
            if (RegionDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDTO>(RegionDomainModel));
        }
    }
}
