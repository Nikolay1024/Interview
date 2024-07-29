using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using PriceListEditor2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PriceListEditor2.Controllers
{
    [RoutePrefix("PriceLists")]
    public class PriceListsController : Controller
    {
        private readonly IPriceListRepository _priceListRepository;
        private readonly IPriceListColumnRepository _priceListColumnRepository;
        private readonly IPriceListProductRepository _priceListProductRepository;
        private readonly IPriceListCellRepository _priceListCellRepository;

        public PriceListsController(IPriceListRepository priceListRepository, IPriceListColumnRepository priceListColumnRepository,
            IPriceListProductRepository priceListProductRepository, IPriceListCellRepository priceListCellRepository)
        {
            _priceListRepository = priceListRepository;
            _priceListColumnRepository = priceListColumnRepository;
            _priceListProductRepository = priceListProductRepository;
            _priceListCellRepository = priceListCellRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> PriceLists(FilteredPriceListParameters parameters, CancellationToken cancellationToken)
        {
            IEnumerable<PriceList> priceLists = await _priceListRepository
                .GetFilteredListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);

            var filteredPriceListsViewModel = new FilteredPriceListsViewModel
            {
                Items = priceLists.Select(p => new PriceListViewModal()
                {
                    Id = p.Id,
                    Title = p.Name,
                }).ToList()
            };

            return View(filteredPriceListsViewModel);
        }

        // GET: /PriceLists/{id}
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult DetailsPriceList(int id)
        {
            PriceList priceList = _priceListRepository.GetPriceListById(id);
            var detailsPriceListViewModel = new DetailsPriceListViewModel()
            {
                Id = priceList.Id,
                Name = priceList.Name,
                Columns = priceList.PriceListColumns.Select(plc => plc.Name).ToList(),
                Products = priceList.PriceListProducts.Select(plp => new PriceListProductViewModel()
                {
                    Name = plp.Name,
                    Code = plp.Code,
                    Cells = plp.PriceListCells.Select(plc => new GetPriceListCellViewModel()
                    {
                        ColumnId = plc.PriceListColumnId,
                        Value = plc.Value
                    }).ToList(),
                }).ToList()
            };

            return View(detailsPriceListViewModel);
        }

        // GET: PriceLists/CreatePriceList
        public ActionResult CreatePriceList()
        {
            var createPriceListViewModel = new CreatePriceListViewModel();
            return View(createPriceListViewModel);
        }

        // POST: PriceLists/CreatePriceList
        [HttpPost]
        public ActionResult CreatePriceList(CreatePriceListViewModel createPriceListViewModel)
        {
            var priceListColumns = new List<PriceListColumn>();
            foreach (PriceListColumnViewModel columns in createPriceListViewModel.Columns)
            {
                priceListColumns.Add(new PriceListColumn()
                {
                    Name = columns.Name,
                    Type = columns.Type,
                });
            }

            var priceList = new PriceList()
            {
                Name = createPriceListViewModel.Name,
                CreatedAt = DateTime.Now,
                PriceListColumns = priceListColumns,
            };

            _priceListRepository.CreatePriceList(priceList);
            _priceListColumnRepository.CreatePriceListColumns(priceListColumns);

            return RedirectToAction("PriceLists");
        }

        // GET: PriceLists/CreatePriceListProduct/{id}
        [HttpGet]
        public ActionResult CreatePriceListProduct(int id)
        {
            PriceList priceList = _priceListRepository.GetPriceListById(id);
            var createPriceListProductViewModel = new CreatePriceListProductViewModel() { PriceListId = id };
            foreach (PriceListColumn column in priceList.PriceListColumns)
            {
                createPriceListProductViewModel.Columns.Add(new PriceListColumnViewModel()
                {
                    Name= column.Name,
                    Type = column.Type,
                });
            }
            
            return View(createPriceListProductViewModel);
        }

        // POST: PriceLists/CreatePriceListProduct
        [HttpPost]
        public async Task<ActionResult> CreatePriceListProduct(CreatePriceListProductViewModel createPriceListProductViewModel,
            CancellationToken cancellationToken)
        {
            var priceListColumns = _priceListColumnRepository.GetPriceListColumnsByPriceListId(Convert.ToInt32(createPriceListProductViewModel.PriceListId));

            var priceListProduct = new PriceListProduct()
            {
                Name = createPriceListProductViewModel.Name,
                Code = Convert.ToInt32(createPriceListProductViewModel.Code),
                PriceListId = Convert.ToInt32(createPriceListProductViewModel.PriceListId)
            };

            int priceListProductId = await _priceListProductRepository.CreatePriceListProductAsync(priceListProduct, cancellationToken);

            var priceListCells = new List<PriceListCell>();
            for (int i = 0; i < priceListColumns.Count; i++)
            {
                priceListCells.Add(new PriceListCell()
                {
                    Value = createPriceListProductViewModel.Cells[i],
                    PriceListProductId = priceListProductId,
                    PriceListColumnId = priceListColumns[i].Id,
                });
            }

            _priceListCellRepository.CreatePriceListCells(priceListCells);

            return RedirectToAction("DetailsPriceList", new { createPriceListProductViewModel.PriceListId });
        }

        //POST: PriceLists/Delete/5
        [HttpPost]
        public JsonResult Delete(int priceListProductId)
        {
            _priceListProductRepository.Delete(priceListProductId);
            
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult PriceListProductsDataHandler(/*DTParameters param, */int priceListId)
        {
            PriceList priceList = _priceListRepository.GetPriceListById(priceListId);

            List<PriceListProductViewModel> priceListProductsViewModel = priceList.PriceListProducts
                .Select(plp => new PriceListProductViewModel()
                {
                    Id = plp.Id,
                    Name = plp.Name,
                    Code = plp.Code,
                    Cells = plp.PriceListCells.Select(plc => new GetPriceListCellViewModel()
                    {
                        ColumnId = plc.PriceListColumnId,
                        Value = plc.Value
                    }).ToList(),
                    Columns = priceList.PriceListColumns.Select(plc => new GetPriceListColumnViewModel()
                    {
                        Id = plc.Id,
                        Name = plc.Name
                    }).ToList(),
                }).ToList();

            //if (!string.IsNullOrEmpty(param.Search?.Value))
            //{
            //    string str = param.Search.Value.ToLower();
            //    priceListProductsViewModel = priceListProductsViewModel.Where(pl => pl.Cells.ContainsValue(str)).ToList();
            //}

            var cnt = priceListProductsViewModel.Count();

            var result = new DTResult<PriceListProductViewModel>()
            {
                //draw = param.Draw,
                data = priceListProductsViewModel.AsEnumerable(),
                recordsFiltered = cnt,
                recordsTotal = cnt,
            };

            return Json(result);
        }
    }
}
