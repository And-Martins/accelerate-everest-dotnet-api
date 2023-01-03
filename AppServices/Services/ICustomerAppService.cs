using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerEntity> GetAllCustomers();
        CustomerEntity GetCustomerById(long id);
        long Add(CustomerEntity customer);
        void Update(CustomerEntity customer);
        void Delete(long id);
    }
}
