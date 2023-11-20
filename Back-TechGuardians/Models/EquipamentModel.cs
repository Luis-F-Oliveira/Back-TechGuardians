using Back_TechGuardians.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_TechGuardians.Models
{
    public class EquipamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatsEquipament Stats { get; set; }
    }
}
