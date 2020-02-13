using DevExpress.Web.Mvc;
using DiagramFromTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiagramFromTree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(DepartmentProvider.GetDepartments());
        }

        public ActionResult LinearUpdate(MVCxDiagramNodeUpdateValues<Department, int> nodeUpdateValues)
        {
            foreach (var item in nodeUpdateValues.Update)
                DepartmentProvider.Update(item);
            foreach (var itemKey in nodeUpdateValues.DeleteKeys)
                DepartmentProvider.Delete(itemKey);
            foreach (var item in nodeUpdateValues.Insert)
            {
                var insertedItem = DepartmentProvider.Insert(item);
                nodeUpdateValues.MapInsertedItemKey(item, insertedItem.ID);
            }
            return DiagramExtension.GetBatchUpdateResult(nodeUpdateValues);
        }
    }
}