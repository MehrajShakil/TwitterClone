namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity
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

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}";
        }
    }
}
