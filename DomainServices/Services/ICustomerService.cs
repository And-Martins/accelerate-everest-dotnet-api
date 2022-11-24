namespace DomainServices.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerEntity> GetAllCustomers();
        CustomerEntity GetCustomerById(int id);
        int Add(CustomerEntity customer);
        void Update(CustomerEntity customer);
        void Delete(int id);
    }
}
