using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bricks.DAL;
using Bricks.Models;
using Microsoft.AspNet.Identity;

namespace Bricks.Controllers
{
    public class PropertiesController : Controller
    {
        private AgencyContext db = new AgencyContext();

        /// <summary>
        /// For the logged in AspNetUser, find the corresponding Bricks.Models.User.ID
        /// Returns null if no user is logged in.
        /// </summary>
        /// <returns>integer User.ID or null</returns>
        public int? getUserIDFromIdentityID()
        {
            string id = User.Identity.GetUserId();

            // generally when not logged in
            if (id == null)
            {
                return null;
            }

            int? userID = db.Users.FirstOrDefault(u => u.AspNetUsersID == id).ID;
            return userID;
        }

        // GET: Properties
        public ActionResult Index()
        {
            int? userID = getUserIDFromIdentityID();
            return View(db.Properties.ToList().Where(p => p.UserID != userID));
        }


        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }

            return View(property);


        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,HouseName,HouseNumber,StreetName,Town,Postcode,HousePicUri,NumberOfBedrooms,NumberOfReceptionRooms")] Property property)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)  // just in case I manage to get here without logging in 
            {
                int userID = (int)getUserIDFromIdentityID();
                property.UserID = userID;
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("./Index");
                
            }

            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,HouseName,HouseNumber,StreetName,Town,Postcode,HousePicUri")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("./Index");
            }
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);

            // do I need to manually remove all bids on deleted properties?  Probably
            // need to review all deletions to ensure they work as expected.
            // TODO

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
