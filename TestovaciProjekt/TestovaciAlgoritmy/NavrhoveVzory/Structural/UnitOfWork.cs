using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// tento patern využívá repository patern
namespace TestovaciAlgoritmy.NavrhoveVzory.Structural
{

    public interface IUnitOfWork
    {
        ICustomerRepository iCustomerRepository { get; set; }
        IEmployeeRepository iEmployeeRepository { get; set; }
        void Comit();
        void Dispose();
    }

    public class UnitOfWork : IUnitOfWork
    {
        IMyDbContext dbContext;
        public ICustomerRepository iCustomerRepository { get; set; }
        public IEmployeeRepository iEmployeeRepository { get; set; }


        public UnitOfWork(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
            iCustomerRepository = new CustomerRepository(dbContext);
            iEmployeeRepository = new EmployeeRepository(dbContext);
        }

        public void Comit()
        {
            dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
