using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityRegistry.Models
{
    public enum Occupation
    {
        Unemployed,
        Voyager,
        Mercenary,
        Forager,
        Excavater
    }

    internal class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Occupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Birthplace { get; set; }
    }
}
