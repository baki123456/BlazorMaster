using BlazorMaster.Shared;

namespace BlazorMaster.Client.servicio
{
    public interface IVentaService
    {
        Task<bool> Guardar(VentaDTO ventaDTO);

    }
}
