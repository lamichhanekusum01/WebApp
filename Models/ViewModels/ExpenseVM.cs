using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.ViewModel
{
    public class ExpenseVM
    {
        public int Id { get; set; }
        public Expense Expense { get; set; }
        public List<SelectListItem> TypeDropDown{ get; set; }
    }
}
