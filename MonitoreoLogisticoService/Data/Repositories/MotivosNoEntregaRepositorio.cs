using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;
using MonitoreoLogisticoService.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Repositories
{
    public class MotivosNoEntregaRepositorio 
        : Repositorio<MotivoNoEntrega,MonitoreoContext>, IMotivosNoEntregaRepositorio
    {
    }
}