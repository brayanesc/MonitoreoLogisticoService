using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;

namespace MonitoreoLogisticoService.Data.Repositories.Interfaces
{
    interface ICoordenadasRepositorio : IRepositorio<Coordenada>
    {
        Coordenada GetSingle(int CoordenadaId);
    }
}
