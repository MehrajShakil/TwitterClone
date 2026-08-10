using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification() : base("System")
        {

        }

        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string DescribeRecord()
        {
            return base.DescribeRecord();
        }
    }
}
