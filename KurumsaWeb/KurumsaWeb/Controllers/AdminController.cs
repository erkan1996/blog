using KurumsaWeb.Models.DataContext;
using KurumsaWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

//using KurumsaWeb.Models.DataContext;

namespace KurumsaWeb.Content
{
    public class AdminController : Controller
    {
		KurumsalDBContext db = new KurumsalDBContext();
		//Get:Admin
		public ActionResult Index()
        {
            
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        

        }
        public ActionResult login()
		{
            return View();
		}
        [HttpPost]
        public ActionResult login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();//tek veri gelecekse single
            if(login.Eposta==admin.Eposta && login.Sifre == admin.Sifre)
			{
                Session["adminid"] = login.AdminId;//otorum değişkeni
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
			}
            ViewBag.Uyarı = "Hatalı giriş";
            return View(admin);
        }
        public ActionResult logout()
		{
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();//tüm sessionları kapat 
            return RedirectToAction("login","Admin");

            
		}
    }
}