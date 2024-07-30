using System;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly PriceListEditorContext _dbContext;
        private bool _disposed = false;

        public BaseRepository()
        {
            _dbContext = new PriceListEditorContext();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
