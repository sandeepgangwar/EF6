using Classes;
using Classes.Enums;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            QueryToLoadRelatedData();
            Console.ReadKey();
        }

        private static void QueryToLoadRelatedData()
        {
            using (var context = new NinjaContext())
            {
                var ninja = context.Ninjas.Where(n=>n.Id == 11).Include(p=>p.EquipmentsOwned).ToList();
            }
        }
        private static void InsertWithRelatedData()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = new Ninja
                {
                    ClanId = 1,
                    Name = "Shaktiman1",
                    DateOfBirth = new DateTime(1990, 11, 11),
                    ServedInOniwaban = true
                };

                var spunk = new NinjaEquipment
                {
                    Id = 1,
                    Name = "Spunk",
                    Type = EquipmentType.Tool
                };
                context.Ninjas.Add(ninja);
                ninja.EquipmentsOwned.Add(spunk);
                context.SaveChanges();
            }
        }

        private static void DeleteNinja()
        {
            using (var context = new NinjaContext())
            {
                var ninja = context.Ninjas.FirstOrDefault();
                context.Ninjas.Remove(ninja);
                context.SaveChanges();
            }
        }

        private static void RetrieveDataWithFind()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja1 = context.Ninjas.Find(3);
                Console.WriteLine("After #1 " + ninja1.Name);

                var ninja2 = context.Ninjas.Find(3);
                Console.WriteLine("After #2 " + ninja2.Name);
            }
        }

        private static void QueryAndUpdateDisconnected()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();

            }

            ninja.ServedInOniwaban = !ninja.ServedInOniwaban;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Attach(ninja);
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void QueryAndUpdate()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var target = context.Ninjas.FirstOrDefault();
                target.ServedInOniwaban = !target.ServedInOniwaban;
                context.SaveChanges();
            }
        }

        private static void SimpleNinjaQuery()
        {
            using (var context = new NinjaContext())
            {
                foreach (var ninja in context.Ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }
        }

        private static void InsertMultipleNinja()
        {

            var ninja1 = new Ninja
            {
                DateOfBirth = new DateTime(1980, 1, 1),
                ClanId = 1,
                Name = "Sampson1",
                ServedInOniwaban = false
            };

            var ninja2 = new Ninja
            {
                DateOfBirth = new DateTime(1980, 1, 1),
                ClanId = 1,
                Name = "Sampson2",
                ServedInOniwaban = false
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(new List<Ninja>
                {
                     ninja1,ninja2
                });
                context.SaveChanges();
            }



        }

        static void InsertNinja()
        {
            var ninja = new Ninja
            {
                DateOfBirth = new DateTime(1980, 1, 1),
                ClanId = 1,
                Name = "Sampson",
                ServedInOniwaban = false
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }
    }
}
