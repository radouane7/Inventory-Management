using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        void rolback();

    }
}
