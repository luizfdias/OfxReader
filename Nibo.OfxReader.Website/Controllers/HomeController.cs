using Nibo.OfxReader.Website.Datalayer;
using Nibo.OfxReader.Website.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Nibo.OfxReader.Website.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public virtual IBankStatementFileService BankStatementFileService { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                if (!fileName.EndsWith(".ofx", StringComparison.InvariantCultureIgnoreCase))
                {
                    ModelState.AddModelError("", "Formato de arquivo inválido");
                    return View();              
                }

                var path = Path.Combine(Server.MapPath("~/App_Data/ofxfiles"), fileName);
                file.SaveAs(path);

                AsyncManager.OutstandingOperations.Increment();

                await this.BankStatementFileService.ProcessFileAsync(path);
            }

            return View();
        }
    }
}