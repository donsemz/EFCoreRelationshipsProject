using System.Text.Json.Serialization;

namespace EFCoreRelationshipsProject.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        
        [JsonIgnore]
        //Single user and defined FKey is UserId Many to 1 relationship
        public User User { get; set; }
        public int UserId { get; set; }
        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
