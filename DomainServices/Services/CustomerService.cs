namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> _customers = new();

        private void CustomerAlreadyExists(CustomerEntity selectedCustomer)
        {
            if (_customers.Any(customer => customer.Email == selectedCustomer.Email && customer.Id != selectedCustomer.Id))
                throw new ArgumentException($"Este email: {selectedCustomer.Email} já está em uso, por favor escolha outro");

            if (_customers.Any(customer => customer.Cpf == selectedCustomer.Cpf && customer.Id != selectedCustomer.Id))
                throw new ArgumentException($"Este CPF: {selectedCustomer.Cpf} já está em uso, por favor escolha outro");
        }

        public long Add(CustomerEntity customer)
        {
            CustomerAlreadyExists(customer);
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;
            _customers.Add(customer);
            return customer.Id;
        }

        public void Delete(long id)
        {
            var selectedCustomer = GetCustomerById(id);
            _customers.Remove(selectedCustomer);
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _customers;
        }

        public CustomerEntity GetCustomerById(long id)
        {
            return _customers.FirstOrDefault(x => x.Id == id) ??
                throw new ArgumentNullException($"Não foi encontrado usuário com Id : {id}");
        }

        public void Update(CustomerEntity selectedCustomer)
        {
            var index = _customers.IndexOf(GetCustomerById(selectedCustomer.Id));
            CustomerAlreadyExists(selectedCustomer);
            _customers[index] = selectedCustomer;
        }
    }
}
