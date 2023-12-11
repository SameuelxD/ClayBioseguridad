using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
    using global::API.Dtos;
    using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstadoController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
            {
                var Estados = await _unitOfWork.Estados.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<EstadoDto>>(Estados);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<EstadoDto>> Post(EstadoDto EstadoDto)
            {
                var Estado = _mapper.Map<Estado>(EstadoDto);
                this._unitOfWork.Estados.Add(Estado);
                await _unitOfWork.SaveAsync();
                if (Estado == null)
                {
                    return BadRequest();
                }
                EstadoDto.Id = Estado.Id;
                return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, EstadoDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<EstadoDto>> Get(int id)
            {
                var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
                if (Estado == null){
                    return NotFound();
                }
                return _mapper.Map<EstadoDto>(Estado);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto EstadoDto)
            {
                if (EstadoDto == null)
                {
                    return NotFound();
                }
                var Estados = _mapper.Map<Estado>(EstadoDto);
                _unitOfWork.Estados.Update(Estados);
                await _unitOfWork.SaveAsync();
                return EstadoDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
                if (Estado == null)
                {
                    return NotFound();
                }
                _unitOfWork.Estados.Remove(Estado);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}
}