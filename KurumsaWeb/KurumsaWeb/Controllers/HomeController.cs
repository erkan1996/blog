using KurumsaWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsaWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private KurumsalDBContext db = new KurumsalDBContext();
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult SliderPartial()
		{
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));//slider id ye göre tersten sırlasın die orderby kullandık
        }
        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
        }
        public ActionResult Hakkimizda()
		{
            return View(db.Hakkimizda.SingleOrDefault());
		}
        public ActionResult IletisimPartial()
		{


            return View(db.Iletisim.SingleOrDefault());


		}
        public ActionResult BlogPartial()
		{
            return View(db.Blog.ToList().OrderByDescending(x => x.BlogId));

		}
        public ActionResult HizmetPartialFooter()
		{
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
		}
    }

	
}