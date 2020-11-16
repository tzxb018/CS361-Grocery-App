using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    public class Item
    {
        [Key]
        [Column("ItemId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Checkoff { get; set; }
        public int Quantity { get; set; }
        public int GroceryListId { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Item item = (Item)obj;
                return (Id == item.Id) && (Name == item.Name) && (Date == item.Date) &&
                    (Checkoff == item.Checkoff) && (Quantity == item.Quantity) && (GroceryListId == item.GroceryListId);
            }
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 7 * hash + Id;
            hash = 11 * hash + (Name != null ? Name.GetHashCode() : 0);
            hash = 13 * hash + (Date != null ? Date.GetHashCode() : 0);
            hash = 17 * hash + (Checkoff ? 1 : 0);
            hash = 19 * hash + GroceryListId;
            return hash;
        }

    }
}
