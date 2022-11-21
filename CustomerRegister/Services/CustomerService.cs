using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;
using BadRequestException = SendGrid.Helpers.Errors.Model.BadRequestException;

namespace CustomerRegister
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> _customers = new();

        public bool Exists(CustomerEntity selectedCustomer)
        {
            var response = _customers
                .Any(customer => customer.Cpf == selectedCustomer.Cpf || customer.Email == selectedCustomer.Email) && (selectedCustomer.Id != selectedCustomer.Id);
            return response;
        }

        public void DuplicatedEmail(CustomerEntity selectedCustomer)
        {
            if(_customers.Any(customer => customer.Email == selectedCustomer.Email))
                throw new BadRequestException("Este email já está em uso, por favor escolha outro");
        }

        public void DuplicatedCPF(CustomerEntity selectedCustomer)
        {
            if (_customers.Any(customer => customer.Cpf == selectedCustomer.Cpf))
                throw new BadRequestException("Este CPF já está em uso, por favor escolha outro");
        }

        public void Add(CustomerEntity customer)
        {
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;

            if (!Exists(customer))
            {
                DuplicatedCPF(customer);
                DuplicatedEmail(customer);
                _customers.Add(customer);

              
            }
        }

        public void Delete(int id)
        {
            if (GetCustomerById(id) is not null){
            _customers.Remove(GetCustomerById(id));
            }
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _customers;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id) ?? 
                throw new BadRequestException($"Não foi encontrado usuário com Id : {id}");
        }

        public void Update (CustomerEntity selectedCustomer)
        {
            GetCustomerById(selectedCustomer.Id);
            {
                DuplicatedCPF(selectedCustomer);
                DuplicatedEmail(selectedCustomer);
                
                var index = _customers.IndexOf(GetCustomerById(selectedCustomer.Id));
                    _customers[index] = selectedCustomer;
            }

        }
    }
}
