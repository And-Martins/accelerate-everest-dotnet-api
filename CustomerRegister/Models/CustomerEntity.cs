
using CustomerRegister.Models;

    public class CustomerEntity : BaseEntity
    {
        public CustomerEntity(string fullName,
            string email, 
            string emailConfirmation, 
            string cpf, 
            string cellphone,
            DateTime dataOfBirth,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            string address,
            int addressNumber)
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            Cpf = cpf;
            Cellphone = cellphone;
            DataOfBirth = dataOfBirth;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            AddressNumber = addressNumber;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime DataOfBirth { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }

    }
