using DataAccessLayer.EntityFramework;
using PriceListEditor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceListEditor.Controllers
{
    public class PriceListController : Controller
    {
        private PriceListEditorEntities DbContext = new PriceListEditorEntities();
        
        public ActionResult GetPriceLists()
        {
            List<PriceList> priceLists = DbContext.PriceLists.ToList();
            return View("PriceLists", priceLists);
        }

        public ActionResult GetPriceListById(int id)
        {
            PriceList priceList = DbContext.PriceLists.Find(id);
            IQueryable<Column> columns = DbContext.Columns.Where(col => col.PriceListId == id);
            List<Cell> cells = DbContext.Cells.Where(cel => columns.Select(col => col.Id).Contains(cel.ColumnId)).ToList();

            var priceListModel = new PriceListModel()
            {
                PriceList = priceList,
                Columns = columns.ToList(),
                Cells = cells,
            };
            return View("PriceList", priceListModel);
        }

        public ActionResult AddPriceList()
        {
            //HtmlString
            return View();
        }

        [HttpPost]
        public ActionResult AddPriceList(PriceList priceList)
        {
            DbContext.PriceLists.Add(priceList);
            DbContext.SaveChanges();
            return RedirectToAction("GetPriceLists");
        }

        public ActionResult AddRow()
        {
            return View();
        }
    }
}