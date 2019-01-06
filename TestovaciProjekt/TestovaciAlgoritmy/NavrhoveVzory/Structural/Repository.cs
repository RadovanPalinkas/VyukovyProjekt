using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.NavrhoveVzory.Structural
{

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Remove(T entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IMyDbContext dbContext;

        public Repository(IMyDbContext dbContext )
        {
            this.dbContext = dbContext;
        }

        //add Entity
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }
        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate);
        }
        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable< Customer> GetCustomerByOrderId(int orderId);
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMyDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable< Customer> GetCustomerByOrderId(int orderId)
        {           
            return dbContext.Set<Customer>().Where(o => o.OrderId == orderId).ToList();
        }
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmpoyeeByDepartmentID(int orderId);
    }

    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMyDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Employee> GetEmpoyeeByDepartmentID(int orderId)
        {
            return dbContext.Set<Employee>().Where(a => a.Id == orderId).ToList();
        }
    }


    public interface IMyDbContext: IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }

    public class MyDbContext :DbContext 
    {
      DbSet<Customer> Customers { get; set; }
      DbSet<Employee> Employees { get; set; }
    }



    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}
