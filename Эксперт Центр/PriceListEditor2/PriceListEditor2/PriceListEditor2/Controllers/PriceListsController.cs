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
    /// <summary>
    /// Контроллер прайс-листа.
    /// </summary>
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

        // GET: /PriceLists/PriceLists
        /// <summary>
        /// Возвращает лист прайс-листов.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Лист прайс-листов.</returns>
        [HttpGet]
        public async Task<ActionResult> PriceLists(CancellationToken cancellationToken)
        {
            List<PriceList> priceLists = await _priceListRepository.GetPriceListsAsync(cancellationToken);

            var priceListsViewModel = new PriceListsViewModel()
            {
                PriceLists = priceLists.Select(p => new PriceListViewModal()
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList()
            };

            return View(priceListsViewModel);
        }

        // GET: /PriceLists/{id}
        /// <summary>
        /// Возвращает подробности прайс-листа.
        /// </summary>
        /// <param name="id">Идентификатор прайс листа</param>
        /// <returns>Прайс-лист.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> DetailsPriceList(CancellationToken cancellationToken, int id)
        {
            PriceList priceList = await _priceListRepository.GetPriceListByIdAsync(cancellationToken, id);
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
        /// <summary>
        /// Возвращает пустую модель прайс-листа.
        /// </summary>
        /// <returns>Прайс-лист.</returns>
        public ActionResult CreatePriceList()
        {
            var createPriceListViewModel = new CreatePriceListViewModel();
            return View(createPriceListViewModel);
        }

        // POST: PriceLists/CreatePriceList
        /// <summary>
        /// Создает новый прайс-лист на основе получаемой модели.
        /// Перенаправляет выполнение на лист прайс-листов.
        /// </summary>
        /// <param name="createPriceListViewModel">Модель прайс-листа</param>
        /// <returns>Объект перенаправления.</returns>
        [HttpPost]
        public async Task<ActionResult> CreatePriceList(CancellationToken cancellationToken, CreatePriceListViewModel createPriceListViewModel)
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

            await _priceListRepository.CreatePriceListAsync(cancellationToken, priceList);

            return RedirectToAction("PriceLists");
        }

        // GET: PriceLists/CreatePriceListProduct/{id}
        /// <summary>
        /// Формирует модель для создания нового товара в прайс-листе.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="id">Идентификатор прайс-листа</param>
        /// <returns>Представление для создания нового товара.</returns>
        [HttpGet]
        public async Task<ActionResult> CreatePriceListProduct(CancellationToken cancellationToken, int id)
        {
            PriceList priceList = await _priceListRepository.GetPriceListByIdAsync(cancellationToken, id);
            var createPriceListProductViewModel = new CreatePriceListProductViewModel() { PriceListId = id };
            foreach (PriceListColumn column in priceList.PriceListColumns)
            {
                createPriceListProductViewModel.Columns.Add(new PriceListColumnViewModel()
                {
                    Name = column.Name,
                    Type = column.Type,
                });
            }

            return View(createPriceListProductViewModel);
        }

        // POST: PriceLists/CreatePriceListProduct
        /// <summary>
        /// Создает товар прайс-листа на основе получаемой модели.
        /// Перенаправляет выполнение на прайс-лист.
        /// </summary>
        /// <param name="createPriceListProductViewModel">Модель товара</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект перенаправления.</returns>
        [HttpPost]
        public async Task<ActionResult> CreatePriceListProduct(CancellationToken cancellationToken,
            CreatePriceListProductViewModel createPriceListProductViewModel)
        {
            var priceListColumns = await _priceListColumnRepository.GetPriceListColumnsByPriceListIdAsync(cancellationToken, Convert.ToInt32(createPriceListProductViewModel.PriceListId));

            var priceListProduct = new PriceListProduct()
            {
                Name = createPriceListProductViewModel.Name,
                Code = Convert.ToInt32(createPriceListProductViewModel.Code),
                PriceListId = Convert.ToInt32(createPriceListProductViewModel.PriceListId)
            };

            int priceListProductId = await _priceListProductRepository.CreatePriceListProductAsync(cancellationToken, priceListProduct);

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

            await _priceListCellRepository.CreatePriceListCellsAsync(cancellationToken, priceListCells);

            return RedirectToAction("DetailsPriceList", new { createPriceListProductViewModel.PriceListId });
        }

        //POST: PriceLists/DeletePriceListProduct/{id}
        /// <summary>
        /// Удаляет товар из прайс-листа по идентификатору товара.
        /// </summary>
        /// <param name="priceListProductId">Идентификатор товара</param>
        /// <returns>JSON-объект, содержащий результат выполнения удаления.</returns>
        [HttpPost]
        public async Task<JsonResult> DeletePriceListProduct(CancellationToken cancellationToken, int priceListProductId)
        {
            await _priceListProductRepository.DeletePriceListProductByIdAsync(cancellationToken, priceListProductId);

            return Json(new { success = true });
        }

        /// <summary>
        /// Получает товары прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListId">Идентификатр прайс-листа</param>
        /// <returns>JSON-объект, содержащий товары прайс-листа.</returns>
        [HttpPost]
        public async Task<JsonResult> PriceListProductsDataHandler(CancellationToken cancellationToken, /*DTParameters param, */ int priceListId)
        {
            PriceList priceList = await _priceListRepository.GetPriceListByIdAsync(cancellationToken, priceListId);

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
