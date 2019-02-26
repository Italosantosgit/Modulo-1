using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class CompaniesController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        //UPLOAD DE IMAGENS


        //CONTROLE DE LISTVIEW EM CASCADA
        public JsonResult GetCities(int departamentsId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartamentsId == departamentsId);
            return Json(cities);
        }

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.Cities).Include(c => c.Departaments);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name");
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "CompanyId,Name,Phone,Address,Logo,DepartamentsId,CityId")]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {

                db.Companies.Add(company);
                db.SaveChanges();

                if (company.LogoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", company.CompanyId);

                    var response = FilesHelper.UpLoadPhoto(company.LogoFile, folder, file);
                    if (response)
                    {
                        //{0} NOME DA PASTA, {1} NOME DO ARQUIVO
                        pic = string.Format("{0}/{1}", folder, file);
                        //para adicionar
                        company.Logo = pic;
                        db.Entry(company).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
                ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", company.CityId);
                ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
                return View(company);
        }

            // GET: Companies/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Company company = db.Companies.Find(id);
                if (company == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", company.CityId);
                ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
                return View(company);
            }
            // POST: Companies/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "CompanyId,Name,Phone,Address,Logo,DepartamentsId,CityId")] 
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.LogoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", company.CompanyId);

                    var response = FilesHelper.UpLoadPhoto(company.LogoFile, folder, file);

                    if (response)
                    {
                        //{0} NOME DA PASTA, {1} NOME DO ARQUIVO
                        pic = string.Format("{0}/{1}", folder, file);
                        //para adicionar
                        company.Logo = pic;
                    }
                }
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", company.CityId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
