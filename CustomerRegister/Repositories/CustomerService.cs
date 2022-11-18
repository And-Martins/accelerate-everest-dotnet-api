using CustomerRegister.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRegister
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> _customers = new();

        public bool Exists(CustomerEntity selectedCustomer)
        {
            var response = _customers.Any(customer => customer.Cpf == selectedCustomer.Cpf || customer.Email == selectedCustomer.Email) && (selectedCustomer.Id != selectedCustomer.Id);
            return response;
        }

        public bool DuplicatedRegister(CustomerEntity selectedCustomer)
        {
            if(_customers.Any(customer => customer.Cpf == selectedCustomer.Cpf || customer.Email == selectedCustomer.Email))
                {
                return true;
                }
            return false;
        }

        public bool AddCustomer(CustomerEntity customer)
        {
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;
            if (Exists(customer)) return false;
            if(DuplicatedRegister(customer)) return false;
            _customers.Add(customer);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            int index = _customers.FindIndex(customer => customer.Id == id);

            if(index == -1) return false;

            _customers.RemoveAt(index);
            return true;
        }

        public List<CustomerEntity> SearchAllCustomers()
        {
            return _customers;
        }

        public CustomerEntity SearchCustomerById(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id) ?? null;
        }

        public int UpdateCustomer(CustomerEntity selectedCustomer, int id)
        {
            var updateCustomer = SearchCustomerById(selectedCustomer.Id);
            if(updateCustomer == null)
            {
                return -1;
            }

            if (DuplicatedRegister(selectedCustomer))
            {
                var index = _customers.IndexOf(updateCustomer);
                _customers[index] = selectedCustomer;
                return index;
            }
            return 0;   
        }
    }
}
