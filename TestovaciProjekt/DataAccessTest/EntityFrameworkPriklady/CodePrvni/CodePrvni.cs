using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessTest.EntityFrameworkPriklady.CodePrvni
{


    public class DoClass
    {
         public void CreateTable()
        {
            Customer customer = new Customer() { Name = "Radovan", Prijmeni = "Palinkáš"};
            Product product = new Product() {  Name = "Košile", Cena = 500};

            CodePrvni cp = new CodePrvni();
            cp.Customers.Add(customer);
            cp.Products.Add(product);
            cp.SaveChanges();
        }
    }

    //tato třída za všechno může 
    public class CodePrvni : DbContext
    {
        //DbSet namapuje instanci objektu 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public CodePrvni() : base(@"Data Source=DESKTOP-ECHHB9J\RADOVANSQL;Initial Catalog=AhojData; Integrated Security = True")
        {            
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prijmeni { get; set; }
        
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cena { get; set; }
    }
}
