using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Category.AddCategory.Notifications
{
    public class AddCategorySendEmailHandler : INotificationHandler<AddCategoryNotification>
    {
        public Task Handle(AddCategoryNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
