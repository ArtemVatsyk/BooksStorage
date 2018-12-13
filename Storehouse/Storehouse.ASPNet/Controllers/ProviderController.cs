using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storehouse.ASPNet.Controllers
{
    public class ProviderController : Controller
    {
        private UnitOfWork unitOfWork;
        public ProviderController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Provider
        [Authorize]
        public ActionResult Index()
        {
            var model = unitOfWork.Providers.GetAll();
               
            return View(model);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Provider p)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Providers.Create(p);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Provider provider = unitOfWork.Providers.Get(id);
            if(provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Provider item)
        {
            unitOfWork.Providers.Update(item);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            unitOfWork.Providers.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}