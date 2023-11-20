namespace Back_TechGuardians.Models
{
    public class MonitoringModel
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public string Room { get; set; }

        // int? EquipamentId { get; set; }
        public EquipamentModel Equipament { get; set; }

        // public int? UserId { get; set; }
        public UserModel User { get; set; }
    }
}
