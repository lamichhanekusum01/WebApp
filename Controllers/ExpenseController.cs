using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.ViewModel;

namespace WebApp.Controllers
{
    public class ExpenseController : Controller
    {    
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
             IEnumerable<Expense> ObjList = _db.Expenses;
            foreach(var obj in ObjList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault( u => u.Id == obj.ExpenseTypeId);
            }
             return View(ObjList);
           // return View();
        }
        //Get-create

        public IActionResult Create()
        {

            List<SelectListItem> TypeDropDown =  _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()

            }).ToList();
            ViewBag.TypeDropDown = TypeDropDown;
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }).ToList()
            };
            return View(expenseVM);
        }

               //POST-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
              //  obj.ExpenseTypeId = 1 ;
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View (obj);
            
        }
         

       
        public IActionResult Delete(int? id)
        {
            
                if (id==null||id==0)
                
                {
                    return NotFound();
                }


               var obj= _db.Expenses.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);


            }

            [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            {
                var obj = _db.Expenses.Find(id);
                    if(obj==null)
                {
                    return NotFound();
                }
                
                   
                        _db.Expenses.Remove(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Index");

                    
                
            }
            

        }
        //GetUpdate
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)

            {
                return NotFound();
            }


            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }
        //Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }

    }
}

