namespace InterfaceSegregation
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> SearchByPrice(double minPrice, double maxPrice);
    }

    public interface ISearchByPrice<T> where T : class
    {
        List<T> SearchByPrice(double minPrice, double maxPrice);
    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductRepository : IRepository<Product>, ISearchByPrice<Product>
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> SearchByPrice(double minPrice, double maxPrice)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerRepository : IRepository<Customer>
    {
        public void Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }



        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
