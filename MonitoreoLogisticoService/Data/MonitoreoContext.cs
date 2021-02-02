using MonitoreoLogisticoService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data
{
    public class MonitoreoContext : DbContext
    {
        public MonitoreoContext() : base("RoghurDBPresentacion")
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Repartidor> Repartidores { get; set; }
        public DbSet<EncargadoLogistica> EncargadosLogistica { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        public DbSet<DetalleItinerario> DetallesItinerarios { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Coordenada> Coordenadas { get; set; }
        public DbSet<OrdenEntrega> OrdenesEntrega { get; set; }
        public DbSet<MarcacionEntrega> MarcacionesEntrega { get; set; }
        public DbSet<MotivoNoEntrega> MotivosNoEntrega { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClientePersona> ClientesPersona { get; set; }
        public DbSet<ClienteEmpresa> ClientesEmpresa { get; set; }

    }
}