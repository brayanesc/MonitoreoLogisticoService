using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;

namespace MonitoreoLogisticoService.Data.Repositories.Interfaces
{
    interface IRepartidoresRepositorio : IRepositorio<Repartidor>
    {
        Repartidor GetSingle(int RepartidorId);
    }
}
