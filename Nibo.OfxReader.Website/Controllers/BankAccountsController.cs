using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nibo.OfxReader.Website.Datalayer;
using Nibo.OfxReader.Website.Models;

namespace Nibo.OfxReader.Website.Controllers
{
    public class BankAccountsController : Controller
    {
        private BankStatementContext db = new BankStatementContext();

        // GET: BankAccounts
        public ActionResult Index()
        {
            return View(db.BankAccounts.ToList());
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
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
