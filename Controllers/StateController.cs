using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorldAPI.DTO.Country;
using WorldAPI.DTO.State;
using WorldAPI.Model;
using WorldAPI.Repositery.IRepositery;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepositery _stateRepo;
        private readonly IMapper _mapper;

        public StateController(IStateRepositery stateRepo, IMapper mapper)
        {
            _stateRepo = stateRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateStateDTO>> CreateState([FromBody] CreateStateDTO createStateDto)
        {
            var state = _mapper.Map<State>(createStateDto);

            await _stateRepo.Create(state);
            return CreatedAtAction("GetState", new { Id = state.Id }, state);

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetStateDTO>>> GetStates()
        {
            var states = await _stateRepo.GetAll();
            var getStateDTOs = _mapper.Map<List<GetStateDTO>>(states);
            if (states != null)
                return Ok(getStateDTOs);
            else
                return NoContent();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetStateDTO>> GetState(int id)
        {
            var state = await _stateRepo.Get(id);

            var getStateDTO = _mapper.Map<GetStateDTO>(state);
            if (state != null)
                return Ok(getStateDTO);
            else
                return NoContent();
        }

        [HttpPut]

        public async Task<ActionResult<State>> UpdtaeState([FromBody] UpdateStateDTO updateStateDTO)
        {
            var state = _mapper.Map<State>(updateStateDTO);
            var stateObject = await _stateRepo.Get(state.Id);
            if (stateObject != null)
            {
                await _stateRepo.Update(state);
                return stateObject;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteState(int id)
        {
            var state = await _stateRepo.Get(id);
            if (state != null)
            {
                await _stateRepo.Delete(state);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
