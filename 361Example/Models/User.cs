using System.ComponentModel.DataAnnotations;


namespace _361Example.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
