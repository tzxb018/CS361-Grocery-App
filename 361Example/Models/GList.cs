using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    /**
     * The purpose of the GList class is to serve as the model for a grocery list.
     * Since every grocery list belongs to an account, the AccountId field links
     * the corresponding User to each GList.
     * The Id field acts as the unique identifier for a GList object.
     * The GList class also has attributes ListName and Date in order that allow
     * the name of the grocery list to be specified as well as when its last update
     * occurred.
     **/
    public class GList
    {
        [Key]
        [Column("GroceryListId")]
        public int Id { get; set; }
        [Column("Name")]
        public String ListName { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }   

        //The overriden Equals method determines whether this GList and another object are equal based on GList's fields
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                GList glist = (GList)obj;
                return (Id == glist.Id) && (ListName == glist.ListName) && (Date == glist.Date) && (AccountId == glist.AccountId);
            }
        }

        //The overriden GetHashCode method ensures that any equal GLists have the same hash code
        public override int GetHashCode()
        {
            int hash = 5;
            hash = 7 * hash + Id;
            hash = 11 * hash + (ListName != null ? ListName.GetHashCode() : 0);
            hash = 13 * hash + (Date != null ? Date.GetHashCode() : 0);
            hash = 17 * hash + AccountId;
            return hash;
        }

    }
}
