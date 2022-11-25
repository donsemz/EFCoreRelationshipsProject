namespace EFCoreRelationshipsProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        //1 User to Many Characters
        public List<Character> Characters { get; set; }
    }
}
