using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> ObjList = _db.ExpenseTypes;
            // IEnumerable<ExpenseTypeController> ObjList = (IEnumerable<ExpenseTypeController>)_db.ExpenseTypes;
            return View(ObjList);
           // return View();
        }
        //Get-create

        public IActionResult Create()
        {
            return View();
        }
       //POST-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                
                _db.ExpenseTypes.Add(obj);
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


               var obj= _db.ExpenseTypes.Find(id);
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
                var obj = _db.ExpenseTypes.Find(id);
                    if(obj==null)
                {
                    return NotFound();
                }
                
                   
                        _db.ExpenseTypes.Remove(obj);
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


            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }
        //Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }

    }
}

