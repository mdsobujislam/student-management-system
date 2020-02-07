using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class LoginController : Controller
    {

        ManagementEntities db = new ManagementEntities();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk) 
        {

            if(ModelState.IsValid)
            {
                using (ManagementEntities db = new ManagementEntities())
                {
                    var obj = db.users.Where(a => a.Username.Equals(objchk.Username) && a.Password.Equals(objchk.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }
                }
            }
            return View(objchk);
        }

    //    public ActionResult Logout();
    //{
    //    Session.Clear();
        
    //    return



    //}







	}
}