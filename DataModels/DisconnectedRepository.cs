using Classes;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class DisconnectedRepository
    {
        public List<Ninja> GetNinjaWithClan()
        {
            using (var context = new NinjaContext())
            {
                return context.Ninjas.AsNoTracking().Include(n => n.Clan).ToList();
            }
        }
    }
}
