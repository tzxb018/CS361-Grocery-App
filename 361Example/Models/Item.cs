using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _361Example.Models
{
    /**
     * The purpose of the Item class is to serve as a model for a grocery list item.
     * Since every item belongs to a grocery list, the GroceryListId field links
     * the corresponding GList to each Item.
     * The Id field acts as the unique identifier for an Item object.
     * The Item class also has fields for name, date, checkoff, and quantity in order to
     * properly model a grocery list item according to requirements.
     **/
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

        //The overriden Equals method determines whether this Item and another object are equal based on Item's fields
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Item item = (Item)obj;
                return (Id == item.Id) && (Name == item.Name) &&
                    (Checkoff == item.Checkoff) && (Quantity == item.Quantity) && (GroceryListId == item.GroceryListId);
            }
        }

        //The overriden GetHashCode method ensures that any equal Items have the same hash code
        public override int GetHashCode()
        {
            int hash = 5;
            hash = 7 * hash + Id;
            hash = 11 * hash + (Name != null ? Name.GetHashCode() : 0);
            hash = 17 * hash + (Checkoff ? 1 : 0);
            hash = 19 * hash + GroceryListId;
            return hash;
        }

    }
}
