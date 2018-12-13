using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storehouse.ASPNet.Controllers
{
    public class ProductController : Controller
    {
        WarehouseOneEntitiesL db = new WarehouseOneEntitiesL();
        private UnitOfWork unitOfWork;
        public ProductController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Product
        [Authorize]
        public ActionResult Index()
        {
            var model = unitOfWork.Products.GetAll();
            return View(model);
        }
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ProviderName");
            ViewBag.TypeId = new SelectList(db.TypeProducts, "Id", "TypeName");
            ViewBag.StorageId = new SelectList(db.Storages, "Id", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Products.Create(p);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Product product = unitOfWork.Products.Get(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Product item)
        {
            unitOfWork.Products.Update(item);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            unitOfWork.Products.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}