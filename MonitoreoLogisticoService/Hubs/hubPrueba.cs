using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Hubs
{
    public class hubPrueba : Hub
    {
        public void Send(string message) {
            Clients.All.send("Me dijiste: "+ message);
        }
    }
}