using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            dynamic info = new Dictionary<string, string>()
            {
                {"Name", "Pritom Debnath"},
                {"Id", "20-42414-1"},
                {"Department", "CSE"},
                {"Email", "debnathpritom@outlook.com"}
            };
            ViewBag.Info = info;
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult Projects()
        {
            List<Dictionary<string, string>> projects_list = new List<Dictionary<string, string>>();
            Dictionary<string, string> projects = new Dictionary<string, string>();

            projects.Add("Name", "Hospital Occupancy");
            projects.Add("GitLink", "https://github.com/PritoM-Debnath/Web_Tech_Project");
            projects_list.Add(new Dictionary<string, string>(projects));

            projects["Name"] = "Super Shop Managment System";
            projects["GitLink"] = "https://github.com/PritoM-Debnath/C-sharp";
            projects_list.Add(new Dictionary<string, string>(projects));

            ViewBag.projects_list = projects_list;

            return View();
        }

        public ActionResult Reference()
        {
            return View();
        }
    }
}