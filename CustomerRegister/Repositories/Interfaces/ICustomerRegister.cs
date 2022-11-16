namespace CustomerRegister.Repositories.Interfaces
{
    public interface ICustomerRegister
    {
        List<CustomerEntity> SearchAllCustomers();
        //CustomerEntity SearchCustomerById(int id);
        bool AddCustomer(CustomerEntity customer);
        int UpdateCustomer(CustomerEntity customer, int id);
        bool DeleteCustomer(int id);

    }
}
