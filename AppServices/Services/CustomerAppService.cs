namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
       private readonly ICustomerAppService _customerAppService;

        public int Add(CustomerEntity customer)
        {
            return _customerAppService.Add(customer);
        }

        public void Delete(int id)
        {
            _customerAppService.Delete(id);
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _customerAppService.GetAllCustomers();
        }

        public CustomerEntity GetCustomerById(int id)
        {
            return _customerAppService.GetCustomerById(id);
        }

        public void Update(CustomerEntity customer)
        {
            _customerAppService.Update(customer);
        }
    }
}
