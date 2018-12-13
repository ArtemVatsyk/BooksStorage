using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storehouse.ASPNet.Controllers
{
    public class WarehouseController : Controller
    {
        private UnitOfWork unitOfWork;
        public WarehouseController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Warehouse
        [Authorize]
        public ActionResult Index()
        {
            var model = unitOfWork.Storages.GetAll();
            return View(model);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Storage storage)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Storages.Create(storage);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(storage);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Storage storage = unitOfWork.Storages.Get(id);
            if(storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Storage item)
        {
            unitOfWork.Storages.Update(item);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            unitOfWork.Storages.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}