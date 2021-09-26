using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Item { 
        [Key]
    
        public int ItemId { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="please insert the value greater than 0")]
        public string Borrow { get; set; }
        public string Lender { get; set; }
        [DisplayName("Item Name")]

        public string ItemName { get; set; }
    }
}

