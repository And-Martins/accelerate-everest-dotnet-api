using DomainServices.Services;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
       private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new System.ArgumentNullException(nameof(customerService));
        }

        public long Add(CustomerEntity customer)
        {
            return _customerService.Add(customer);
        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        public CustomerEntity GetCustomerById(long id)
        {
            return _customerService.GetCustomerById(id);
        }

        public void Update(CustomerEntity customer)
        {
            _customerService.Update(customer);
        }
    }
}
