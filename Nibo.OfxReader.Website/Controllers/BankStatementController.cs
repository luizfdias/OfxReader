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
using Nibo.OfxReader.Website.Models.Reports;

namespace Nibo.OfxReader.Website.Controllers
{
    public class BankStatementController : Controller
    {
        private BankStatementContext db = new BankStatementContext();

        // GET: BankAccounts
        public ActionResult Index()
        {
            return View(db.BankStatements.ToList());
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankStatement bankStatement = db.BankStatements.Find(id);
            if (bankStatement == null)
            {
                return HttpNotFound();
            }

            var bankStatementDetail = new BankStatementDetail(bankStatement);

            return View(bankStatementDetail);
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
