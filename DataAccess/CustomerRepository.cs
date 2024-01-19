using Models;

namespace DataAccess
{
    public static class CustomerRepository
    {
        public static List<Customer> GetCustomers()
        {
            var result = new List<Customer>();
            using (var context = new DataAccessContext())
            {
                result = context.Customer.ToList();
            }
            return result;
        }

        public static Customer? GetCustomers(int customerId)
        {
            var result = new Customer();
            using (var context = new DataAccessContext())
            {
                result = context.Customer.Where( x => x.Id == customerId).FirstOrDefault();
            }
            return result;
        }

        public static int AddCustomer(Customer customer)
        {
            int result = 0;
            using (var context = new DataAccessContext())
            {
                context.Add(customer);
                result = context.SaveChanges();
            }
            return result;
        }

        public static int DeleteCustomer(int customerId)
        {
            int result = 0;
            using (var context = new DataAccessContext())
            {
                context.Customer.RemoveRange(context.Customer.Where( x => x.Id == customerId));
                result = context.SaveChanges(); 
                
            }
            return result;
        }

        public static int UpdateCustomer(Customer customer)
        {
            int result = 0;
            using (var context = new DataAccessContext())
            {
                foreach (var item in context.Customer.Where(x => x.Id == customer.Id))
                {
                    item.FirstName = customer.FirstName;
                    item.LastName = customer.LastName;  
                    item.Phone = customer.Phone;
                    item.City = customer.City;
                    item.Country = customer.Country;
                }
                result = context.SaveChanges();
            }
            return result;
        }

    }
}
