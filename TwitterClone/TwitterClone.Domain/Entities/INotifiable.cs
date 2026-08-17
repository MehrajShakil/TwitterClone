using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public interface INotifiable
    {
        void AddNotification(Guid notificationId);
    }
}
