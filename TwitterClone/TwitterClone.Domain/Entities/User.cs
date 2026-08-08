namespace TwitterClone.Domain.Entities
{
    public class User
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _createdAt;
        private DateTime _modifiedAt;
        private Guid _createdBy;
        private Guid _modifiedBy;

        public User()
        {
            _id = Guid.NewGuid();
            _createdAt = DateTime.UtcNow;
        }

        public Guid Id
        {
            get {  return _id; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public DateTime ModifiedAt
        {
            get { return _modifiedAt; }
            set { _modifiedAt = value; }
        }

        public Guid CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public Guid ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }

    }
}
