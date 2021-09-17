using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Item { 
        [Key]
    
        public int ItemId { get; set; }
    public string Borrow { get; set; }
}
}

