using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository , IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //Get Walks
        //Get: /api/walks?filterOn=Name&filterQuery=Track
        public async Task< IActionResult> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery) { 
        
            var walkDataModel = await _walkRepository.GetAllAsync(filterOn,filterQuery);
           return Ok( _mapper.Map<List<WalkDTO>>(walkDataModel));

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDataModel = await _walkRepository.GetById(id);
            if (walkDataModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(walkDataModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkDTO addWalkDTO)
        {
            var WalkDataModel = _mapper.Map<Walk>(addWalkDTO);
            WalkDataModel = await _walkRepository.CreateAsync(WalkDataModel);
            return Ok(_mapper.Map<WalkDTO>(WalkDataModel));

        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update ([FromRoute] Guid id,[FromBody] UpdateWalkDTO updateWalkDTO)
        {
            var WalkDataModel = await _walkRepository.UpdateAsync(id,_mapper.Map<Walk>(updateWalkDTO));
            if (WalkDataModel == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<WalkDTO>(WalkDataModel));
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var WalkDataModel = await _walkRepository.DeleteAsync(id);
            return Ok(_mapper.Map<WalkDTO>(WalkDataModel));
        }
    }
}
