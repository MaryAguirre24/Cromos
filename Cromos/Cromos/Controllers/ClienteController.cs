using BD.Data;
using BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace Cromos.Controllers
{
    [ApiController]
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClienteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VerClienteDTO>>> ObtenerCliente()
        {
            var clientes = await context.Clientes.ToListAsync();
            if (clientes == null)
            {
                return BadRequest("Error al obtener los clientes");
            }
            if (clientes.Count == 0)
            {
                return NotFound("No se encontraron clientes");
            }
            return Ok(clientes);
        }
        [HttpGet("listaClientes")]
        public async Task<ActionResult<List<VerClienteDTO>>> ListaClientes()
        {
            var listaclientes = await context.Clientes.ToListAsync();
            if (listaclientes == null)
            {
                return BadRequest("Error al obtener los clientes");
            }
            if (listaclientes.Count == 0)
            {
                return NotFound("No se encontraron clientes");
            }
            return Ok(listaclientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerClienteDTO>> ObtenerClientePorId(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }
            return Ok(cliente);
        }
    }
}
