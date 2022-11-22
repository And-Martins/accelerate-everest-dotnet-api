using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRegister
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> _customers = new();

        private void CustomerAlreadyExists(CustomerEntity selectedCustomer)
        {
            if (_customers.Any(customer => customer.Email == selectedCustomer.Email))
                throw new ArgumentException("Este email já está em uso, por favor escolha outro");

            if (_customers.Any(customer => customer.Cpf == selectedCustomer.Cpf))
                throw new ArgumentException("Este CPF já está em uso, por favor escolha outro");
        }

        public void Add(CustomerEntity customer)
        {
            CustomerAlreadyExists(customer);
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;
            _customers.Add(customer);
        }

        public void Delete(int id)
        {
           var selectedCustomer = GetCustomerById(id);
           _customers.Remove(selectedCustomer);

        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _customers;
        }

        public CustomerEntity GetCustomerById(int id)
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
