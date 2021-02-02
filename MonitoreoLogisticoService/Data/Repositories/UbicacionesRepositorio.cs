using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;
using MonitoreoLogisticoService.Data.Repositories.Interfaces;

namespace MonitoreoLogisticoService.Data.Repositories
{
    public class UbicacionesRepositorio 
        : Repositorio<Ubicacion,MonitoreoContext>, IUbicacionesRepositorio
    {
    }
}