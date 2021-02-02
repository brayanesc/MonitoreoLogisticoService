using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;
using MonitoreoLogisticoService.Data.Repositories.Interfaces;
using System.Linq;

namespace MonitoreoLogisticoService.Data.Repositories
{
    public class RepartidoresRepositorio 
        : Repositorio<Repartidor, MonitoreoContext>, IRepartidoresRepositorio
    {
        public Repartidor GetSingle(int RepartidorId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == RepartidorId);
            return query;
        }
    }
}