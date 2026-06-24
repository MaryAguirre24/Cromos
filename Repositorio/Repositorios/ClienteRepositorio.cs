using Microsoft.EntityFrameworkCore;
using BD.Data; 
using BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.DTOs;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly ApplicationDbContext context;

        public ClienteRepositorio(ApplicationDbContext context): base(context) 
        {
            this.context = context;
        }

        public async Task<List<VerClienteDTO>> ObtenerListaClientes()
        {
            return await context.Clientes
                .Include(c => c.Persona)
                .Include(c => c.MovimientosCuentaCorriente)
                .Select(c => new VerClienteDTO
                {
                    Id = c.Id,
                    NombreCompleto = c.Persona.Nombre + " " + c.Persona.Apellido,
                    Telefono = c.Persona.Telefono,
                    FechaRegistro = c.FechaRegistro,
                    Deuda = c.MovimientosCuentaCorriente.Sum(m => m.Monto),
                    Estado = c.Estado
                })
                .ToListAsync();
        }

        public async Task<List<VerClienteDTO>> ObtenerClientesDeudores()
        {
            return await context.Clientes
                .Include(c => c.Persona)
                .Include(c => c.MovimientosCuentaCorriente)
                .Where(c => c.MovimientosCuentaCorriente.Sum(m => m.Monto) > 0)
                .Select(c => new VerClienteDTO
                {
                    Id = c.Id,
                    NombreCompleto = c.Persona.Nombre + " " + c.Persona.Apellido,
                    Telefono = c.Persona.Telefono,
                    FechaRegistro = c.FechaRegistro,
                    Deuda = c.MovimientosCuentaCorriente.Sum(m => m.Monto),
                    Estado = c.Estado
                })
                .ToListAsync();
        }
    }
}
