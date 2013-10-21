using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Batch1Work.Helpers;
using Batch1Work.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Batch1Work.Controllers
{

    public class HomeController : Controller
    {
        private const string GRID_ITEMS_KEY = "GridItems";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterMenuCustomization_Building()
        {
            return Json(ActionGridItems.Select(x => x.Building).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_Floor()
        {
            return Json(ActionGridItems.Select(x => x.Floor).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_Area()
        {
            return Json(ActionGridItems.Select(x => x.Area).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_Item()
        {
            return Json(ActionGridItems.Select(x => x.Item).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_ProductType()
        {
            return Json(ActionGridItems.Select(x => x.ProductType).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_AsbestosType()
        {
            return Json(ActionGridItems.Select(x => x.AsbestosType).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_Quantity()
        {
            return Json(ActionGridItems.Select(x => x.Quantity).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_InspFreq()
        {
            return Json(ActionGridItems.Select(x => x.InspFreq).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_MaScore()
        {
            return Json(ActionGridItems.Select(x => x.MaScore).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_PaScore()
        {
            return Json(ActionGridItems.Select(x => x.PaScore).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_RiskScore()
        {
            return Json(ActionGridItems.Select(x => x.RiskScore).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_RiskCategory()
        {
            return Json(ActionGridItems.Select(x => x.RiskCategory).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_RecAction()
        {
            return Json(ActionGridItems.Select(x => x.RecAction).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetActionGridItems([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = ActionGridItems.ToDataSourceResult(request);
            return Json(result);
        }

        private IEnumerable<ActionGridItem> ActionGridItems
        {
            get
            {
                var item = System.Web.HttpContext.Current.Session[GRID_ITEMS_KEY];
                if (item != null)
                    return (IList<ActionGridItem>) item;

                var gridItems = SampleDataHelper.GenerateActionGridItems(1000);
                System.Web.HttpContext.Current.Session[GRID_ITEMS_KEY] = gridItems;
                return gridItems;

            }
        }
    }

}
