using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyDbContext :DbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }        
    }
}
