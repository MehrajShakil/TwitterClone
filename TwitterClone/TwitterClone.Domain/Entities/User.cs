namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {

        public User() : base(Guid.NewGuid())
        {

        }

        private string _firstName;
        private string _lastName;
        private string _email;


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private List<Guid> _followers = new List<Guid>();
        private List<Guid> _inComingNotifications = new List<Guid>();

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}";
        }

        public void Follow(Guid userId)
        {
            if(!_followers.Contains(userId))
            {
                _followers.Add(userId);
            }
        }

        public void Unfollow(Guid userId)
        {
            if(_followers.Contains(userId))
            {
                _followers.Remove(userId);
            }
        }

        public void AddNotification(Guid notificationId)
        {
            if(!_inComingNotifications.Contains(notificationId))
            {
                _inComingNotifications.Add(notificationId);
            }
        }
    }
}
