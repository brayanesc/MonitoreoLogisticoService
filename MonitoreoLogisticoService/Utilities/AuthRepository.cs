using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MonitoreoLogisticoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoService.Utilities
{
    public class AuthRepository : IDisposable
    {
        private AuthContext authContext;
        private UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            authContext = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(authContext));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel) {

            IdentityUser user = new IdentityUser {
                UserName = userModel.NombreUsuario
            };

            var result = await userManager.CreateAsync(user, userModel.Contrasena);
            return result;

        }

        public async Task<IdentityUser> FindUser(string userName, string password) {
            return await userManager.FindAsync(userName, password);

        }

        public void Dispose()
        {
            authContext.Dispose();
            userManager.Dispose();
        }
    }
}