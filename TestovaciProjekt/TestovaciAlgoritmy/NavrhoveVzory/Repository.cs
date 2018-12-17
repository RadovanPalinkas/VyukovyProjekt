using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//Repository pattern: nejprve je potřeba vytvořit Intarface které obsahuje několik metod Add(), Remove(), Get(), Find()
//neměl by obsahovat metody Save a Update.
//účelem je odddělit busines logiku od přístupu k datům

namespace TestovaciAlgoritmy.NavrhoveVzory
{

    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Remove(T entity);

    }

    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetByName(string name);
    }

    public class UserRepository : IEmployeeRepository
    {
        private readonly DbSet<Employee> store;

        public void Add(Employee entity)
        {
            store.Add(entity);
        }

        public IEnumerable<Employee> GetAll()
        {
            return store;
        }

        public Employee GetById(int id)
        {
            return store.Find(id);
        }

        public Employee GetByName(string name)
        {
            return store.Find(name); 
        }

        public void Remove(Employee entity)
        {
            store.Remove(entity);
        }

    }


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
}
