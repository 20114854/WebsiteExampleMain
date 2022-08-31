using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebsiteExampleMain.Models;

namespace WebsiteExampleMain.Controllers
{


    public class StaffContoller : Controller
    {

        StaffContext db = new StaffContext();
        public IActionResult StaffList()
        {
            return View(StaffContext.Staffobject);
        }

        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddStaff(Staff sf)
        {
            Staff data = sf;
            if(sf.Name==null||sf.Id<0||sf.Password==null||sf.Dob==null||sf.Title==null)
            {
                ViewBag.Error = "Please enter all the values in each field";
                return View();
            }
            else
            {
                StaffContext.Staffobject.Add(sf);
                return RedirectToAction("StaffList");
            }

        }

        public IActionResult EditStaff(int id)
        {
            Staff temp = StaffContext.Staffobject.Where(x => x.Id==id).FirstOrDefault();
            return View(temp);
        }

        public IActionResult EditStaff(Staff sf)
        {
            Staff data = sf;
            if (sf.Name == null || sf.Id < 0 || sf.Password == null || sf.Dob == null || sf.Title == null)
            {
                ViewBag.Error = "Please enter all the values in each field";
                return View();
            }
            else
            {
                (from p in StaffContext.Staffobject
                 where p.Id == sf.Id
                 select p).ToList().ForEach(x =>
                 {
                     x.Password = sf.Password;
                     x.Dob = sf.Dob;
                     x.Title = sf.Title;
                     x.Name = sf.Name;
                 });
                return RedirectToAction("StaffList");
            }

        }

        public IActionResult ViewStaff(int id)
        {
            Staff temp = StaffContext.Staffobject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }

        public IActionResult DeleteStaff(int id)
        {
            Staff temp = StaffContext.Staffobject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }
        [HttpPost]

        public IActionResult DeleteStaff(Staff sf)
        {
            StaffContext.Staffobject = StaffContext.Staffobject.Where(x => x.Id != sf.Id).ToList();
            return RedirectToAction("StaffList");
        }
    }
}
