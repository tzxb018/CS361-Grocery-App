using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    /**
     * The purpose of the User class is to serve as a model for a user/account of the grocery app.
     * The Id field acts as the unique identifier for a User object.
     * The User class also has fields for email and password, since every User must have an
     * email and password in order to create an account.
     **/
    public class User
    {
        [Key]
        [Column("AccountId")]
        public int Id { get; set; }
        [Column("Username")]
        public string Email { get; set; }
        [Column("EncryptedPassword")]
        public string Password { get; set; }

        //The overriden Equals method determines whether this User and another object are equal based on User's fields
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                User user = (User)obj;
                return (Id == user.Id) && (Email == user.Email) && (Password == user.Password);
            }
        }

        //The overriden GetHashCode method ensures that any equal Users have the same hash code
        public override int GetHashCode()
        {
            int hash = 5;
            hash = 7 * hash + Id;
            hash = 11 * hash + (Email != null ? Email.GetHashCode() : 0);
            hash = 13 * hash + (Password != null ? Password.GetHashCode() : 0);
            return hash;
        }

    }
}
