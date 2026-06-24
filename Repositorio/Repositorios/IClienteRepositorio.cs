using Shared.DTOs;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<List<VerClienteDTO>> ObtenerListaClientes();
        Task<List<VerClienteDTO>> ObtenerClientesDeudores();
    }
}