using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class User
{
    [Key]
    public int Id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}

