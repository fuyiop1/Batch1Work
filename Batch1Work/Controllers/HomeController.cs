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
