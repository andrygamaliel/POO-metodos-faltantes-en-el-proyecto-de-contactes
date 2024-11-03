namespace PersonalAgenda
{
    public class Person
    {
        public int Identifier { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public int YearsOld { get; set; }
        public string Location { get; set; }
        public bool IsCloseFriend { get; set; }

        public Person(int identifier, string firstName, string surname, string location, string phoneNumber, string contactEmail, int yearsOld, bool isCloseFriend)
        {
            Identifier = identifier;
            FirstName = firstName;
            Surname = surname;
            PhoneNumber = phoneNumber;
            ContactEmail = contactEmail;
            YearsOld = yearsOld;
            Location = location;
            IsCloseFriend = isCloseFriend;
        }
    }
}
