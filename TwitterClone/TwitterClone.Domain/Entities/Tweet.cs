using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        private Guid _userId;
        private string _content;
        

        public Tweet(string content) : base(Guid.NewGuid())
        {
            _content = content;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {UserId}, Content: {Content}";
        }
    }
}
