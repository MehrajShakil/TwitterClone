namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        private Guid _userId;
        private Guid _tweetId;

        public Like() : base(Guid.NewGuid())
        {

        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public Guid TweetId
        {
            get { return _tweetId; }
            set { _tweetId = value; }
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {UserId}, TweetId: {TweetId}";
        }
    }
}
