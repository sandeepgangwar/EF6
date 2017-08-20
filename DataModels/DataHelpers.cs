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
    public class DataHelpers
    {
        public static void NewWithSeed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            using (var context = new NinjaContext())
            {
                if (context.Ninjas.Any()) return;
                var vClan = context.Clans.Add(new Clan() { ClanName="Vermont Clan" });
            }
        }
    }
}
