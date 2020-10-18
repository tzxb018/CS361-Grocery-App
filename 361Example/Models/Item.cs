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
        public int GroceryListId { get; set; }
    }
}
