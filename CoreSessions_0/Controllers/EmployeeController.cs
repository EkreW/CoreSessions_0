using CoreSessions_0.ExtensionMethods;
using CoreSessions_0.Models.ContextClasses;
using CoreSessions_0.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime;

namespace CoreSessions_0.Controllers
{
    public class EmployeeController : Controller
    {
        @*
            Bizden istenen senaryo :
            
        Bir Employeer ismi ve soyismini girip SignIn Action'ina post yapsın...Eger o isimde ve soyisimde bir Employee varsa bu employee nesnesi Session'a eklensin ve onu 3. bir Action'a yönlendirerek Session bilgisindeki ismi ve soyismi yazdırın eger öyle bir Employee yoksa ViewBag.Message'de "Böyle bir calısan yoktur" diye mesaj cıkarıp SignIn sayfasında kalmasını saglayın...
         *@

        NorthwindContext _db;
        public EmployeeController(NorthwindContext db)
        {
            _db = db;
        }

        public IActionResult GetSessionData()
        {
            return View();
        }


        public IActionResult SingIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SingIn(Employee item)
        {
            Employee e = _db.Employees.FirstOrDefault(x => x.FirstName == item.FirstName && x.LastName == item.LastName);
            if (e == null)
            {
                ViewBag.Message = "Calisan Bulunamadı!";
                return View();
            }
            HttpContext.Session.SetObject("cagri", e);
            return RedirectToAction("GetSessionData");
        }
    }
}
