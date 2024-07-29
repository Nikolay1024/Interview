using Ninject.Modules;
using PriceListEditor2.Domain.Interfaces;
using PriceListEditor2.Infrastructure.Data.Repositories;

namespace PriceListEditor2.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IPriceListRepository>().To<PriceListRepository>();
            Bind<IPriceListColumnRepository>().To<PriceListColumnRepository>();
            Bind<IPriceListProductRepository>().To<PriceListProductRepository>();
            Bind<IPriceListCellRepository>().To<PriceListCellRepository>();
        }
    }
}