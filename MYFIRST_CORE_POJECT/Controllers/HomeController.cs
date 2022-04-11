using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MYFIRST_CORE_POJECT.DB_Context;
using MYFIRST_CORE_POJECT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MYFIRST_CORE_POJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.id = 1;
            ViewBag.name = "Aman Mishra";
            ViewBag.email = "aman@gmail.com";
            ViewBag.designation = "manager";
            ViewBag.List = new List<string>()
            {
                "i",
                "love",
                "my",
                "India"

            };
            ViewData["abc1"] = 1;
            ViewData["abc2"] = "PRAGATI MISHRA";
            ViewData["abc3"] = "praga@gmail.com";
            ViewData["abc4"] = "NOIDA";

            ViewData["abc5"] = "IT";
            ViewData["abc"] = new List<string>()
            {
                "i",
                "love",
                "my",
                "India"

            };
            TempData["abc"] = 3;
            TempData["abc1"] = "rahul";
            TempData["abc2"] = "rahul@gmail.com";
            TempData["abc3"] = "IT";
            TempData["abc4"] = 15000;
            TempData["er"] = new List<String>()
            {
                "welcome tepmdata",
                "how are you ",
                

            };
            HttpContext.Session.SetString("name", "Aman Mishra");
            var data = HttpContext.Session.GetString("name");



            return View();
        }

        public IActionResult Privacy()
        {
            List<empmodel> mod = new List<empmodel>();
            Company_2Context ent = new Company_2Context();
            var data = ent.Employees.ToList();
            foreach (var item in data)
            {
                mod.Add(new empmodel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    Department = item.Department,
                    City = item.City

                });
            }
            return View(mod);
        }
        public IActionResult add_emp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add_emp(empmodel mod)
        {
            Company_2Context ent = new Company_2Context();
            Employee tbl = new Employee();
            tbl.Id = mod.Id;
            tbl.Name = mod.Name;
            tbl.Email = mod.Email;
            tbl.Mobile = mod.Mobile;
            tbl.Department = mod.Department;
            tbl.City = mod.City;
            if (mod.Id == 0)
            {
                ent.Employees.Add(tbl);
                ent.SaveChanges();
                return RedirectToAction("Privacy");
            }
            else
            {
                ent.Entry(tbl).State= EntityState.Modified;
                ent.SaveChanges();
                return RedirectToAction("Privacy");
            }


              

        }
        public IActionResult Edit(int id)
        {
            Company_2Context ent = new Company_2Context();
            var edit = ent.Employees.Where(m => m.Id == id).First();
            empmodel mod = new empmodel();
            mod.Id = edit.Id;
            mod.Name = edit.Name;
            mod.Email = edit.Email;
            mod.Mobile = edit.Mobile;
            mod.Department = edit.Department;
            mod.City = edit.City;
            return View("add_emp", mod);

        }
        public IActionResult delete(int id)
        {
            Company_2Context ent = new Company_2Context();
            var dlt = ent.Employees.Where(m => m.Id == id).First();
            ent.Employees.Remove(dlt);
            ent.SaveChanges();
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
