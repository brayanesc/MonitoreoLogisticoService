using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;
using MonitoreoLogisticoService.Data.Repositories.Interfaces;
using System.Linq;

namespace MonitoreoLogisticoService.Data.Repositories
{
    public class CoordenadasRepositorio : Repositorio<Coordenada, MonitoreoContext>, ICoordenadasRepositorio
    {
        public Coordenada GetSingle(int CoordenadaId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == CoordenadaId);
            return query;
        }
    }
}