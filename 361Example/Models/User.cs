using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    public class User
    {
        [Key]
        [Column("AccountId")]
        public int Id { get; set; }
        [Column("Username")]
        public string email { get; set; }
        [Column("EncryptedPassword")]
        public string password { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                User user = (User)obj;
                return (Id == user.Id) && (email == user.email) && (password == user.password);
            }
        }
    }
}
