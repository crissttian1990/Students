using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index(string SearchBy, string Search, int page = 1, int pageSize = 5)
       {
           List<Student> studentsList = StudentBL.GetAllStudents(SearchBy, Search, page, pageSize);

           // Variables for pagination
           ViewBag.SearchBy = SearchBy;
           ViewBag.Search = Search;
           ViewBag.page = page;
           ViewBag.pageSize = pageSize;
           ViewBag.totalStudents = StudentBL.GetAllStudentsCount();

           // Result 
           return View(studentsList);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = BL.StudentBL.Details(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                BL.StudentBL.Create(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = BL.StudentBL.Details(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                BL.StudentBL.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = BL.StudentBL.Details(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL.StudentBL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}