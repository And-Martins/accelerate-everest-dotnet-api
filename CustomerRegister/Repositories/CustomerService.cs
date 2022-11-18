

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

        public bool AddCustomer(CustomerEntity customer)
        {
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;
            if (Exists(customer)) return false;
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
            int index = _customers.FindIndex(customer=>customer.Id == id);
            if (index == -1) return -1;
            if (!Exists(selectedCustomer))
            {
                _customers[index].Id= id;
                _customers[index] = selectedCustomer;
                return 0;
            }
            selectedCustomer.Id = _customers[index].Id;
            _customers[index] = selectedCustomer;
            return 1;
        }

       

        //    private readonly RegisterDBContext _dbContext;
        //    public CustomerRegister(RegisterDBContext registerDBContext)
        //    {
        //        _dbContext = registerDBContext;
        //    }
        //    public async Task<CustomerEntity> SearchCustomerById(int id)
        //    {
        //        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        //    }
        //    public async Task<List<CustomerEntity>> SearchAllCustomers()
        //    {
        //        return await _dbContext.Customers.ToListAsync();
        //    }
        //    public async Task<CustomerEntity> AddCustomer(CustomerEntity customer)
        //    {
        //        await _dbContext.Customers.AddAsync(customer);
        //        await _dbContext.SaveChangesAsync();

        //        return customer;
        //    }

        //    public async Task<CustomerEntity> UpdateCustomer(CustomerEntity customer, int id)
        //    {
        //        CustomerEntity customerFound = await SearchCustomerById(id);
        //        if(customerFound == null)
        //        {
        //            throw new Exception($"Usuário com ID:{id} não foi encontrado.");
        //        }

        //        customerFound.FullName = customer.FullName;
        //        customerFound.Email = customer.Email;
        //        customerFound.EmailConfirmation = customer.EmailConfirmation;
        //        customerFound.Cpf = customer.Cpf;
        //        customerFound.Cellphone = customer.Cellphone;
        //        customerFound.DataOfBirth = customer.DataOfBirth;
        //        customerFound.EmailSms = customer.EmailSms;
        //        customerFound.Whatsapp = customer.Whatsapp;
        //        customerFound.Country = customer.Country;
        //        customerFound.City = customer.City;
        //        customerFound.PostalCode = customer.PostalCode;
        //        customerFound.Address = customer.Address;
        //        customerFound.AddressNumber = customer.AddressNumber;

        //        _dbContext.Update(customerFound);
        //        await _dbContext.SaveChangesAsync();
        //        return customerFound;
        //    }
        //    public async Task<bool> DeleteCustomer(int id)
        //    {
        //        CustomerEntity customerFound = await SearchCustomerById(id);

        //        if(customerFound == null)
        //        {
        //            throw new Exception($"Usuário com ID:{id} não foi encontrado.");
        //        }
        //        _dbContext.Customers.Remove(customerFound);
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //}
    }
}
