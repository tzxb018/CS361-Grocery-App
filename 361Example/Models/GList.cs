using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    public class GList
    {
        [Key]
        [Column("GroceryListId")]
        public int Id { get; set; }
        [Column("Name")]
        public String ListName { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public int AccountId { get; set; }   

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
