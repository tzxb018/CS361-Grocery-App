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
                return (Id == glist.Id) && (ListName == glist.ListName) && (Items == glist.Items) && (Date == glist.Date);
            }
        }

    }
}
