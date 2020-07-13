using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testASPMVC.Models.BusinessObjectLayer.Base;
using testASPMVC.Services.Base;

namespace testASPMVC.Controllers.Base
{
    public abstract class CRUDController<TBaseDTO, TService> : Controller
        where TBaseDTO : BaseDTO
        where TService : CRUDService<TBaseDTO>, new()
    {
        protected TService service = new TService();

        [HttpGet]
        public virtual JsonResult Get(Guid entityId)
        {
            var result = service.Get(entityId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual ActionResult GetList()
        {
            var viewModelList = service.GetList();
            return Json(viewModelList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult Save(TBaseDTO viewModel)
        {
            var result = service.Save(viewModel));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual void Update(TBaseDTO viewModel)
        {
            service.Update(viewModel);
        }

        [HttpPost]
        public virtual void Delete(Guid entityId)
        {
            service.Delete(entityId);
        }
    }
}