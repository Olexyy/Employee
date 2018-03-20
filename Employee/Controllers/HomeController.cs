using Newtonsoft.Json;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Employees";
            ViewBag.TotalEmployees = db.Employees.Count();
            ViewBag.TotalDepartments = db.Departments.Count();
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "Description page.";
            ViewBag.Message = "Powered by ASP.NET MVC 5.";
            return View();
        }
        public ActionResult Autocomplete(string Input)
        {
            List<string> proposal = new List<string>();
            if (!String.IsNullOrEmpty(Input))
            {
                var Employees = this.StartsWithQuery(Input.Trim());
                proposal = Employees.Select(i =>i.Name).Take(5).ToList();
            }
            return PartialView("Proposal", proposal);
        }
        public ActionResult Search(string Search, int? Page)
        {
            ViewBag.Search = (Search == null)? String.Empty : Search.Trim();
            return View(this.SearchQuery(ViewBag.Search, Page));
        }
        private IEnumerable<Employee> SearchQuery(string Search, int? Page)
        {
            IQueryable<Employee> Employees;
            if (!String.IsNullOrEmpty(Search))
                Employees = this.StartsWithQuery(Search);
            else
                Employees = this.db.Employees.AsQueryable();
            int PageSize = 3;
            int PageNumber = (Page ?? 1);
            return Employees.OrderBy(i => i.Name).ToPagedList(PageNumber, PageSize);
        }
        private IQueryable<Employee> StartsWithQuery(string Search, bool NamesOnly = false)
        {
            return from c in this.db.Employees
                   where c.Name.StartsWith(Search)
                   select c;
        }
    }
}