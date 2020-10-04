using System;
using System.ComponentModel.DataAnnotations;

namespace _361Example.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Checkoff { get; set; }
    }
}
