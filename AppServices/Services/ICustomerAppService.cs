using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerEntity> GetAllCustomers();
        CustomerEntity GetCustomerById(int id);
        int Add(CustomerEntity customer);
        void Update(CustomerEntity customer);
        void Delete(int id);
    }
}
