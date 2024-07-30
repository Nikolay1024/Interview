using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PriceListEditor2.Infrastructure.Data.Migrations
{
    internal sealed class PriceListEditorConfiguration : DbMigrationsConfiguration<PriceListEditorContext>
    {
        public PriceListEditorConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PriceListEditorContext dbContext)
        {
            List<PriceList> priceLists = new List<PriceList>()
            {
                new PriceList() { Id = 1, Name = "Прайс лист от 01.01.2014", CreatedAt = new DateTime(2024, 1, 1) },
                new PriceList() { Id = 2, Name = "Прайс лист от 01.01.2015", CreatedAt = new DateTime(2024, 1, 1) },
                new PriceList() { Id = 3, Name = "Прайс лист от 01.01.2016", CreatedAt = new DateTime(2024, 1, 1) },
                new PriceList() { Id = 4, Name = "Прайс лист от 01.01.2017", CreatedAt = new DateTime(2024, 1, 1) }
            };
            foreach (PriceList priceList in priceLists)
                dbContext.PriceLists.AddOrUpdate(pl => new { pl.Name, pl.CreatedAt }, priceList);

            List<PriceListColumn> priceListColumns = new List<PriceListColumn>()
            {
                new PriceListColumn() { Id = 1, Name = "Моя колонка (числовая)", Type = PriceListColumnType.Number, PriceListId = 1 },
                new PriceListColumn() { Id = 2, Name = "Еще одна моя колонка (строковая)", Type = PriceListColumnType.String, PriceListId = 1 },
                new PriceListColumn() { Id = 3, Name = "Еще одна моя колонка (текстовая)", Type = PriceListColumnType.Text, PriceListId = 1 },
            };
            foreach (PriceListColumn priceListColumn in priceListColumns)
                dbContext.PriceListColumns.AddOrUpdate(plc => new { plc.Name, plc.Type, plc.PriceListId }, priceListColumn);

            List<PriceListProduct> priceListProducts = new List<PriceListProduct>()
            {
                new PriceListProduct() { Id = 1, Name = "Стул", Code = 1, PriceListId = 1 },
                new PriceListProduct() { Id = 2, Name = "Стол", Code = 2, PriceListId = 1 },
                new PriceListProduct() { Id = 3, Name = "Компьютер", Code = 3, PriceListId = 1 },
                new PriceListProduct() { Id = 4, Name = "Монитор", Code = 4, PriceListId = 1 },
                new PriceListProduct() { Id = 5, Name = "Клавиатура", Code = 5, PriceListId = 1 },
                new PriceListProduct() { Id = 6, Name = "Мышь", Code = 6, PriceListId = 1 },
                new PriceListProduct() { Id = 7, Name = "Коврик", Code = 7, PriceListId = 1 },
                new PriceListProduct() { Id = 8, Name = "Кресло", Code = 8, PriceListId = 1 },
                new PriceListProduct() { Id = 9, Name = "Мышь", Code = 9, PriceListId = 1 },
                new PriceListProduct() { Id = 10, Name = "Сумка", Code = 10, PriceListId = 1 },
                new PriceListProduct() { Id = 11, Name = "Плита", Code = 11, PriceListId = 1 },
            };
            foreach (PriceListProduct priceListProduct in priceListProducts)
                dbContext.PriceListProducts.AddOrUpdate(plc => new { plc.Name, plc.Code, plc.PriceListId }, priceListProduct);

            List<PriceListCell> priceListCells = new List<PriceListCell>()
            {
                new PriceListCell() { Id = 1, Value = "100", PriceListProductId = 1, PriceListColumnId = 1 },
                new PriceListCell() { Id = 2, Value = "Значение для первой строковой колонки", PriceListProductId = 1, PriceListColumnId = 2 },
                new PriceListCell() { Id = 3, Value = "Значение для второй текстовой колонки", PriceListProductId = 1, PriceListColumnId = 3 },

                new PriceListCell() { Id = 4, Value = "700", PriceListProductId = 2, PriceListColumnId = 1 },
                new PriceListCell() { Id = 5, Value = "Деревянный", PriceListProductId = 2, PriceListColumnId = 2 },
                new PriceListCell() { Id = 6, Value = "Красно-зеленый", PriceListProductId = 2, PriceListColumnId = 3 },

                new PriceListCell() { Id = 7, Value = "2", PriceListProductId = 3, PriceListColumnId = 1 },
                new PriceListCell() { Id = 8, Value = "Pentium 4", PriceListProductId = 3, PriceListColumnId = 2 },
                new PriceListCell() { Id = 9, Value = "1.2GHz", PriceListProductId = 3, PriceListColumnId = 3 },

                new PriceListCell() { Id = 10, Value = "8999", PriceListProductId = 4, PriceListColumnId = 1 },
                new PriceListCell() { Id = 11, Value = "Монитор", PriceListProductId = 4, PriceListColumnId = 2 },
                new PriceListCell() { Id = 12, Value = "LG 24MK430H черный", PriceListProductId = 4, PriceListColumnId = 3 },

                new PriceListCell() { Id = 13, Value = "3000", PriceListProductId = 5, PriceListColumnId = 1 },
                new PriceListCell() { Id = 14, Value = "Клавиатура проводная", PriceListProductId = 5, PriceListColumnId = 2 },
                new PriceListCell() { Id = 15, Value = "A4Tech Bloody B800", PriceListProductId = 5, PriceListColumnId = 3 },

                new PriceListCell() { Id = 16, Value = "1499", PriceListProductId = 6, PriceListColumnId = 1 },
                new PriceListCell() { Id = 17, Value = "Мышь проводная", PriceListProductId = 6, PriceListColumnId = 2 },
                new PriceListCell() { Id = 18, Value = "A4Tech Bloody V3/V3M черный", PriceListProductId = 6, PriceListColumnId = 3 },

                new PriceListCell() { Id = 19, Value = "799", PriceListProductId = 7, PriceListColumnId = 1 },
                new PriceListCell() { Id = 20, Value = "Коврик", PriceListProductId = 7, PriceListColumnId = 2 },
                new PriceListCell() { Id = 21, Value = "A4Tech Bloody B-081 черный", PriceListProductId = 7, PriceListColumnId = 3 },

                new PriceListCell() { Id = 22, Value = "11799", PriceListProductId = 8, PriceListColumnId = 1 },
                new PriceListCell() { Id = 23, Value = "Кресло офисное", PriceListProductId = 8, PriceListColumnId = 2 },
                new PriceListCell() { Id = 24, Value = "TetChair BOSS люкс хром 2 TONE", PriceListProductId = 8, PriceListColumnId = 3 },

                new PriceListCell() { Id = 25, Value = "2399", PriceListProductId = 9, PriceListColumnId = 1 },
                new PriceListCell() { Id = 26, Value = "Мышь беспроводная/проводная", PriceListProductId = 9, PriceListColumnId = 2 },
                new PriceListCell() { Id = 27, Value = "A4Tech Bloody R3 черный", PriceListProductId = 9, PriceListColumnId = 3 },

                new PriceListCell() { Id = 28, Value = "1199", PriceListProductId = 10, PriceListColumnId = 1 },
                new PriceListCell() { Id = 29, Value = "Сумка", PriceListProductId = 10, PriceListColumnId = 2 },
                new PriceListCell() { Id = 30, Value = "Continent CC-018 Black", PriceListProductId = 10, PriceListColumnId = 3 },

                new PriceListCell() { Id = 31, Value = "26999", PriceListProductId = 11, PriceListColumnId = 1 },
                new PriceListCell() { Id = 32, Value = "Электрическая плита", PriceListProductId = 11, PriceListColumnId = 2 },
                new PriceListCell() { Id = 33, Value = "Gorenje EC5341SG серебристый", PriceListProductId = 11, PriceListColumnId = 3 },
            };
            foreach (PriceListCell priceListCell in priceListCells)
                dbContext.PriceListCells.AddOrUpdate(plc => new { plc.Value, plc.PriceListProductId, plc.PriceListColumnId }, priceListCell);
        }
    }
}
