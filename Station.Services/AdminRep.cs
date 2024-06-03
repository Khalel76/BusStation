using Station.Domain.Entities;
using Station.Persistance;
using Station.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Services
{
    public class AdminRep : IAdminRep
    {
        private readonly StationContext context;

        public AdminRep(StationContext context)
        {
            this.context = context;
        }
        public Admin GetAdmin(string id)
        {
            var data = context.Admin.Where(x => x.UserName == id).FirstOrDefault();
            return data;
        }
    }
}
