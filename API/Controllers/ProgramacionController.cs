
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProgramacionController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get()
            {
                var Programaciones = await _unitOfWork.Programaciones.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<ProgramacionDto>>(Programaciones);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<ProgramacionDto>> Post(ProgramacionDto ProgramacionDto)
            {
                var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
                this._unitOfWork.Programaciones.Add(Programacion);
                await _unitOfWork.SaveAsync();
                if (Programacion == null)
                {
                    return BadRequest();
                }
                ProgramacionDto.Id = Programacion.Id;
                return CreatedAtAction(nameof(Post), new { id = ProgramacionDto.Id }, ProgramacionDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<ProgramacionDto>> Get(int id)
            {
                var Programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);
                if (Programacion == null){
                    return NotFound();
                }
                return _mapper.Map<ProgramacionDto>(Programacion);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody] ProgramacionDto ProgramacionDto)
            {
                if (ProgramacionDto == null)
                {
                    return NotFound();
                }
                var Programaciones = _mapper.Map<Programacion>(ProgramacionDto);
                _unitOfWork.Programaciones.Update(Programaciones);
                await _unitOfWork.SaveAsync();
                return ProgramacionDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var Programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);
                if (Programacion == null)
                {
                    return NotFound();
                }
                _unitOfWork.Programaciones.Remove(Programacion);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}
