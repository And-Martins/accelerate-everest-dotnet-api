namespace DomainServices.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerEntity> GetAllCustomers();
        CustomerEntity GetCustomerById(long id);
        long Add(CustomerEntity customer);
        void Update(CustomerEntity customer);
        void Delete(int id);
    }
}
