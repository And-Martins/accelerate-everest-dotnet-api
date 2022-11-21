using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.SecurityTokenService;
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

        public int AddCustomer(CustomerEntity customer)
        {
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;

            if (Exists(customer)) return 0;

            if(DuplicatedRegister(customer)) return 0;

            _customers.Add(customer);
            return customer.Id;
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

        public void UpdateCustomer (CustomerEntity selectedCustomer, int id)
        {
            var updateCustomer = SearchCustomerById(selectedCustomer.Id);
            if(updateCustomer == null)
            {
                throw new BadRequestException($"Não foi encontrado nenhum registro com este CPF: {selectedCustomer.Cpf}");
            }

            if (DuplicatedRegister(selectedCustomer))
            {
                var index = _customers.IndexOf(updateCustomer);
                _customers[index] = selectedCustomer;
            }
            else
            {
            throw new BadRequestException("Email e CPF já existem na nossa base de dados.");
            }
        }
    }
}
