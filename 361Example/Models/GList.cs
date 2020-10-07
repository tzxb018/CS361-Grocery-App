using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Models
{
    public class GList
    {
        [Key]
        public int Id { get; set; }
        public String ListName { get; set; }
        public IEnumerable<Item> items { get; set; }

    }
}
