namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
       private readonly ICustomerAppService _customerAppService;

        public long Add(CustomerEntity customer)
        {
            return _customerAppService.Add(customer);
        }

        public void Delete(long id)
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
