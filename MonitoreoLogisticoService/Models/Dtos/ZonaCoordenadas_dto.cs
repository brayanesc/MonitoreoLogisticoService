using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Models.Dtos
{
    public class ZonaCoordenadas_dto
    {
        public List<Coordenada_dto> coordenadas { get; set; }
        public int zonaid { get; set; }
    }
}