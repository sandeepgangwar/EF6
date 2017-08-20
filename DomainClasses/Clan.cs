using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Clan : IModificationHistory
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDirty { get; set; }
    }
}
