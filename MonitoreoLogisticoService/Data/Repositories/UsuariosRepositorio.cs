﻿using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Data.Repositories.Base;
using MonitoreoLogisticoService.Data.Repositories.Interfaces;

namespace MonitoreoLogisticoService.Data.Repositories
{
    public class UsuariosRepositorio 
        : Repositorio<Usuario,MonitoreoContext>, IUsuariosRepositorio
    {
    }
}