using InventoryManagement.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventoryDBContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();

        }

        public void rolback()
        {
             foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
