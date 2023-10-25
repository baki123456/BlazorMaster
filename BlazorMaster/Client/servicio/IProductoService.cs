using BlazorMaster.Shared;

namespace BlazorMaster.Client.servicio
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista();

    }
}
