using Storehouse.Core;
using Storehouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storehouse.ASPNet.Controllers
{
    public class TypesController : Controller
    {
        private UnitOfWork unitOfWork;
        public TypesController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Types
        [Authorize]
        public ActionResult Index()
        {
            var model = unitOfWork.TypeProducts.GetAll();
            return View(model);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(TypeProduct tp)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TypeProducts.Create(tp);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(tp);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            TypeProduct typeProduct = unitOfWork.TypeProducts.Get(id);
            if(typeProduct == null)
            {
                return HttpNotFound();
            }
            return View(typeProduct);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(TypeProduct item)
        {
            unitOfWork.TypeProducts.Update(item);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            unitOfWork.TypeProducts.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}