using DataAccess;
using Models;

namespace BusinessLayer
{
    public class CustomerService : IService<Customer>
    {
        public int Add(Customer item)
        {
            return CustomerRepository.AddCustomer(item);
        }

        public int Delete(int id)
        {
            return CustomerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAll()
        {
            return CustomerRepository.GetCustomers();
        }

        public Customer? GetDetails(int id)
        {
            return CustomerRepository.GetCustomers(id);
        }

        public int Update(Customer item)
        {
            return CustomerRepository.UpdateCustomer(item);
        }
    }
}
