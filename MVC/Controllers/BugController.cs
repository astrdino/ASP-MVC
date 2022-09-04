using System;
using System.Collections.Generic;

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class BugController : Controller
    {
        private BugDatabaseEntities1 db = new BugDatabaseEntities1();



        
        // GET: Bug
        public ActionResult Index()
        {

            calcount(); //Get Total Count of Sql Data
            calHighRisk();

            var sqlDataList = Fetch();

            
            

            //var sqlData = FetchOne();

            return View("Index", sqlDataList);



            //return View(db.Table_1.ToList());
        }

      


        public ActionResult SearchButtonHandle(int id)
        {

            calcount(); //Get Total Count of Sql Data

            SqlFetch data = new SqlFetch();

            Table_1 obj = data.FetchOne(id);

            

            return View("Search", obj);

        }

        [HttpPost]
        public ActionResult SearchButtonHandle(FormCollection form)
        {

            ViewBag.test = form["SearchInput"];

            SqlFetch data = new SqlFetch();

            int numericValue;

            if (int.TryParse(ViewBag.test, out numericValue))
            {
                Table_1 obj = data.FetchOne(Int32.Parse(ViewBag.test));
                return View("Search", obj);

            }
            else
            {

                List<Table_1> list = new List<Table_1>();
                return View("Index", list);
            }

            



           

        }


        // GET: Bug/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_1 table_1 = db.Table_1.Find(id);
            if (table_1 == null)
            {
                return HttpNotFound();
            }
            return View(table_1);
        }

        // GET: Bug/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bug/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date,Bug_Level")] Table_1 table_1)
        {
            if (ModelState.IsValid)
            {
                db.Table_1.Add(table_1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_1);
        }

        // GET: Bug/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_1 table_1 = db.Table_1.Find(id);
            if (table_1 == null)
            {
                return HttpNotFound();
            }
            return View(table_1);
        }

        // POST: Bug/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date")] Table_1 table_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_1);
        }

        // GET: Bug/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_1 table_1 = db.Table_1.Find(id);
            if (table_1 == null)
            {
                return HttpNotFound();
            }
            return View(table_1);
        }

        // POST: Bug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_1 table_1 = db.Table_1.Find(id);
            db.Table_1.Remove(table_1);
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


        public void calcount()
        {
            ViewBag.Count = db.Table_1.Count();
            
            
        }

        public void calHighRisk()
        {

            SqlFetch data = new SqlFetch();


            ViewBag.AmtHR = data.FetchHRAmt();
        }

        public List<Table_1> Fetch()
        {
            List<Table_1> dataObject = new List<Table_1>();

            SqlFetch data = new SqlFetch();

            dataObject = data.Fetch();

            return dataObject;
        }


        


    }
}
