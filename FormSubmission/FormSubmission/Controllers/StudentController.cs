using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
       
        public ActionResult Create()
        {
            return View();
        }
        /*
        public ActionResult CreateSubmission(FormCollection f)
        {
            Student s = new Student();
            /*
            s.Id =Request["Id"];
            s.Name = Request["Name"];
            s.Cgpa = Request["Cgpa"];
            //

            s.Id = f["Id"];
            s.Name = f["Name"];
            s.Cgpa = f["Cgpa"];

            return View(s);
        }
        */
        public ActionResult CreateSubmission(Student s)
        {
            return View(s);
        }
    }
}